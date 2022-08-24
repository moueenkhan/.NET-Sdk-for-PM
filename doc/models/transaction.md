
# Transaction

## Structure

`Transaction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Amount` | `int` | Required | - |
| `TransactionType` | `string` | Required | - |
| `Currency` | `string` | Required | - |
| `Description` | `string` | Required | - |
| `OrderId` | `string` | Required | - |
| `UserAgent` | `string` | Required | - |
| `UserIpAddress` | `string` | Required | - |

## Example (as JSON)

```json
{
  "amount": 1000,
  "transactionType": "REGULAR",
  "currency": "NZD",
  "description": "Widgets",
  "orderId": "145",
  "userAgent": "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36",
  "userIpAddress": "192.168.0.1"
}
```

