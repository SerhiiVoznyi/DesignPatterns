---
title: "GoF Design Patterns (Gof.DesignPatterns)"
name: gof-design-patterns
type: skill
status: reviewed
version: 1.0.0
last_reviewed: 2026-08-22
tooling: agnostic
package: Gof.DesignPatterns
languages:
  - csharp
namespaces:
  - DesignPatterns
  - DesignPatterns.Implementation
  - DesignPatterns.Concurrent
tags:
  - gof
  - design-patterns
  - csharp
  - nuget
  - abstractions
description: >-
  WHAT: Apply Gang of Four patterns via Gof.DesignPatterns contracts
  (interfaces and a few bases), not textbook sample classes.
  WHEN: Implementing or reviewing C#/.NET that should use Abstract Factory,
  Builder, Prototype, Factory Method, Singleton, Adapter, Bridge, Composite,
  Chain of Responsibility, Command, Strategy, or Visitor; or when the task
  names GoF, Gof.DesignPatterns, or this repository.
  NOT: Adding unpublished GoF types to this library unless the task asks to
  extend the package.
inputs:
  - C#/.NET change that may use a GoF pattern
  - optional existing application types
  - whether the flow is already asynchronous
outputs:
  - choice of one of the twelve shipped patterns
  - implementations of the matching interfaces or bases
related:
  - README.md
---

# GoF with Gof.DesignPatterns

## Metadata

| Field | Value |
| --- | --- |
| Title | GoF Design Patterns (Gof.DesignPatterns) |
| Id | `gof-design-patterns` |
| Type | skill |
| Tooling | agnostic (any assistant that can load this file) |
| Package | `Gof.DesignPatterns` |
| Language | C# |
| Namespaces | `DesignPatterns`, `DesignPatterns.Implementation`, `DesignPatterns.Concurrent` |
| Docs | [README.md](README.md) |
| Status | reviewed · v1.0.0 · 2026-08-22 |

**Load this skill** when choosing or implementing one of the twelve shipped patterns. **Skip it** for unrelated C# work or unpublished GoF patterns (Observer, Decorator, and similar) unless the task is to extend the library.

## Use when

- Writing or reviewing C# that should share these pattern contracts.
- Choosing among the **12 patterns this package actually ships**.

## Not when

- The user did not ask to extend the **library**: do not add missing GoF types (Observer, Decorator, Facade, Proxy, …) to this repo.
- A simpler constructor, function, or DI registration already solves the problem.

## Library facts

- Package: `Gof.DesignPatterns`. Interfaces plus a few bases — consumers implement domain types.
- Namespaces: `DesignPatterns`, `DesignPatterns.Implementation`, `DesignPatterns.Concurrent` (`Task` / `*Async`).
- Snippets and intent text: [README.md](README.md). Read it before inventing members.

## Method

1. Name the problem: **creation**, **structure**, or **behavior**.
2. Pick **one** pattern from the map below.
3. Implement the matching interface (or inherit the listed base). Inject implementations via constructors in app code.
4. If the work is already async, use `DesignPatterns.Concurrent` counterparts, not `.Result` / `.Wait()`.

## Pattern to type map

| Pattern | Types |
| --- | --- |
| Abstract Factory | `IAbstractFactory`, `IAbstractFactory<TResult>`, `IAbstractFactory<TResult, TInput>` |
| Builder | `IBuilder<TResult>`, `IDistributiveBuilder<TResult>`, `DistributiveBuilderBase<TResult>` |
| Prototype | `IPrototype<TThis>` |
| Factory Method | `IFactoryMethod<TResult>` |
| Singleton | `ISingleton<TThis>`, `SingletonBase<TThis>` |
| Adapter | `IAdapter<TSource, TResult>` |
| Bridge | `IBridge<TImplementation>` |
| Composite | `IComposite`, `CompositeBase` |
| Chain of Responsibility | `IChainOfResponsibility<TResult, TOperation>`, `ChainOfResponsibilityBase<TResult, TOperation>` |
| Command | `ICommand`, `ICommand<TResult>`, `ICommand<TResult, TExecutor>` |
| Strategy | `IStrategy`, `IStrategy<TResult>`, `IStrategy<TResult, TData>` |
| Visitor | `IVisitor`, `IAcceptor`, `IVisitor<TResult>`, `IAcceptor<TResult>` |

Concurrent types live in `DesignPatterns.Concurrent` (and `DesignPatterns.Concurrent.Implementation` for CoR). Same pattern names; async method names (`CreateAsync`, `HandleAsync`, `ExecuteAsync`, …).

## Caveats

- **Abstract Factory:** generic interfaces model **one product role**. A GoF product *family* needs an explicit multi-method interface you define.
- **Singleton:** `GetInstance()` is an **instance** method. `where TThis : new()` does **not** forbid `new TThis()`. Prefer `GetInstance()` as the access point. Do not use Singleton for services the host already manages with DI unless there is a clear reason.
- **Chain of Responsibility:** `AddNextHandler` registers the next link and **returns that next handler**. `RegisterNext` replaces the current successor.
- Do not call members that are not on these types. Confirm against source or the README.

## Failure modes

- Inventing APIs or README sample types (`Company`, `Widget`) as if they shipped in the package.
- Treating this library as a full GoF catalog or as finished pattern implementations.
- Using `SingletonBase` when a scoped/singleton DI registration is enough.
