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
    /// <summary>
    /// Adds blob suite as singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddBlobSuiteAsSingleton(this IServiceCollection services)
    {
        services.AddBlobCopyAsSingleton()
                .AddBlobDeleteUtilAsSingleton()
                .AddBlobDownloadUtilAsSingleton()
                .AddBlobServiceUtilAsSingleton()
                .AddBlobUploadUtilAsSingleton();

        return services;
    }

    /// <summary>
    /// Adds blob suite as scoped.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
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