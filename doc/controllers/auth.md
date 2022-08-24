# Auth

```csharp
AuthController authController = client.AuthController;
```

## Class Name

`AuthController`


# Create Authenticate

```csharp
CreateAuthenticateAsync(
    string contentType,
    string authorization,
    string grantType)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contentType` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `grantType` | `string` | Form, Required | - |

## Response Type

[`Task<Models.AuthenticationResponse>`](../../doc/models/authentication-response.md)

## Example Usage

```csharp
string contentType = "application/x-www-form-urlencoded";
string authorization = "Basic dUhucXY2a3pveTJZQWM5NTdHRGhhbm5LUzZUVmltRzM6QkVBTGZhTVFuSnRsWEc4aQ==";
string grantType = "client_credentials";

try
{
    AuthenticationResponse result = await authController.CreateAuthenticateAsync(contentType, authorization, grantType);
}
catch (ApiException e){};
```

