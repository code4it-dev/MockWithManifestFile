using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockWithManifestFileService;
using NSubstitute;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace MockWithManifestFile
{
    [TestClass]
    public class GenderParserTest
    {

        [TestMethod]
        public async Task TestWithObjectCreation()
        {
            // Arrange
            var fakeObject = new GenderInfo { name = "Davide", gender = "male" };

            var fakeGenderParser = Substitute.For<IGenderParser>();
            fakeGenderParser.GetGenderInfo(default).ReturnsForAnyArgs(fakeObject);

            var sut = new MessageCreator(fakeGenderParser);

            // Act
            var message = await sut.CreateMessage("Davide");

            //Assert
            Assert.AreEqual("Hey boy!", message);
        }

        [TestMethod]
        public async Task TestWithEmbeddedResource()
        {
            // Arrange
            var fakeObject = await GetFakeGenderInfo();

            var fakeGenderParser = Substitute.For<IGenderParser>();
            fakeGenderParser.GetGenderInfo(default).ReturnsForAnyArgs(fakeObject);

            var sut = new MessageCreator(fakeGenderParser);

            // Act
            var message = await sut.CreateMessage("Davide");

            //Assert
            Assert.AreEqual("Hey boy!", message);
        }





        public async Task<GenderInfo> GetFakeGenderInfo()
        {
            var fileName = "MockWithManifestFileTests.Mocks.genderinfo-davide.json";

            var stream = Assembly.GetExecutingAssembly()
              .GetManifestResourceStream(fileName);

            return await JsonSerializer.DeserializeAsync<GenderInfo>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }).ConfigureAwait(false);
        }
    }
}
