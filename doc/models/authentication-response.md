
# Authentication Response

## Structure

`AuthenticationResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IssuedAt` | `string` | Required | - |
| `ApplicationName` | `string` | Required | - |
| `Scope` | `string` | Required | - |
| `Status` | `string` | Required | - |
| `ExpiresIn` | `string` | Required | - |
| `TokenType` | `string` | Required | - |
| `ClientId` | `string` | Required | - |
| `AccessToken` | `string` | Required | - |

## Example (as JSON)

```json
{
  "issued_at": "1464126466974",
  "application_name": "111111-2c4e-42cc-b613-fe974111111a",
  "scope": null,
  "status": "approved",
  "expires_in": "3599",
  "token_type": "BearerToken",
  "client_id": "axxxxxxxxxxx",
  "access_token": "bxxxxxxx"
}
```

