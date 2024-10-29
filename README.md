<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body style="font-family: Arial, sans-serif; margin: 20px; color: #333;">
    <h1 style="color: #333;">Microsoft Graph API Mail Sender Console Application</h1>
    <p>This guide walks you through setting up a .NET 8 console application that sends emails using Microsoft Graph API with Device Code Authentication. The instructions cover cloning the project from GitHub, configuring Azure app registration, and using the Microsoft Graph SDK to send an email.</p>
    <h2>Prerequisites</h2>
    <ul>
        <li><a href="https://dotnet.microsoft.com/download/dotnet/8.0" style="color: #007bff; text-decoration: none;">.NET SDK 8.0</a></li>
        <li><a href="https://portal.azure.com/" style="color: #007bff; text-decoration: none;">Azure Account</a> with permissions to register applications</li>
        <li>Optional: Familiarity with <a href="https://learn.microsoft.com/en-us/graph/overview" style="color: #007bff; text-decoration: none;">Microsoft Graph API</a></li>
    </ul>
    <h2>Step 1: Register the Application in Azure AD</h2>
    <h3>1.1 Go to Azure Active Directory</h3>
    <ol>
        <li>Log in to the <a href="https://portal.azure.com/" style="color: #007bff; text-decoration: none;">Azure Portal</a>.</li>
        <li>In the left sidebar, select <strong>Azure Active Directory</strong>.</li>
    </ol>
    <h3>1.2 Register a New Application</h3>
    <ol>
        <li>In <strong>Azure Active Directory</strong>, select <strong>App registrations</strong> from the left menu, then click <strong>New registration</strong>.</li>
        <li>Set the following details:
            <ul>
                <li><strong>Name</strong>: Choose a name, e.g., "GraphAPIMailSender".</li>
                <li><strong>Supported account types</strong>: Select <strong>Accounts in this organizational directory only</strong> (default).</li>
            </ul>
        </li>
        <li>Click <strong>Register</strong>.</li>
    </ol>
    <h3>1.3 Configure API Permissions</h3>
    <ol>
        <li>Go to your app's overview page and select <strong>API permissions</strong>.</li>
        <li>Click <strong>Add a permission</strong> > <strong>Microsoft Graph</strong> > <strong>Delegated permissions</strong>.</li>
        <li>Search and add the following permissions:
            <ul>
                <li><code>Mail.Send</code></li>
                <li><code>User.Read</code></li>
            </ul>
        </li>
        <li>Click <strong>Add permissions</strong> and then <strong>Grant admin consent</strong> to apply the permissions for all users.</li>
    </ol>
    <h3>1.4 Get the Client ID and Tenant ID</h3>
    <ol>
        <li>On the application <strong>Overview</strong> page, copy the <strong>Application (client) ID</strong> and <strong>Directory (tenant) ID</strong>.</li>
        <li>You’ll use these IDs in your application.</li>
    </ol>
    <h3>1.5 (Optional) Configure Redirect URIs</h3>
    <p>In <strong>Authentication</strong> settings, ensure you have set the <strong>Redirect URI</strong> to <code>https://login.microsoftonline.com/common/oauth2/nativeclient</code>.</p>
    <h2>Step 2: Clone and Run the Application</h2>
    <h3>2.1 Clone the GitHub Repository</h3>
    <p>Instead of creating a project from scratch, clone the repository and modify it with your own configuration details:</p>
    <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">gh repo clone zerenenes18/AutoMailSend-GraphAPI</pre>
    <h3>2.2 Update Configuration with Your Azure Details</h3>
    <p>Open the cloned project in your preferred IDE and replace placeholders in the code with your <strong>Client ID</strong> and <strong>Tenant ID</strong> from Step 1.4.</p>
    <h3>2.3 Install Required Packages</h3>
    <p>Ensure you have the required packages installed by running the following commands:</p>
    <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">dotnet add package Microsoft.Graph<br>dotnet add package Azure.Identity<br>dotnet add package Microsoft.Graph.Models<br>dotnet add package Microsoft.Graph.Me.SendMail</pre>
    <h3>2.4 Run the Application</h3>
    <ol>
        <li>Run the console application to send an email:
            <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">dotnet build<br>dotnet run</pre>
        </li>
        <li>A device code will be displayed in the console. Open a browser and navigate to the URL provided, then enter the code to authenticate.</li>
        <li>Once authenticated, the application will send an email using Microsoft Graph API on your behalf.</li>
    </ol>
    <p>This README provides all the steps needed to set up and use the Microsoft Graph API to send emails from a .NET Console application.</p>
</body>
</html>
