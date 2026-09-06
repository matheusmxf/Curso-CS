# ProjetoPedido — Codebase Overview & Why Program.cs Has Blue Underlines

## Summary

`ProjetoPedido` is a small **console application in C#** (.NET 10) that implements a classic order-management exercise (the "Order" challenge from the Nelio Alves C# course). It reads client data and order items from the console, builds an `Order` object composed of a `Client`, `OrderStatus`, and `List<OrderItem>` (each referencing a `Product`), and then prints an order summary.

The blue squiggly underlines the user sees in `Program.cs` are **compiler warnings**, not errors — specifically **nullable reference type warnings (CS8600 / CS8604)** caused by the interaction between `<Nullable>enable</Nullable>` and `Console.ReadLine()` returning a nullable `string?`. The code compiles and runs correctly; the underlines are informational.

## Why the Blue Underlines Appear (The Direct Answer)

The project has `<Nullable>enable</Nullable>` in `ProjetoPedido.csproj`. This tells the C# compiler to track whether a reference can be null and to warn when a nullable value is treated as non-nullable.

`Console.ReadLine()` returns `string?` (nullable — it can be `null` if the stream ends). The `Program.cs` code assigns or passes that `string?` into variables and methods that expect a non-nullable `string`. The compiler flags each of these with a **warning**, which VSCode's C# extension (Roslyn) renders as a **blue squiggly line** (red = error, green = suggestion, blue = warning).

The exact lines that get the blue underline:

| Line | Code | Warning Code | Why |
|------|------|--------------|-----|
| `string name = Console.ReadLine();` | CS8600 | Assigning `string?` to non-nullable `string` |
| `string email = Console.ReadLine();` | CS8600 | Same — `string?` → `string` |
| `DateTime birthDate = DateTime.Parse(Console.ReadLine());` | CS8604 | Passing `string?` into `DateTime.Parse(string)` |
| `OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());` | CS8604 | Passing `string?` into `Enum.Parse<TEnum>(string)` |
| `string nameProduct = Console.ReadLine();` | CS8600 | `string?` → `string` |
| `double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);` | CS8604 | Passing `string?` into `double.Parse(string, ...)` |
| `int quantity = int.Parse(Console.ReadLine());` | CS8604 | Passing `string?` into `int.Parse(string)` |

**These are non-blocking warnings.** The application still builds and runs. They are not bugs in behavior — the code assumes the user always types something, so `Console.ReadLine()` won't actually return `null` in the normal flow.

### How to fix (for reference, not applied here)
Use the null-forgiving operator `!` or the null-coalescing `??`:
- `string name = Console.ReadLine()!;` or `string name = Console.ReadLine() ?? "";`
- `int quantity = int.Parse(Console.ReadLine()!);`

Or remove `<Nullable>enable</Nullable>` from the `.csproj` (not recommended for modern code).

## Other Observations in the Code (Not warnings)

- **UX typo in `Program.cs`**: `System.Console.Write("Email");` is missing the colon/space — it shows `Email` instead of `Email: `. This is not a compiler warning, just a cosmetic bug in the prompt.
- **Enum typo/inconsistency** (`Entities/Enums/OrderStatus.cs`): `PendingPaymet` is misspelled (should be `PendingPayment`) and `DELIVERED` is all-caps while the others are PascalCase. Both are cosmetic; the enum compiles fine.
- **Missing validation**: `Enum.Parse<OrderStatus>` will throw `ArgumentException` if the user types an invalid status string (e.g. "Pending"). `int.Parse` / `double.Parse` / `DateTime.Parse` will throw `FormatException` on invalid input. The course exercise intentionally leaves these unhandled.

## Architecture

