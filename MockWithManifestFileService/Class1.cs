using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MockWithManifestFileService
{
    public interface IGenderParser
    {
        Task<GenderInfo> GetGenderInfo(string name);
    }

    public class GenderParser : IGenderParser
    {
        public async Task<GenderInfo> GetGenderInfo(string name)
        {
            GenderInfo genderInfo = null;
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"https://api.genderize.io/?name={name}");

                 genderInfo =  System.Text.Json.JsonSerializer.Deserialize<GenderInfo>(data);
            }
            return genderInfo;
        }
    }

    public interface IMessageCreator
    {
        Task<string> CreateMessage(string name);
    }

    public class MessageCreator : IMessageCreator
    {
        private readonly IGenderParser gender;

        public MessageCreator(IGenderParser gender)
        {
            this.gender = gender;
        }

        public async Task<string> CreateMessage(string name)
        {
            var genderInfo = await this.gender.GetGenderInfo(name);
            return genderInfo.gender == "male" ? "Hey boy!" : "Hey girl";
        }
    }

    public class GenderInfo
    {
        public string name { get; set; }
        public string gender { get; set; }
        //        "name": "andrea",
        //"gender": "male",
        //"probability": 0.62,
        //"count": 302977
    }
}
