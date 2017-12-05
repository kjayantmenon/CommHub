
namespace CommunicationHub.Contracts
{
    using CommunicationHub.Models;
    using Newtonsoft.Json.Linq;
    using System.Threading.Tasks;

    public interface ICommunicationHubManager
    {
        Task<string> RegisterApplicationAsync(AppRegistrationInfo appRegistrationInfo);

        Task<string> RegisterUserAsync(UserRegistrationInfo userRegistrationInfo);

        Task<string> ProcessMessageAsync(string applicationId,dynamic payLoad);
    }
}
