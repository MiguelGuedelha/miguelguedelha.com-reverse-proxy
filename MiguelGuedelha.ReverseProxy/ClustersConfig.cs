using Yarp.ReverseProxy.Configuration;

namespace MiguelGuedelha.ReverseProxy;

public static class ClustersConfig
{
    private static readonly bool IsDev = string.Equals(
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), 
        "Development", 
        StringComparison.InvariantCultureIgnoreCase);

    //Addresses
    private const string PersonalSiteFrontendAddress = "http://miguelguedelha-com-app";
    private const string PersonalSiteBackendAddress = "http://miguelguedelha-com-api:8080";
    private const string SleepTokenRuneGeneratorAddress = "http://sleep-token-rune-gen";
    private const string RedisCommanderAddress = "http://redis-commander:8081";
    private static readonly string SelfAddress = $"http://127.0.0.1:{(IsDev ? 5280 : 8080)}";

    //Clusters
    public const string PersonalSiteFrontendId = "personal-site-frontend";
    private static readonly ClusterConfig PersonalSiteFrontendCluster = new()
    {
        ClusterId = PersonalSiteFrontendId,
        Destinations = new Dictionary<string, DestinationConfig>
        {
            { "frontend1", new(){ Address = PersonalSiteFrontendAddress } }
        }
    };
    
    public const string PersonalSiteBackendId = "personal-site-backend";
    private static readonly ClusterConfig PersonalSiteBackendCluster = new()
    {
        ClusterId = PersonalSiteBackendId,
        Destinations = new Dictionary<string, DestinationConfig>
        {
            { "backend1", new(){ Address = PersonalSiteBackendAddress } }
        }
    };
    
    public const string SleepTokenRuneGeneratorId = "sleep-token-rune-generator";
    private static readonly ClusterConfig SleepTokenRuneGeneratorCluster = new()
    {
        ClusterId = SleepTokenRuneGeneratorId,
        Destinations = new Dictionary<string, DestinationConfig>
        {
            { "sleep-token-rune-generator1", new(){ Address = SleepTokenRuneGeneratorAddress } }
        }
    };
    
    public const string RedisCommanderId = "redis-commander";
    private static readonly ClusterConfig RedisCommanderCluster = new()
    {
        ClusterId = RedisCommanderId,
        Destinations = new Dictionary<string, DestinationConfig>
        {
            { "redis-commander1", new(){ Address = RedisCommanderAddress } }
        }
    };
    
    public const string SelfId = "self";
    private static readonly ClusterConfig SelfCluster = new()
    {
        ClusterId = SelfId,
        Destinations = new Dictionary<string, DestinationConfig>
        {
            { "self1", new(){ Address = SelfAddress } }
        }
    };
    
    public static readonly List<ClusterConfig> Clusters = new()
    {
        PersonalSiteFrontendCluster,
        PersonalSiteBackendCluster,
        SleepTokenRuneGeneratorCluster,
        RedisCommanderCluster,
        SelfCluster
    };
}