
# Refund Req Body

## Structure

`RefundReqBody`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Merchant` | [`Models.Merchant2`](../../doc/models/merchant-2.md) | Required | - |
| `Transaction` | [`Models.Transaction2`](../../doc/models/transaction-2.md) | Required | - |

## Example (as JSON)

```json
{
  "merchant": {
    "merchantIdCode": "301234567"
  },
  "transaction": {
    "refundAmount": 1000,
    "refundReason": "Defective goods",
    "refundId": "R145",
    "originalPaymentId": "381a08c8-9189-4995-b07b-6c3821f70e35",
    "userAgent": "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36",
    "userIpAddress": "192.168.0.1"
  }
}
```

