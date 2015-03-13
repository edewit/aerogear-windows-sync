using Aerogear.Sync.Json;
using JsonDiffPatch;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json.Linq;

namespace tests
{
    [TestClass]
    public class JsonMergePatchDiffTest
    {
        [TestMethod]
        public void Equals()
        {
            JsonMergePatchDiff x = JsonMergePatchDiff.FromJsonNode(JToken.Parse(@"{""name"":""Fletch""}"));
            JsonMergePatchDiff y = JsonMergePatchDiff.FromJsonNode(JToken.Parse(@"{""name"":""Fletch""}"));
            Assert.AreEqual(x, y);
        }
    }
}
