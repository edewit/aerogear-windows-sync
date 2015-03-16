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
using JsonDiffPatch;
using Newtonsoft.Json.Linq;

namespace Aerogear.Sync.Json
{
    public class JsonMergePatchClientSynchronizer : ClientSynchronizer<JToken, JsonMergePatchEdit>
    {
        ShadowDocument<JToken> ClientSynchronizer<JToken, JsonMergePatchEdit>.PatchShadow(JsonMergePatchEdit edit, ShadowDocument<JToken> shadowDocument)
        {
            throw new System.NotImplementedException();
        }

        ClientDocument<JToken> ClientSynchronizer<JToken, JsonMergePatchEdit>.PatchDocument(JsonMergePatchEdit edit, ClientDocument<JToken> document)
        {
            var patcher = new JsonPatcher();
            var content = document.Content;
            patcher.Patch(ref content, edit.Diff.JsonMergePatch());
            return new ClientDocument<JToken>(document.Id, document.ClientId, content);
        }

        JsonMergePatchEdit ClientSynchronizer<JToken, JsonMergePatchEdit>.ServerDiff(ClientDocument<JToken> document, ShadowDocument<JToken> shadowDocument)
        {
            var diff = new JsonDiffer().Diff(document.Content, shadowDocument.Document.Content);
            return new JsonMergePatchEdit(shadowDocument.Document.ClientId, shadowDocument.Document.Id, shadowDocument.ClientVersion, shadowDocument.ServerVersion, new JsonMergePatchDiff(diff));
        }

        JsonMergePatchEdit ClientSynchronizer<JToken, JsonMergePatchEdit>.ClientDiff(ShadowDocument<JToken> shadowDocument, ClientDocument<JToken> document)
        {
            var diff = new JsonDiffer().Diff(shadowDocument.Document.Content, document.Content);
            return new JsonMergePatchEdit(shadowDocument.Document.ClientId, shadowDocument.Document.Id, shadowDocument.ClientVersion, shadowDocument.ServerVersion, new JsonMergePatchDiff(diff));
        }

        PatchMessage<JsonMergePatchEdit> ClientSynchronizer<JToken, JsonMergePatchEdit>.CreatePatchMessage(string documentId, string clientId, System.Collections.Generic.LinkedList<JsonMergePatchEdit> edits)
        {
            throw new System.NotImplementedException();
        }

        PatchMessage<JsonMergePatchEdit> ClientSynchronizer<JToken, JsonMergePatchEdit>.PatchMessageFromJson(string json)
        {
            throw new System.NotImplementedException();
        }

        void ClientSynchronizer<JToken, JsonMergePatchEdit>.AddContent(JToken content, object objectNode, string fieldName)
        {
            throw new System.NotImplementedException();
        }
    }
}
