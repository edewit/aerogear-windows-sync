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
using Aerogear.Sync.Client;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Aerogear.Sync
{
    /// <summary>
    /// An in-memory implementation of <seealso cref="ClientDataStore"/>.
    /// <para>
    /// This implementation is mainly intended for testing and example applications.
    /// 
    /// </para>
    /// </summary>
    /// @param <T> The data type data that this implementation can handle. </param>
    /// @param <S> The type of <seealso cref="Edit"/>s that this implementation can handle. </param>
    public class InMemoryDataStore<T, S> : ClientDataStore<T, S> where S: Edit<Diff>
    {

        private readonly LinkedList<S> emptyQueue = new LinkedList<S>();
        private readonly IDictionary<Key, ClientDocument<T>> documents = new ConcurrentDictionary<Key, ClientDocument<T>>();
        private readonly IDictionary<Key, ShadowDocument<T>> shadows = new ConcurrentDictionary<Key, ShadowDocument<T>>();
        private readonly IDictionary<Key, BackupShadowDocument<T>> backups = new ConcurrentDictionary<Key, BackupShadowDocument<T>>();
        private readonly IDictionary<Key, LinkedList<S>> pendingEdits = new ConcurrentDictionary<Key, LinkedList<S>>();

        public void SaveShadowDocument(ShadowDocument<T> shadowDocument)
        {
            shadows.Add(key(shadowDocument.document()), shadowDocument);
        }

        public ShadowDocument<T> GetShadowDocument(string documentId, string clientId)
        {
            return shadows[key(documentId, clientId)];
        }

        public void SaveBackupShadowDocument(BackupShadowDocument<T> backupShadow)
        {
            backups.Add(key(backupShadow.shadow().document()), backupShadow);
        }

        public BackupShadowDocument<T> GetBackupShadowDocument(string documentId, string clientId)
        {
            return backups[key(documentId, clientId)];
        }

        public void SaveClientDocument(ClientDocument<T> document)
        {
            documents.Add(key(document), document);
        }

        public ClientDocument<T> GetClientDocument(string documentId, string clientId)
        {
            return documents[key(documentId, clientId)];
        }

        public void SaveEdits(S edit, string documentId, string clientId)
        {
            var thisKey = key(edit.DocumentId, edit.ClientId);
            if (!pendingEdits.ContainsKey(thisKey))
            {
                pendingEdits[thisKey] = new LinkedList<S>();
            }
                
            pendingEdits[thisKey].AddLast(edit);
        }

        public LinkedList<S> GetEdits(string documentId, string clientId)
        {
            return pendingEdits[key(documentId, clientId)];
        }

        public void RemoveEdits(string documentId, string clientId)
        {
            pendingEdits.Remove(key(documentId, clientId));
        }

        public void RemoveEdit(S edit, string documentId, string clientId)
        {
            pendingEdits[key(documentId, clientId)].Remove(edit);
        }

        private Key key(ClientDocument<T> document)
        {
            return key(document.Id, document.ClientId);
        }

        private static Key key(string documentId, string clientId)
        {
            return new Key(documentId, clientId);
        }

        private class Key
        {

            public string ClientId { get; protected set; }
            public string DocumentId { get; protected set; }

            public Key(string documentId, string clientId)
            {
                ClientId = clientId;
                DocumentId = documentId;
            }

            public override bool Equals(object o)
            {
                if (this == o)
                {
                    return true;
                }
                if (!(o is Key))
                {
                    return false;
                }

                Key id = (Key)o;

                if (ClientId != null ? !ClientId.Equals(id.ClientId) : id.ClientId != null)
                {
                    return false;
                }
                return DocumentId != null ? DocumentId.Equals(id.DocumentId) : id.DocumentId == null;
            }

            public override int GetHashCode()
            {
                int result = ClientId != null ? ClientId.GetHashCode() : 0;
                result = 31 * result + (DocumentId != null ? DocumentId.GetHashCode() : 0);
                return result;
            }
        }
    }
}
