using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockWithManifestFileService;
using System.Threading.Tasks;

namespace MockWithManifestFile
{
    [TestClass]
    public class GenderParserTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var p = new GenderParser();
            var g =await p.GetGenderInfo("davide");
            Assert.AreEqual("male", g.gender);
        }


        [TestMethod]
        public async Task T()
        {
            var p = new GenderParser();
            var m = new MessageCreator(p);
            var message = await m.CreateMessage("davide");

            Assert.AreEqual("Hey boy!", message);

        }
    }
}
