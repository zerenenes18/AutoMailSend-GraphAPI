<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Microsoft Graph API Mail Sender Console Application</title>
</head>
<body style="font-family: Arial, sans-serif; margin: 20px; color: #333;">
    <h1 style="color: #333;">Microsoft Graph API Mail Sender Console Application</h1>
    <p>This guide walks you through creating a .NET 8 console application that sends emails using Microsoft Graph API and Device Code Authentication. You’ll learn to set up Azure app registration, configure permissions, and use the Microsoft Graph SDK to send an email.</p>

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

    <h2>Step 2: Set Up the Console Application</h2>

    <h3>2.1 Create a New .NET Console Application</h3>
    <ol>
        <li>Open a terminal and create a new project with the following command:
            <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">dotnet new console -n GraphMailSender</pre>
        </li>
        <li>Change into the project directory:
            <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">cd GraphMailSender</pre>
        </li>
    </ol>

    <h3>2.2 Install Microsoft Graph SDK</h3>
    <p>Add the Microsoft Graph SDK package to your project:</p>
    <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">dotnet add package Microsoft.Graph<br>dotnet add package Azure.Identity</pre>

    <h3>2.3 Run the Application</h3>
    <ol>
        <li>Run the console application to send the email:
            <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px;">dotnet run</pre>
        </li>
        <li>A device code will be displayed in the console. Open a browser and navigate to the URL provided, then enter the code to authenticate.</li>
        <li>Once authenticated, the application will send an email using Microsoft Graph API on your behalf.</li>
    </ol>

    <p>This README should help you set up and use the Microsoft Graph API to send emails from a .NET Console application.</p>
</body>
</html>
