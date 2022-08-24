
# Client Class Documentation

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

## PayMark EFTPOSClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| AuthController | Gets AuthController controller. |
| PaymentsController | Gets PaymentsController controller. |
| OAuthAuthorizationController | Gets OAuthAuthorizationController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| Auth | Gets the AuthManager. | `AuthManager` |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the PayMark EFTPOSClient using the values provided for the builder. | `Builder` |

## PayMark EFTPOSClient Builder Class

Class to build instances of PayMark EFTPOSClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `Auth(AuthManager auth)` | Gets the AuthManager. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |

