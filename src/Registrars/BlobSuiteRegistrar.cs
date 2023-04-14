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
    /// Adds all of the Azure Cosmos utilities needed for use <para/>
    /// </summary>
    /// <param name="services"></param>
    public static void AddBlobSuite(this IServiceCollection services)
    {
        services.AddBlobDownloadUtil();
        services.AddBlobUploadUtilAsSingleton();
        services.AddBlobCopyAsSingleton();
        services.AddBlobDeleteUtilAsSingleton();
        services.AddBlobServiceUtilAsSingleton();
    }
}