
# Getting Started with PayMark EFTPOS

## Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (PayMarkEFTPOS.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8, Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

## Installation

The following section explains how to use the PayMarkEFTPOS.Standard library in a new project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=PayMark%20EFTPOS-CSharp&workspaceName=PayMarkEFTPOS&projectName=PayMarkEFTPOS.Standard&rootNamespace=PayMarkEFTPOS.Standard&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=PayMark%20EFTPOS-CSharp&workspaceName=PayMarkEFTPOS&projectName=PayMarkEFTPOS.Standard&rootNamespace=PayMarkEFTPOS.Standard&step=createProject)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=PayMark%20EFTPOS-CSharp&workspaceName=PayMarkEFTPOS&projectName=PayMarkEFTPOS.Standard&rootNamespace=PayMarkEFTPOS.Standard&step=setStartup)

### 3. Add reference of the library project

In order to use the Tester library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=PayMark%20EFTPOS-CSharp&workspaceName=PayMarkEFTPOS&projectName=PayMarkEFTPOS.Standard&rootNamespace=PayMarkEFTPOS.Standard&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `Tester.Tests` and click `OK`. By doing this, we have added a reference of the `Tester.Tests` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=PayMark%20EFTPOS-CSharp&workspaceName=PayMarkEFTPOS&projectName=PayMarkEFTPOS.Standard&rootNamespace=PayMarkEFTPOS.Standard&step=createReference)

### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=PayMark%20EFTPOS-CSharp&workspaceName=PayMarkEFTPOS&projectName=PayMarkEFTPOS.Standard&rootNamespace=PayMarkEFTPOS.Standard&step=addCode)

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.SandBox`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `OAuthClientId` | `string` | OAuth 2 Client ID |
| `OAuthClientSecret` | `string` | OAuth 2 Client Secret |
| `OAuthToken` | `Models.OAuthToken` | Object for storing information about the OAuth token |

The API client can be initialized as follows:

```csharp
PayMarkEFTPOS.Standard.PayMarkEFTPOSClient client = new PayMarkEFTPOS.Standard.PayMarkEFTPOSClient.Builder()
    .ClientCredentialsAuth("OAuthClientId", "OAuthClientSecret")
    .Environment(PayMarkEFTPOS.Standard.Environment.SandBox)
    .HttpClientConfig(config => config.NumberOfRetries(0))
    .Build();
```

## Authorization

This API uses `OAuth 2 Client Credentials Grant`.

## Client Credentials Grant

Your application must obtain user authorization before it can execute an endpoint call in case this SDK chooses to use *OAuth 2.0 Client Credentials Grant*. This authorization includes the following steps

The `FetchToken()` method will exchange the OAuth client credentials for an *access token*. The access token is an object containing information for authorizing client requests and refreshing the token itself.

```csharp
var authManager = client.ClientCredentialsAuth;

try
{
    OAuthToken token = authManager.FetchToken();
    // re-instantiate the client with OAuth token
    client = client.ToBuilder().OAuthToken(token).Build();
}
catch (ApiException e)
{
    // TODO Handle exception
}
```

The client can now make authorized endpoint calls.

### Storing an access token for reuse

It is recommended that you store the access token for reuse.

```csharp
// store token
SaveTokenToDatabase(client.ClientCredentialsAuth.OAuthToken);
```

### Creating a client from a stored token

To authorize a client from a stored access token, just set the access token in Configuration along with the other configuration parameters before creating the client:

```csharp
// load token later
OAuthToken token = LoadTokenFromDatabase();

// Provide token along with other configuration properties while instantiating the client
PayMarkEFTPOSClient client = client.ToBuilder().OAuthToken(token).Build();
```

### Complete example

```csharp
using PayMarkEFTPOS.Standard;
using PayMarkEFTPOS.Standard.Models;
using PayMarkEFTPOS.Standard.Exceptions;
using PayMarkEFTPOS.Standard.Authentication;
using System.Collections.Generic;
namespace OAuthTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PayMarkEFTPOS.Standard.PayMarkEFTPOSClient client = new PayMarkEFTPOS.Standard.PayMarkEFTPOSClient.Builder()
                .ClientCredentialsAuth("OAuthClientId", "OAuthClientSecret")
                .Environment(PayMarkEFTPOS.Standard.Environment.SandBox)
                .HttpClientConfig(config => config.NumberOfRetries(0))
                .Build();
            try
            {
                OAuthToken token = LoadTokenFromDatabase();

                // Set the token if it is not set before
                if (token == null)
                {
                    var authManager = client.ClientCredentialsAuth;
                    token = authManager.FetchToken();
                }

                SaveTokenToDatabase(token);
                client = client.ToBuilder().OAuthToken(token).Build();
            }
            catch (OAuthProviderException e)
            {
                // TODO Handle exception
            }
        }

        //function for storing token to database
        static void SaveTokenToDatabase(OAuthToken token)
        {
            //Save token here
        }

        //function for loading token from database
        static OAuthToken LoadTokenFromDatabase()
        {
            OAuthToken token = null;
            //token = Get token here
            return token;
        }
    }
}

// the client is now authorized and you can use controllers to make endpoint calls
```

## List of APIs

* [O Auth Authorization](doc/controllers/o-auth-authorization.md)
* [Auth](doc/controllers/auth.md)
* [Payments](doc/controllers/payments.md)

## Classes Documentation

* [Utility Classes](doc/utility-classes.md)
* [HttpRequest](doc/http-request.md)
* [HttpResponse](doc/http-response.md)
* [HttpStringResponse](doc/http-string-response.md)
* [HttpContext](doc/http-context.md)
* [HttpClientConfiguration](doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](doc/http-client-configuration-builder.md)
* [IAuthManager](doc/i-auth-manager.md)
* [ApiException](doc/api-exception.md)

