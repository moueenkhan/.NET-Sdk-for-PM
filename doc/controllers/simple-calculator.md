# Simple Calculator

```java
SimpleCalculatorController simpleCalculatorController = client.getSimpleCalculatorController();
```

## Class Name

`SimpleCalculatorController`


# Get Calculate

Calculates the expression using the specified operation.

```java
CompletableFuture<Double> getCalculateAsync(
    final GetCalculateInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | [`OperationTypeEnum`](../../doc/models/operation-type-enum.md) | Template, Required | The operator to apply on the variables |
| `x` | `double` | Query, Required | The LHS value |
| `y` | `double` | Query, Required | The RHS value |

## Response Type

`double`

## Example Usage

```java
GetCalculateInput getCalculateInput = new GetCalculateInput();
getCalculateInput.setOperation(OperationTypeEnum.MULTIPLY);
getCalculateInput.setX(222.14);
getCalculateInput.setY(165.14);


simpleCalculatorController.getCalculateAsync(getCalculateInput).thenAccept(result -> {
    // TODO success callback handler
}).exceptionally(exception -> {
    // TODO failure callback handler
    return null;
});
```

