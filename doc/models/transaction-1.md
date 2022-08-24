
# Transaction 1

## Structure

`Transaction1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Amount` | `int` | Required | - |
| `TransactionType` | `string` | Required | - |
| `Currency` | `string` | Required | - |
| `Description` | `string` | Required | - |
| `OrderId` | `string` | Required | - |

## Example (as JSON)

```json
{
  "amount": 1000,
  "transactionType": "REGULAR",
  "currency": "NZD",
  "description": "Widgets",
  "orderId": "145"
}
```

