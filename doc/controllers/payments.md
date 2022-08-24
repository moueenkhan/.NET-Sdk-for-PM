# Payments

```csharp
PaymentsController paymentsController = client.PaymentsController;
```

## Class Name

`PaymentsController`

## Methods

* [Create a Regular Payment](../../doc/controllers/payments.md#create-a-regular-payment)
* [Get Autopay Details](../../doc/controllers/payments.md#get-autopay-details)
* [Create a Refund](../../doc/controllers/payments.md#create-a-refund)
* [Retrieve Multiple Payments](../../doc/controllers/payments.md#retrieve-multiple-payments)


# Create a Regular Payment

```csharp
CreateARegularPaymentAsync(
    string accept,
    string contentType,
    string authorization,
    Models.RegularPaymentReqBody regularPaymentBody)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `contentType` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `regularPaymentBody` | [`Models.RegularPaymentReqBody`](../../doc/models/regular-payment-req-body.md) | Body, Required | - |

## Response Type

[`Task<Models.RegularPaymentResponse>`](../../doc/models/regular-payment-response.md)

## Example Usage

```csharp
string accept = "application/vnd.paymark_api+json";
string contentType = "application/vnd.paymark_api+json";
string authorization = "Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw";
var regularPaymentBody = new RegularPaymentReqBody();
regularPaymentBody.Bank = new Bank();
regularPaymentBody.Bank.PayerId = "0215551234";
regularPaymentBody.Bank.BankId = "ASB";
regularPaymentBody.Bank.PayerIdType = "MOBILE";
regularPaymentBody.Merchant = new Merchant();
regularPaymentBody.Merchant.MerchantIdCode = "301234567";
regularPaymentBody.Merchant.MerchantUrl = "https://www.widgets.co.nz/";
regularPaymentBody.Merchant.CallbackUrl = "https://www.widgets.co.nz/callback?order=145";
regularPaymentBody.Transaction = new Transaction();
regularPaymentBody.Transaction.Amount = 1000;
regularPaymentBody.Transaction.TransactionType = "REGULAR";
regularPaymentBody.Transaction.Currency = "NZD";
regularPaymentBody.Transaction.Description = "Widgets";
regularPaymentBody.Transaction.OrderId = "145";
regularPaymentBody.Transaction.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36";
regularPaymentBody.Transaction.UserIpAddress = "192.168.0.1";

try
{
    RegularPaymentResponse result = await paymentsController.CreateARegularPaymentAsync(accept, contentType, authorization, regularPaymentBody);
}
catch (ApiException e){};
```


# Get Autopay Details

```csharp
GetAutopayDetailsAsync(
    string accept,
    string contentType,
    string authorization,
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `contentType` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `id` | `string` | Template, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
string accept = "application/vnd.paymark_api+json";
string contentType = "application/vnd.paymark_api+json";
string authorization = "Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw";
string id = "381a08c8-9189-4995-b07b-6c3821f70e35";

try
{
    await paymentsController.GetAutopayDetailsAsync(accept, contentType, authorization, id);
}
catch (ApiException e){};
```


# Create a Refund

```csharp
CreateARefundAsync(
    string accept,
    string contentType,
    string authorization,
    Models.RefundReqBody refundReqBody)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `contentType` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `refundReqBody` | [`Models.RefundReqBody`](../../doc/models/refund-req-body.md) | Body, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
string accept = "application/vnd.paymark_api+json";
string contentType = "application/vnd.paymark_api+json";
string authorization = "Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw";
var refundReqBody = new RefundReqBody();
refundReqBody.Merchant = new Merchant2();
refundReqBody.Merchant.MerchantIdCode = "301234567";
refundReqBody.Transaction = new Transaction2();
refundReqBody.Transaction.RefundAmount = 1000;
refundReqBody.Transaction.RefundReason = "Defective goods";
refundReqBody.Transaction.RefundId = "R145";
refundReqBody.Transaction.OriginalPaymentId = "381a08c8-9189-4995-b07b-6c3821f70e35";
refundReqBody.Transaction.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36";
refundReqBody.Transaction.UserIpAddress = "192.168.0.1";

try
{
    await paymentsController.CreateARefundAsync(accept, contentType, authorization, refundReqBody);
}
catch (ApiException e){};
```


# Retrieve Multiple Payments

```csharp
RetrieveMultiplePaymentsAsync(
    int orderId,
    int merchantIdCode,
    int payerId,
    DateTime fromCreationTime,
    DateTime toCreationTime,
    DateTime fromActualSettlementDate,
    DateTime toActualSettlementDate,
    string status,
    string offset,
    int limit,
    string accept,
    string contentType,
    string authorization)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `int` | Query, Required | - |
| `merchantIdCode` | `int` | Query, Required | - |
| `payerId` | `int` | Query, Required | - |
| `fromCreationTime` | `DateTime` | Query, Required | - |
| `toCreationTime` | `DateTime` | Query, Required | - |
| `fromActualSettlementDate` | `DateTime` | Query, Required | - |
| `toActualSettlementDate` | `DateTime` | Query, Required | - |
| `status` | `string` | Query, Required | - |
| `offset` | `string` | Query, Required | - |
| `limit` | `int` | Query, Required | - |
| `accept` | `string` | Header, Required | - |
| `contentType` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
int orderId = 165;
int merchantIdCode = 301234567;
int payerId = 37147292;
DateTime fromCreationTime = DateTime.Parse("2016-03-13T12:52:32.123Z");
DateTime toCreationTime = DateTime.Parse("2016-03-13T12:52:32.123Z");
DateTime fromActualSettlementDate = DateTime.Parse("2016-03-13T12:52:32.123Z");
DateTime toActualSettlementDate = DateTime.Parse("2016-03-13T12:52:32.123Z");
string status = "AUTHORISED";
string offset = "0fe3085c-1f8a-4830-b587-f778d0f5340a";
int limit = 2;
string accept = "application/vnd.paymark_api+json";
string contentType = "application/vnd.paymark_api+json";
string authorization = "Bearer 2qYLkfqqeDb77GkYcgW1eAaNpGvY";

try
{
    dynamic result = await paymentsController.RetrieveMultiplePaymentsAsync(orderId, merchantIdCode, payerId, fromCreationTime, toCreationTime, fromActualSettlementDate, toActualSettlementDate, status, offset, limit, accept, contentType, authorization);
}
catch (ApiException e){};
```

