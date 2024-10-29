using Microsoft.Graph;
using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph.Models;
using Microsoft.Graph.Me.SendMail;

class Program
{
    static async Task Main(string[] args)
    {
        var scopes = new[] { "Mail.Send", "User.Read" };
          var tenantId = "###";  // Or your own tenant ID
        var clientId = "###";  // Your app registration clientId

        var options = new DeviceCodeCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            ClientId = clientId,
            TenantId = tenantId,
            DeviceCodeCallback = (code, cancellation) =>
            {
                Console.WriteLine(code.Message);  // Displays the code for the user to enter in the browser
                return Task.FromResult(0);
            }
        };

        var deviceCodeCredential = new DeviceCodeCredential(options);
        var graphClient = new GraphServiceClient(deviceCodeCredential, scopes);

        // Sending mail
        await SendMailAsync(graphClient);
    }

    private static async Task SendMailAsync(GraphServiceClient graphClient)
    {
        var requestBody = new SendMailPostRequestBody
{
    Message = new Message
    {
        Subject = "Microsoft Graph API R&D",
        Body = new ItemBody
        {
            ContentType = BodyType.Html,
            Content = " <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 20px;'>    <div" +
            "  style='background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);'>" + 
        "<h1 style='color: #333; font-size: 24px; margin-bottom: 10px;'>Microsoft Graph Api Test .NET Console Project</h1>" +
       " <p style='color: #555; font-size: 16px; line-height: 1.5;'>Hello,</p>" + 
        "<p style='color: #555; font-size: 16px; line-height: 1.5;'>" +
            "This is an automatic email. Authentication was done from a .NET 8 Console project using a " +
            "<a href='https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-device-code' target='_blank'"+ "style='color: #007bff; text-decoration: none;'>Device code provider </a> "+ 
            "and after the user logged in, the email was sent on behalf of the user by the application.</p>"+
       "<p style='margin-top: 20px; font-size: 16px; font-weight: bold; color: #333;'>"+ 
            "Best regards,<br>Enes Zeren </p>   </div> </body>",
        },
        ToRecipients = new List<Recipient>
        {
            new Recipient
            {
                EmailAddress = new EmailAddress
                {
                    Address = "test@gmail.com",
                },
            },
        },
        CcRecipients = new List<Recipient>
        {
            new Recipient
            {
                EmailAddress = new EmailAddress
                {
                    Address = "test@gmail.com",
                },
            },
        },
    },
    SaveToSentItems = false,
};


        // Sending SendMail request
        try
        {
            if (graphClient.Me != null)
            {
                await graphClient.Me.SendMail.PostAsync(requestBody); 
                Console.WriteLine("Email sent successfully.");
            }
            else
            {
                Console.WriteLine("GraphClient.Me is null; the user may not have signed in.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during email sending: {ex.Message}");
        }
    }
}
