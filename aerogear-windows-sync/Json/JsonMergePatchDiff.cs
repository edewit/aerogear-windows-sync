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
