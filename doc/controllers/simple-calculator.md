# Simple Calculator

```ts
const simpleCalculatorController = new SimpleCalculatorController(client);
```

## Class Name

`SimpleCalculatorController`


# Get Calculate

Calculates the expression using the specified operation.

```ts
async getCalculate(
  operation: OperationTypeEnum,
  x: number,
  y: number,
  requestOptions?: RequestOptions
): Promise<ApiResponse<number>>
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | [`OperationTypeEnum`](../../doc/models/operation-type-enum.md) | Template, Required | The operator to apply on the variables |
| `x` | `number` | Query, Required | The LHS value |
| `y` | `number` | Query, Required | The RHS value |
| `requestOptions` | `RequestOptions \| undefined` | Optional | Pass additional request options. |

## Response Type

`number`

## Example Usage

```ts
const operation = 'MULTIPLY';
const x = 222.14;
const y = 165.14;
try {
  const { result, ...httpResponse } = await simpleCalculatorController.getCalculate(operation, x, y);
  // Get more response info...
  // const { statusCode, headers } = httpResponse;
} catch(error) {
  if (error instanceof ApiError) {
    const errors = error.result;
    // const { statusCode, headers } = error;
  }
}
```

