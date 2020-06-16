using System.Net.Http;
using System.Threading.Tasks;

namespace MockWithManifestFileService
{

    public class GenderParser : IGenderParser
    {
        public async Task<GenderInfo> GetGenderInfo(string name)
        {
            GenderInfo genderInfo = null;
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"https://api.genderize.io/?name={name}");

                genderInfo = System.Text.Json.JsonSerializer.Deserialize<GenderInfo>(data);
            }
            return genderInfo;
        }
    }
}
