[![](https://img.shields.io/nuget/v/Soenneker.Blob.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.suite/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.suite/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.suite/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.suite/actions/workflows/codeql.yml)

# Soenneker.Blob.Suite

Installs and registers the Soenneker utilities for copying, deleting, downloading, uploading, and accessing Azure Blob Storage.

## Installation

```bash
dotnet add package Soenneker.Blob.Suite
```

Install the individual packages instead when an application needs only part of the suite.

## Configuration

```json
{
  "Environment": "Production",
  "Azure": {
    "Storage": {
      "Blob": {
        "ConnectionString": "<connection string>",
        "AccountName": "<storage account name>",
        "AccountKey": "<storage account key>"
      }
    }
  }
}
```

The connection string is used for normal Blob operations. The account name, account key, and environment are required by the SAS utility registered through the upload package.

## Registration

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Blob.Suite.Registrars;

services.AddBlobSuiteAsSingleton();
```

Use `AddBlobSuiteAsScoped()` when the utilities should follow the consuming dependency-injection scope.

## Registered utilities

| Interface | Purpose |
| --- | --- |
| `IBlobCopyUtil` | Copies blobs within or between containers |
| `IBlobDeleteUtil` | Deletes individual blobs or a virtual directory prefix |
| `IBlobDownloadUtil` | Downloads blobs to temporary files, memory, or text |
| `IBlobServiceUtil` | Provides the underlying Azure `BlobServiceClient` |
| `IBlobUploadUtil` | Uploads files, streams, bytes, or text |
| `IBlobSasUtil` | Creates signed read URLs; registered as an upload dependency |

`Soenneker.Blob.Fetch` is not included. Add that package separately when blob metadata listing is needed.

## Usage

Inject only the utility needed by each consumer:

```csharp
using Soenneker.Blob.Download.Abstract;
using Soenneker.Blob.Upload.Abstract;

public sealed class AssetStore
{
    private readonly IBlobUploadUtil _uploads;
    private readonly IBlobDownloadUtil _downloads;

    public AssetStore(IBlobUploadUtil uploads, IBlobDownloadUtil downloads)
    {
        _uploads = uploads;
        _downloads = downloads;
    }

    public async ValueTask UploadManifest(
        string json,
        CancellationToken cancellationToken)
    {
        _ = await _uploads.Upload(
            "assets",
            "manifest.json",
            json,
            contentType: "application/json",
            cancellationToken: cancellationToken);
    }

    public ValueTask<string> DownloadManifest(CancellationToken cancellationToken)
    {
        return _downloads.DownloadToString(
            "assets",
            "manifest.json",
            cancellationToken: cancellationToken);
    }
}
```

The upload method returns Azure's `Response<BlobContentInfo>` when the caller needs the service response. See each component package for operation-specific ownership, buffering, and error behavior.
