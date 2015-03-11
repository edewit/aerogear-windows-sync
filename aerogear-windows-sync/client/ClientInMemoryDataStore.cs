/// <summary>
/// JBoss, Home of Professional Open Source
/// Copyright Red Hat, Inc., and individual contributors.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
/// 	http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </summary>
namespace Aerogear.Sync.Client
{
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    /// <summary>
    /// An in-memory implementation of <seealso cref="ClientDataStore"/>.
    /// <para>
    /// This implementation is mainly intended for testing and example applications.
    /// 
    /// </para>
    /// </summary>
    /// @param <T> The data type data that this implementation can handle. </param>
    /// @param <S> The type of <seealso cref="Edit"/>s that this implementation can handle. </param>
    public class ClientInMemoryDataStore<T, S> : ClientDataStore<T, S> where S : Edit<Diff>
    {

        private readonly LinkedList<S> emptyQueue = new LinkedList<S>();
        private readonly IDictionary<Id, ClientDocument<T>> documents = new ConcurrentDictionary<Id, ClientDocument<T>>();
        private readonly IDictionary<Id, ShadowDocument<T>> shadows = new ConcurrentDictionary<Id, ShadowDocument<T>>();
        private readonly IDictionary<Id, BackupShadowDocument<T>> backups = new ConcurrentDictionary<Id, BackupShadowDocument<T>>();
        private readonly IDictionary<Id, LinkedList<S>> pendingEdits = new ConcurrentDictionary<Id, LinkedList<S>>();

        public void SaveShadowDocument(ShadowDocument<T> shadowDocument)
        {
            shadows.Add(id(shadowDocument.document()), shadowDocument);
        }

        public ShadowDocument<T> GetShadowDocument(string documentId, string clientId)
        {
            return shadows[id(documentId, clientId)];
        }

        public void SaveBackupShadowDocument(BackupShadowDocument<T> backupShadow)
        {
            backups.Add(id(backupShadow.shadow().document()), backupShadow);
        }

        public BackupShadowDocument<T> GetBackupShadowDocument(string documentId, string clientId)
        {
            return backups[id(documentId, clientId)];
        }

        public void SaveClientDocument(ClientDocument<T> document)
        {
            documents.Add(id(document), document);
        }

        public ClientDocument<T> GetClientDocument(string documentId, string clientId)
        {
            return documents[id(documentId, clientId)];
        }

        public void SaveEdits(S edit, string documentId, string clientId)
        {

        }

        public LinkedList<S> GetEdits(string documentId, string clientId)
        {
            return null;
        }

        public void RemoveEdits(string documentId, string clientId)
        {

        }

        public void RemoveEdit(S edit, string documentId, string clientId)
        {
            
        }

        private Id id(ClientDocument<T> document)
        {
            return id(document.Id(), document.clientId());
        }

        private static Id id(string documentId, string clientId)
        {
            return new Id(documentId, clientId);
        }

        private class Id
        {

            private readonly string clientId_Renamed;
            private readonly string documentId;

            public Id(string documentId, string clientId)
            {
                this.clientId_Renamed = clientId;
                this.documentId = documentId;
            }

            public virtual string clientId()
            {
                return clientId_Renamed;
            }

            public virtual string DocumentId
            {
                get
                {
                    return documentId;
                }
            }

            public override bool Equals(object o)
            {
                if (this == o)
                {
                    return true;
                }
                if (!(o is Id))
                {
                    return false;
                }

                Id id = (Id)o;

                if (clientId_Renamed != null ? !clientId_Renamed.Equals(id.clientId_Renamed) : id.clientId_Renamed != null)
                {
                    return false;
                }
                return documentId != null ? documentId.Equals(id.documentId) : id.documentId == null;
            }

            public override int GetHashCode()
            {
                int result = clientId_Renamed != null ? clientId_Renamed.GetHashCode() : 0;
                result = 31 * result + (documentId != null ? documentId.GetHashCode() : 0);
                return result;
            }
        }
    }
}