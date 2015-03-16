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
using Newtonsoft.Json.Linq;
namespace Aerogear.Sync.Json
{
    public class JsonMergePatchEdit : Edit<JsonMergePatchDiff>
    {

        private readonly string clientId;
        private readonly string documentId;
        private readonly long clientVersion;
        private readonly long serverVersion;
        private readonly string checksum;
        private readonly JsonMergePatchDiff diff;
        public string ClientId { get { return clientId; } }
        public string DocumentId { get { return documentId; } }
        public long ClientVersion { get { return clientVersion; } }
        public long ServerVersion { get { return serverVersion; } }
        public string Checksum { get { return checksum; } }
        public JsonMergePatchDiff Diff { get { return diff; } }

        public JsonMergePatchEdit(string clientId, string documentId, long clientVersion, long serverVersion, JsonMergePatchDiff diff)
        {
            this.clientId = clientId;
            this.clientVersion = clientVersion;
            this.documentId = documentId;
            this.serverVersion = serverVersion;
            this.checksum = Arguments.checkNotNull(checksum, "checksum must not be null");
            this.diff = diff;
        }

        public override string ToString()
        {
            return "JsonMergePatchEdit[serverVersion=" + ServerVersion + ", clientVersion=" + ClientVersion + ", checksum=" + Checksum + ", diffs=" + diff + ']';
        }
    }
}