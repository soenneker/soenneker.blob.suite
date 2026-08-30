using Microsoft.Extensions.DependencyInjection;
using Soenneker.Blob.Copy.Registrars;
using Soenneker.Blob.Delete.Registrars;
using Soenneker.Blob.Download.Registrars;
using Soenneker.Blob.Service.Registrars;
using Soenneker.Blob.Upload.Registrars;

namespace Soenneker.Blob.Suite.Registrars;

/// <summary>
/// Registers the Blob copy, delete, download, service, and upload utilities together.
/// </summary>
public static class BlobSuiteRegistrar
{
    /// <summary>
    /// Registers Blob Suite with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
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
    /// Registers Blob Suite with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
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