- **Type**: Console application (`OutputType=Exe`), .NET 10, C#.
- **Pattern**: Simple object-oriented domain model + a single `Program.Main` that drives the flow. No layers, no DI, no external dependencies.
- **Execution flow**: `Main` → reads client data (name/email/birth) → reads order status → constructs `Client` and `Order` → loops N times reading product/quantity → builds `OrderItem` → calls `order.AddItem()` → prints `order.ToString()` (the `Order.ToString()` builds a multiline summary using a `StringBuilder`).

## Directory Structure

```
ProjetoPedido/
├── Program.cs                    — Entry point; console I/O and object construction
├── ProjetoPedido.csproj          — Project config (net10.0, Nullable=enable, ImplicitUsings=enable)
├── Entities/
│   ├── Client.cs                 — Name, Email, BirthDate
│   ├── Order.cs                  — Moment, Status, Client, List<OrderItem>; AddItem/RemoveItem/Total/ToString
│   ├── OrderItem.cs              — Quantity, Price, Product; SubTotal()/ToString()
│   ├── Product.cs                — NameProduct, Price
│   └── Enums/
│       └── OrderStatus.cs        — PendingPaymet, Processing, Shipped, DELIVERED
├── bin/                          — Build output (generated)
└── obj/                          — Intermediate build files (generated)
```

## Key Abstractions

### Order
- **File**: `Entities/Order.cs`
- **Responsibility**: Aggregates the order's moment, status, client, and the list of order items. Owns the total computation.
- **Key members**: `Moment`, `Status`, `Client`, `Items` (initialized `= new List<OrderItem>()`); `AddItem()`, `RemoveItem()`, `Total()` (sums `item.SubTotal()`), `ToString()` (StringBuilder multiline summary).

### OrderItem
- **File**: `Entities/OrderItem.cs`
- **Responsibility**: A line item linking a `Product` to a quantity and price.
- **Key members**: `Quantity`, `Price`, `Product`; `SubTotal()` returns `Price * Quantity`; `ToString()` formats as `"{Product.NameProduct}, $Price, Quantity: N, Subtotal: $X"`.

### Product
- **File**: `Entities/Product.cs`
- **Responsibility**: Simple product value object.
- **Key members**: `NameProduct`, `Price`.

### Client
- **File**: `Entities/Client.cs`
- **Responsibility**: Customer data.
- **Key members**: `Name`, `Email`, `BirthDate`; `ToString()` returns `"{Name}, ({dd/MM/yyyy}) - {Email}"`.

### OrderStatus (enum)
- **File**: `Entities/Enums/OrderStatus.cs`
- **Values**: `PendingPaymet = 0`, `Processing = 1`, `Shipped = 2`, `DELIVERED = 3`.

## Data Flow (Program.cs)

1. Prompt user for `Name`, `Email`, `Birth date` → parse with `Console.ReadLine()` / `DateTime.Parse`.
2. Prompt for `Status` → `Enum.Parse<OrderStatus>(Console.ReadLine())`.
3. Construct `new Client(name, email, birthDate)` and `new Order(DateTime.Now, status, client)`.
4. Ask `How many items to this order?` → `int n = int.Parse(Console.ReadLine())`.
5. Loop `n` times: read `Product name`, `Product price` (`double.Parse` with `InvariantCulture`), `Quantity`; create `new Product(...)` and `new OrderItem(quantity, price, product)`; call `order.AddItem(orderItem)`.
6. Print `order` — `Order.ToString()` builds the summary and calls `Total()`.

## Suggested Reading Order

1. `Program.cs` — the entry point; explains how every entity is put together.
2. `Entities/Order.cs` — the aggregation root; shows how items + client + status combine and how the summary is formatted.
3. `Entities/OrderItem.cs` — the line-item model and price math.
4. `Entities/Product.cs` and `Entities/Client.cs` — simple value objects.
5. `Entities/Enums/OrderStatus.cs` — the status enum (note the typo).

---

**Note**: The reported issue (blue underlines) is expected given `<Nullable>enable</Nullable>` + `Console.ReadLine()` returning `string?`. The code is functionally correct — it's a warnings-only situation, not a compilation error.
