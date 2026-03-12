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
    public static IServiceCollection AddBlobSuiteAsSingleton(this IServiceCollection services)
    {
        services.AddBlobCopyAsSingleton()
                .AddBlobDeleteUtilAsSingleton()
                .AddBlobDownloadUtilAsSingleton()
                .AddBlobServiceUtilAsSingleton()
                .AddBlobUploadUtilAsSingleton();

        return services;
    }

    public static IServiceCollection AddBlobSuiteAsScoped(this IServiceCollection services)
    {
        services.AddBlobDownloadUtilAsScoped()
                .AddBlobDeleteUtilAsScoped()
                .AddBlobCopyAsScoped()
                .AddBlobServiceUtilAsScoped()
                .AddBlobUploadUtilAsScoped();

        return services;
    }
}