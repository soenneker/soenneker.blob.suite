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
    /// Adds all of the Azure Blob utilities as singletons. Use <see cref="AddBlobSuiteAsScoped"/> if you can.. it adds the utilities as scoped if possible.
    /// </summary>
    public static void AddBlobSuiteAsSingleton(this IServiceCollection services)
    {
        services.AddBlobCopyAsSingleton();
        services.AddBlobDeleteUtilAsSingleton();
        services.AddBlobDownloadUtil();
        services.AddBlobServiceUtilAsSingleton();
        services.AddBlobUploadUtilAsSingleton();
    }

    /// <summary>
    /// Adds all of the Azure Blob utilities as scoped unless they have clients that cache. <para/>
    /// See <see cref="AddBlobSuiteAsSingleton"/> for adding them all as singletons, but you should use this one if you can.
    /// </summary>
    public static void AddBlobSuiteAsScoped(this IServiceCollection services)
    {
        services.AddBlobDownloadUtil();
        services.AddBlobDeleteUtilAsScoped();
        services.AddBlobCopyAsScoped();
        services.AddBlobServiceUtilAsScoped();
        services.AddBlobUploadUtilAsScoped();
    }
}