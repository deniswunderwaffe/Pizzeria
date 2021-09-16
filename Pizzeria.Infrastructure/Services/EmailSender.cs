using System;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace Pizzeria.Infrastructure.Services
{
   public class EmailSender: IEmailSender
   {
      public async Task SendEmailAsync(string email, string subject, string htmlMessage)
      {
         MailjetClient client =
            new MailjetClient("2bbe990ea3f4a0574e43b7e62c50eb57", "f254e34079a455bfb3441f1481203589");
         MailjetRequest request = new MailjetRequest
            {
               Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "rhnmskorpion@gmail.com")
            .Property(Send.FromName, "TestAuth")
            .Property(Send.Subject, subject)
            .Property(Send.HtmlPart, htmlMessage)
            .Property(Send.Recipients, new JArray {
               new JObject {
                  {"Email", email}
               }
            });
         MailjetResponse response = await client.PostAsync(request);
      }
   }
}