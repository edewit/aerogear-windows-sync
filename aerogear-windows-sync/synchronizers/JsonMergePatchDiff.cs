using JsonDiffPatch;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerogear.Sync.synchronizers
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

        public static JsonMergePatchDiff fromJsonNode(JToken jsonNode)
        {
            return new JsonMergePatchDiff(PatchDocument.Parse(jsonNode.ToString()), jsonNode.GetHashCode());
        }
    }
}
