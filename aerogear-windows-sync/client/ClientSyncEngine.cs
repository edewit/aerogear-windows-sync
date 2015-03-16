/*
 * JBoss, Home of Professional Open Source.
 * Copyright Red Hat, Inc., and individual contributors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writtrrting, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Aerogear.Sync.Client
{
    public class ClientSyncEngine<T, S> where S : Edit<Diff>
    {
        private ClientSynchronizer<T, S> synchronizer;
        private DataStore<T, S> dataStore;

        public ClientSyncEngine(ClientSynchronizer<T, S> synchronizer, DataStore<T, S> dataStore)
        {
            this.synchronizer = synchronizer;
            this.dataStore = dataStore;
        }

        public void AddDocument(ClientDocument<T> clientDocument)
        {

        }

        /// <summary>
        /// Returns an <seealso cref="PatchMessage"/> which contains a diff against the engine's stored
        /// shadow document and the passed-in document.
        ///     
        /// There might be pending edits that represent edits that have not made it to the server
        /// for some reason (for example packet drop). If a pending edit exits the contents (the diffs)
        /// of the pending edit will be included in the returned Edits from this method.
        ///     
        /// The returned <seealso cref="PatchMessage"/> instance is indended to be sent to the server engine
        /// for processing.
        /// </summary>
        /// <param name="document"> the updated document. </param>
        /// <returns> <seealso cref="PatchMessage"/> containing the edits for the changes in the document. </returns>
        public virtual PatchMessage<S> diff(ClientDocument<T> document)
        {
            string documentId = document.Id;
            string clientId = document.ClientId;

            ShadowDocument<T> shadow = GetShadowDocument(documentId, clientId);
            S edit = ServerDiff(document, shadow);
            dataStore.SaveEdits(edit, documentId, clientId);
            ShadowDocument<T> patchedShadow = DiffPatchShadow(shadow, edit);
            SaveShadow(incrementClientVersion(patchedShadow));
            return GetPendingEdits(document.Id, document.ClientId);

        }

        private ShadowDocument<T> GetShadowDocument(string documentId, string clientId)
        {
            return dataStore.GetShadowDocument(documentId, clientId);
        }

        private S ServerDiff(ClientDocument<T> doc, ShadowDocument<T> shadow)
        {
            return synchronizer.ServerDiff(doc, shadow);
        }

        private ShadowDocument<T> DiffPatchShadow(ShadowDocument<T> shadow, S edit)
        {
            return synchronizer.PatchShadow(edit, shadow);
        }

        private ShadowDocument<T> SaveShadow(ShadowDocument<T> newShadow)
        {
            dataStore.SaveShadowDocument(newShadow);
            return newShadow;
        }

        private ShadowDocument<T> incrementClientVersion(ShadowDocument<T> shadow)
        {
            return newShadowDoc(shadow.ServerVersion, shadow.ClientVersion + 1, shadow.Document);
        }

        private ShadowDocument<T> newShadowDoc(long serverVersion, long clientVersion, ClientDocument<T> doc)
        {
            return new ShadowDocument<T>(serverVersion, clientVersion, doc);
        }

        private PatchMessage<S> GetPendingEdits(string documentId, string clientId)
        {
            return synchronizer.CreatePatchMessage(documentId, clientId, dataStore.GetEdits(documentId, clientId));
        }
    }
}