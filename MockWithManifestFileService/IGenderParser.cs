using System.Threading.Tasks;

namespace MockWithManifestFileService
{
    public interface IGenderParser
    {
        Task<GenderInfo> GetGenderInfo(string name);
    }
}
