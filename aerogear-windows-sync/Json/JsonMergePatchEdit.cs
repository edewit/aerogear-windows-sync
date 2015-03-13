
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
        public string ClientId { get { return clientId;  } }
        public string DocumentId { get { return documentId; } }
        public long ClientVersion { get { return clientVersion; } }
        public long ServerVersion { get { return serverVersion; } }
        public string Checksum { get { return checksum; } }
        private readonly JsonMergePatchDiff diff;

        private JsonMergePatchEdit(string clientId, string documentId, long clientVersion, long serverVersion, JsonMergePatchDiff diff)
        {
            this.clientId = clientId;
            this.clientVersion = clientVersion;
            this.documentId = documentId;
            this.serverVersion = serverVersion;
            this.checksum = Arguments.checkNotNull(checksum, "checksum must not be null");
            this.diff = diff;
        }

        JsonMergePatchDiff Edit<JsonMergePatchDiff>.GetDiff
        {
            get { return diff; }
        }

        public override string ToString()
        {
            return "JsonMergePatchEdit[serverVersion=" + ServerVersion + ", clientVersion=" + ClientVersion + ", checksum=" + Checksum + ", diffs=" + diff + ']';
        }
    }
}