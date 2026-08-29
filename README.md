[![](https://img.shields.io/nuget/v/Soenneker.Blob.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.suite/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.suite/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.suite/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.suite/actions/workflows/codeql.yml)

# Soenneker.Blob.Suite

A concoction of Azure Blob Storage utilities and libraries.

## Install

```bash
dotnet add package Soenneker.Blob.Suite
```

## Quick start

```csharp
using Soenneker.Blob.Suite.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddBlobSuiteAsSingleton();
```

Registers Blob Suite with a singleton lifetime.

## What you get

- `BlobSuiteRegistrar` — A concoction of Azure Blob Storage utilities and libraries.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `BlobSuiteRegistrar.AddBlobSuiteAsSingleton(services)` | Registers Blob Suite with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `BlobSuiteRegistrar.AddBlobSuiteAsScoped(services)` | Registers Blob Suite with a scoped lifetime. | The same service collection, so additional registrations can be chained. |
