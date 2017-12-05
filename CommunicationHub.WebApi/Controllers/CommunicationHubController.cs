using CommunicationHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CommunicationHub.WebApi.Controllers
{

    public class CommunicationsHubController: ApiController
    {
        [HttpPost]
        [Route("api/CommunicationsHub/register")]
        public async Task<IHttpActionResult> RegisterApplication([FromBody]AppRegistrationInfo registrationDetails)
        {
            return Ok();
        }

        /// <summary>
        /// This method would register a new application to the communication hub.
        /// Post successful registration, the hub would be available to the application to send messages on the 
        /// various preferred channels.
        /// </summary>
        /// <param name="registrationDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CommunicationsHub/register")]
        public async Task<IHttpActionResult> RegisterUserApplication([FromBody]UserRegistrationInfo registrationDetails)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/CommunicationsHub/registrations/{appId}")]
        public async Task<List<UserRegistrationInfo>> GetAllRegistrationsForApp([FromUri]string appId)
        {
            List<UserRegistrationInfo> registrations = new List<UserRegistrationInfo>();
            return registrations;

        }



    }
}