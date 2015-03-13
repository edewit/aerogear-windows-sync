using Aerogear.Sync.Client;
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
            throw new System.NotImplementedException();
        }

        JsonMergePatchEdit ClientSynchronizer<JToken, JsonMergePatchEdit>.ServerDiff(ClientDocument<JToken> document, ShadowDocument<JToken> shadowDocument)
        {
            throw new System.NotImplementedException();
        }

        JsonMergePatchEdit ClientSynchronizer<JToken, JsonMergePatchEdit>.ClientDiff(ShadowDocument<JToken> shadowDocument, ClientDocument<JToken> document)
        {
            throw new System.NotImplementedException();
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
