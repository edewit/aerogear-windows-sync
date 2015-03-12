using JsonDiffPatch;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json.Linq;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var left = JToken.Parse("{ 'foo': 'bar'}");
            var right = JToken.Parse("{ 'foo': 'baz', 'bla': ['har'] }");

            var patchDoc = new JsonDiffer().Diff(left, right);

            var patcher = new JsonPatcher();
            patcher.Patch(ref left, patchDoc);


        }
    }
}
