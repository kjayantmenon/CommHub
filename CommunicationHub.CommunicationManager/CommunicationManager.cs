

namespace CommunicationHub
{
    using System.Threading.Tasks;
    using CommunicationHub.Contracts;
    using CommunicationHub.Models;
    using System;

    public class CommunicationManager : ICommunicationHubManager
    {
        public async Task<string> ProcessMessageAsync(string applicationId, dynamic payLoad)
        {
            //Create a jobId for the message process
            var jobId = Guid.NewGuid();
            //Validate Message
            //Get registered Channels for User
            //For each channel, get formatted message
            //Send a notifications on each channel

            return jobId.ToString();
        }

        public async Task<string> RegisterApplicationAsync(AppRegistrationInfo appRegistrationInfo)
        {
            var appId = Guid.NewGuid();
            return appId.ToString();
        }

        public async Task<string> RegisterUserAsync(UserRegistrationInfo userRegistrationInfo)
        {
            var userId = Guid.NewGuid();
            return userId.ToString();
        }
    }
}
