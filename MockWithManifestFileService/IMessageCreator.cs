using System.Threading.Tasks;

namespace MockWithManifestFileService
{
    public interface IMessageCreator
    {
        Task<string> CreateMessage(string name);
    }
}
