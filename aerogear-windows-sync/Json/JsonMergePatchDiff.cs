using JsonDiffPatch;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerogear.Sync.Json
{
    public class JsonMergePatchDiff : Diff
    {

        private readonly PatchDocument jsonMergePatch;
        private readonly int jsonNodeHashCode;

        private JsonMergePatchDiff(PatchDocument jsonMergePatch, int jsonNodeHashCode)
        {
            this.jsonMergePatch = Arguments.checkNotNull(jsonMergePatch, "jsonMergePatch must not be null");
            this.jsonNodeHashCode = Arguments.checkNotNull(jsonNodeHashCode, "jsonNodeHashCode must not be null");
        }

        public virtual PatchDocument JsonMergePatch()
        {
            return jsonMergePatch;
        }

        public override string ToString()
        {
            return "JsonMergePatchDiff[jsonMergePatch=" + jsonMergePatch + ']';
        }

        public static JsonMergePatchDiff FromJsonNode(JToken jsonNode)
        {
            return new JsonMergePatchDiff(PatchDocument.Parse(jsonNode.ToString()), jsonNode.GetHashCode());
        }

        public override bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || this.GetType() != o.GetType())
            {
                return false;
            }
            JsonMergePatchDiff that = (JsonMergePatchDiff)o;
            return jsonNodeHashCode == that.jsonNodeHashCode;
        }

        public override int GetHashCode()
        {
            int result = jsonMergePatch.GetHashCode();
            result = 31 * result + jsonNodeHashCode;
            return result;

        }
    }
}
