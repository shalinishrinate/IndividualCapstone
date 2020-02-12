using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using CapstoneProject.Models;
using Microsoft.AspNet.Identity;

namespace CapstoneProject.Controllers
{
    public class SMSController : TwilioController
    {
        // GET: SMS
        public ActionResult SendSms()
        {
            var accountSid = PrivateKeys.twilioaccountSid;
            var authToken = PrivateKeys.twilioAuthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(PrivateKeys.MyNumber);
            var from = new PhoneNumber(PrivateKeys.TwilioNumber);

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "The AIR Quality near your location is bad, take necessary precautions!");
            return Content(message.Sid);
        }
    }
}