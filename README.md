# Gof.DesignPatterns

[Gof.DesignPatterns](https://www.nuget.org/packages/Gof.DesignPatterns/) is a .NET class library of **generic abstractions** for a subset of the Gang of Four (GoF) design patterns — those that can be expressed as reusable interfaces (and a few abstract bases).

The package is intended to speed up application code by giving you a shared vocabulary and type-safe contracts. You still write the domain-specific implementations. It is not a complete GoF catalog and not a drop-in replacement for a textbook “one class per pattern” sample.

**Supported targets:** `netstandard2.0`, `netstandard2.1`, `net8.0`, `net9.0`, `net10.0` (C# 14, nullable reference types enabled).

## Content

- [Disclaimer](#disclaimer)
- [Installation](#installation)
- [What this library provides](#what-this-library-provides)
- [Creational patterns](#creational-patterns)
  - [Abstract Factory](#abstract-factory)
  - [Builder](#builder)
  - [Prototype](#prototype)
  - [Factory Method](#factory-method)
  - [Singleton](#singleton)
- [Structural patterns](#structural-patterns)
  - [Adapter](#adapter)
  - [Bridge](#bridge)
  - [Composite](#composite)
- [Behavioral patterns](#behavioral-patterns)
  - [Chain of Responsibility](#chain-of-responsibility)
  - [Command](#command)
  - [Strategy](#strategy)
  - [Visitor](#visitor)
- [Concurrent APIs](#concurrent-apis)
- [Agent skill](#agent-skill)
- [Resources](#resources)
- [Contributing](#contributing)
- [License](#license)

## Disclaimer

Code and opinions in this repository are the author’s personal work, created in spare time. They do not represent the views of any employer and are not affiliated with, supported by, or funded by any employer.

[↑ Back to Content](#content)

## Installation

Latest stable package: **Gof.DesignPatterns** 2.0.1 on [NuGet](https://www.nuget.org/packages/Gof.DesignPatterns/).

```bash
dotnet add package Gof.DesignPatterns --version 2.0.1
```

Package Manager:

```powershell
Install-Package Gof.DesignPatterns -Version 2.0.1
```

[↑ Back to Content](#content)

## What this library provides

| Surface | Role |
| --- | --- |
| `DesignPatterns` | Synchronous interfaces (`IStrategy`, `IAdapter`, …) |
| `DesignPatterns.Implementation` | Shared bases: `SingletonBase<T>`, `DistributiveBuilderBase<T>`, `CompositeBase`, `ChainOfResponsibilityBase<TResult, TOperation>` |
| `DesignPatterns.Concurrent` | Async counterparts (`ExecuteAsync` / `HandleAsync` / `Task`-based APIs) |

**Included patterns**

- **Creational:** Abstract Factory, Builder, Prototype, Factory Method, Singleton
- **Structural:** Adapter, Bridge, Composite
- **Behavioral:** Chain of Responsibility, Command, Strategy, Visitor

Patterns without a generic abstraction in this repo (for example Observer or Decorator) are intentionally omitted.

[↑ Back to Content](#content)

---

## Creational patterns

Creational patterns isolate how objects are created so callers depend on contracts rather than concrete construction.

[↑ Back to Content](#content)

### Abstract Factory

**Intent.** Provide an interface for creating objects without binding callers to concrete types. In the GoF book, a factory typically exposes several methods that create a *family* of related products.

**In this library.** `IAbstractFactory<TResult>` and `IAbstractFactory<TResult, TInput>` model **one product role** per interface. The non-generic `IAbstractFactory.Create<TResult, TInput>` is a type-parameterized factory: the caller chooses both types at the call site. For a textbook family (for example `CreateButton()` + `CreateScrollBar()`), define your own interface with one member per product.

```csharp
using DesignPatterns;

public sealed class Company
{
    public required string Name { get; init; }
}

public sealed class CompanyFactory : IAbstractFactory<Company, string>
{
    public Company Create(string operationData) => new() { Name = operationData };
}

IAbstractFactory<Company, string> factory = new CompanyFactory();
Company company = factory.Create("Contoso");
```

[↑ Back to Content](#content)

### Builder

**Intent.** Separate construction of a complex object from its representation so the same process can produce different results.

**In this library.** `IBuilder<TResult>` is a single `Build()` step. `IDistributiveBuilder<TResult>` (and `DistributiveBuilderBase<TResult>`) registers an ordered list of mutations. With `safely: true`, a mutation that throws is skipped instead of aborting the chain.

```csharp
using DesignPatterns;
using DesignPatterns.Implementation;

public sealed class Order
{
    public string Customer { get; set; } = "";
    public decimal Total { get; set; }
}

public sealed class StaticReportBuilder : IBuilder<string>
{
    public string Build() => "monthly-report";
}

var order = new DistributiveBuilderBase<Order>()
    .AddMutation(o => o.Customer = "Ada")
    .AddMutation(o => o.Total = 19.99m)
    .Build();
```

[↑ Back to Content](#content)

### Prototype

**Intent.** Create new objects by copying a prototypical instance rather than constructing from scratch.

**In this library.** `IPrototype<TThis>.Clone()` — you decide shallow vs deep copy.

```csharp
using DesignPatterns;

public sealed class Document : IPrototype<Document>
{
    public required string Title { get; init; }

    public Document Clone() => new() { Title = Title };
}

var original = new Document { Title = "Spec" };
Document copy = original.Clone();
```

[↑ Back to Content](#content)

### Factory Method

**Intent.** Define an interface for creating an object, and let subclasses (or implementations) decide the concrete type.

**In this library.** `IFactoryMethod<TResult>.Instantiate()`.

```csharp
using DesignPatterns;

public sealed class Widget { }

public sealed class WidgetFactory : IFactoryMethod<Widget>
{
    public Widget Instantiate() => new Widget();
}

Widget widget = new WidgetFactory().Instantiate();
```

[↑ Back to Content](#content)

### Singleton

**Intent.** Ensure a type has one shared instance and a single access point.

**In this library.** `ISingleton<TThis>.GetInstance()` and `SingletonBase<TThis>` (`where TThis : new()`). The instance is stored in a static field (eager, thread-safe via .NET type initialization). The `new()` constraint means the language **cannot** forbid `new TThis()`; treat `GetInstance()` as the intended entry point. `GetInstance` is an instance method: construct a throwaway host and ask it for the shared instance.

```csharp
using DesignPatterns.Implementation;

public sealed class ConfigurationStore : SingletonBase<ConfigurationStore>
{
    public string Environment { get; set; } = "Production";
}

var first = new ConfigurationStore().GetInstance();
var second = new ConfigurationStore().GetInstance();
// first and second are the same object
```

[↑ Back to Content](#content)

---

## Structural patterns

Structural patterns compose classes and objects into larger structures without making them rigid.

[↑ Back to Content](#content)

### Adapter

**Intent.** Convert one interface into another so otherwise incompatible types can work together.

**In this library.** `IAdapter<TSource, TResult>.Adapt(TSource)`.

```csharp
using DesignPatterns;

public sealed record Customer(string Name);
public sealed record Company(string CompanyName);

public sealed class CustomerToCompanyAdapter : IAdapter<Customer, Company>
{
    public Company Adapt(Customer source) => new(source.Name);
}

Company company = new CustomerToCompanyAdapter().Adapt(new Customer("Ada"));
```

[↑ Back to Content](#content)

### Bridge

**Intent.** Split an abstraction from its implementation so the two can vary independently.

**In this library.** `IBridge<TImplementation>` exposes `Implementer`. Domain operations on the abstraction delegate to that implementer.

```csharp
using DesignPatterns;

public interface IRenderEngine
{
    string RenderCircle(int radius);
}

public sealed class SvgRenderEngine : IRenderEngine
{
    public string RenderCircle(int radius) => $"<circle r=\"{radius}\" />";
}

public sealed class CircleBridge : IBridge<IRenderEngine>
{
    public CircleBridge(IRenderEngine implementer, int radius)
    {
        Implementer = implementer;
        Radius = radius;
    }

    public IRenderEngine Implementer { get; }
    public int Radius { get; }

    public string Draw() => Implementer.RenderCircle(Radius);
}

string svg = new CircleBridge(new SvgRenderEngine(), 10).Draw();
```

[↑ Back to Content](#content)

### Composite

**Intent.** Compose objects into a tree and treat leaves and nodes uniformly.

**In this library.** `IComposite` (`Add`, `Remove`, `Clear`, `IsComposite`) and `CompositeBase` (in-memory list). `IsComposite()` is `true` when the node has children.

```csharp
using DesignPatterns;

public sealed class Node(string name) : CompositeBase
{
    public string Name { get; } = name;
}

var root = new Node("Root");
var child = new Node("Child");
root.Add(child);
bool hasChildren = root.IsComposite(); // true
root.Remove(child);
```

[↑ Back to Content](#content)

---

## Behavioral patterns

Behavioral patterns assign responsibilities and shape communication between objects.

[↑ Back to Content](#content)

### Chain of Responsibility

**Intent.** Pass a request along a chain of handlers until one handles it.

**In this library.** `IChainOfResponsibility<TResult, TOperation>` and `ChainOfResponsibilityBase<TResult, TOperation>`. Each handler has at most one successor. `AddNextHandler` registers the next link and **returns that next handler** so you can continue chaining from the tail. `RegisterNext` replaces the current successor.

```csharp
using DesignPatterns.Implementation;

public sealed class PositiveHandler : ChainOfResponsibilityBase<string, int>
{
    public override string Handle(int operationData)
    {
        if (operationData > 0) return "Positive";
        return Next is not null ? Next.Handle(operationData) : "Unknown";
    }
}

public sealed class NegativeHandler : ChainOfResponsibilityBase<string, int>
{
    public override string Handle(int operationData)
    {
        if (operationData < 0) return "Negative";
        return Next is not null ? Next.Handle(operationData) : "Unknown";
    }
}

var head = new PositiveHandler();
head.AddNextHandler(new NegativeHandler());
string sign = head.Handle(-3); // "Negative"
```

[↑ Back to Content](#content)

### Command

**Intent.** Encapsulate a request as an object so you can parameterize, queue, or log operations.

**In this library.** `ICommand` (`Execute()`), `ICommand<TResult>`, and `ICommand<TResult, TExecutor>` (execute against a collaborator).

```csharp
using DesignPatterns;

public sealed class Ledger
{
    public int Balance { get; set; }
}

public sealed class CreditCommand : ICommand<Ledger, int>
{
    private readonly Ledger _ledger;

    public CreditCommand(Ledger ledger) => _ledger = ledger;

    public Ledger Execute(int amount)
    {
        _ledger.Balance += amount;
        return _ledger;
    }
}

var ledger = new CreditCommand(new Ledger()).Execute(50);
```

[↑ Back to Content](#content)

### Strategy

**Intent.** Encapsulate algorithms and make them interchangeable inside a context.

**In this library.** `IStrategy`, `IStrategy<TResult>`, and `IStrategy<TResult, TData>`.

```csharp
using DesignPatterns;

public sealed class UpperCaseStrategy : IStrategy<string, string>
{
    public string Execute(string data) => data.ToUpperInvariant();
}

public sealed class LowerCaseStrategy : IStrategy<string, string>
{
    public string Execute(string data) => data.ToLowerInvariant();
}

IStrategy<string, string> strategy = new UpperCaseStrategy();
string text = strategy.Execute("GoF");
```

[↑ Back to Content](#content)

### Visitor

**Intent.** Add operations to a type hierarchy without modifying the element types, via double dispatch (`Accept` / `Visit`).

**In this library.** `IAcceptor` / `IVisitor` and `IAcceptor<TResult>` / `IVisitor<TResult>`. Concrete acceptors typically dispatch to a more specific visitor interface when available.

```csharp
using System;
using DesignPatterns;

public sealed class StringAcceptor(string value) : IAcceptor<string>
{
    public string Value { get; } = value;

    public string Accept(IVisitor<string> visitor) => visitor.Visit(this);
}

public sealed class UpperCaseVisitor : IVisitor<string>
{
    public string Visit(IAcceptor<string> acceptor) => acceptor switch
    {
        StringAcceptor s => s.Value.ToUpperInvariant(),
        _ => throw new NotSupportedException(acceptor.GetType().Name)
    };
}

string result = new StringAcceptor("gof").Accept(new UpperCaseVisitor());
```

[↑ Back to Content](#content)

---

## Concurrent APIs

`DesignPatterns.Concurrent` mirrors the same pattern set with asynchronous methods (`Task` / `Task<T>`). Use these when the work is I/O-bound or already async in your application.

```csharp
using DesignPatterns.Concurrent;

public sealed class UpperCaseStrategy : IStrategy<string, string>
{
    public Task<string> ExecuteAsync(string data)
        => Task.FromResult(data.ToUpperInvariant());
}

string text = await new UpperCaseStrategy().ExecuteAsync("GoF");
```

There is also a concurrent `ChainOfResponsibilityBase` under `DesignPatterns.Concurrent.Implementation`.

Worked examples used by the test suite live under [`src/DesignPatterns.Tests/Examples`](src/DesignPatterns.Tests/Examples).

[↑ Back to Content](#content)

## Agent skill

Tool-agnostic instructions for applying these abstractions (pattern map, caveats, when not to use the package) live in [`SKILL.md`](SKILL.md). Point any coding assistant at that file when implementing or reviewing GoF usage with this library.

[↑ Back to Content](#content)

## Resources

- [Refactoring.Guru – Design Patterns](https://refactoring.guru/design-patterns)
- [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns) (GoF)

[↑ Back to Content](#content)

## Contributing

Issues and pull requests are welcome: improvements to existing abstractions, additional examples, or documentation fixes.

[↑ Back to Content](#content)

## License

This project is licensed under the **Apache License 2.0**. See [LICENSE.md](LICENSE.md) for the full text.

[↑ Back to Content](#content)
