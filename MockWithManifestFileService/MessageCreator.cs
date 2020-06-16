using System.Threading.Tasks;

namespace MockWithManifestFileService
{
    public class MessageCreator : IMessageCreator
    {
        private readonly IGenderParser gender;

        public MessageCreator(IGenderParser gender)
        {
            this.gender = gender;
        }

        public async Task<string> CreateMessage(string name)
        {
            var genderInfo = await gender.GetGenderInfo(name);
            return genderInfo.gender.Equals("male", System.StringComparison.OrdinalIgnoreCase) ? "Hey boy!" : "Hey girl!";
        }
    }
}
