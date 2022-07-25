using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ConsoleSms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            //string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            string accountSid = "";
            string authToken = "";

            string numTel = Console.ReadLine();
            string msg = Console.ReadLine();

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber("+19475002009"),
                to: new Twilio.Types.PhoneNumber("")
            );

            Console.WriteLine("Message Personalisé à partir de VisualStudio");
        }
    }
    
}