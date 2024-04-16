using Microsoft.Extensions.DependencyInjection;
using Soenneker.Blob.Copy.Registrars;
using Soenneker.Blob.Delete.Registrars;
using Soenneker.Blob.Download.Registrars;
using Soenneker.Blob.Service.Registrars;
using Soenneker.Blob.Upload.Registrars;

namespace Soenneker.Blob.Suite.Registrars;

/// <summary>
/// A concoction of Azure Blob Storage utilities and libraries
/// </summary>
public static class BlobSuiteRegistrar
{
    public static void AddBlobSuiteAsSingleton(this IServiceCollection services)
    {
        services.AddBlobCopyAsSingleton();
        services.AddBlobDeleteUtilAsScoped();
        services.AddBlobDownloadUtil();
        services.AddBlobServiceUtilAsSingleton();
        services.AddBlobUploadUtilAsSingleton();
    }

    public static void AddBlobSuiteAsScoped(this IServiceCollection services)
    {
        services.AddBlobDownloadUtil();
        services.AddBlobDeleteUtilAsScoped();
        services.AddBlobCopyAsScoped();
        services.AddBlobServiceUtilAsScoped();
        services.AddBlobUploadUtilAsScoped();
    }
}