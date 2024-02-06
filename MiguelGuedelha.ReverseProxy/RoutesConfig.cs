using Yarp.ReverseProxy.Configuration;

namespace MiguelGuedelha.ReverseProxy;

public static class RoutesConfig
{
    //Hostnames
    private const string BaseDomain = "miguelguedelha.com";
    private const string FrontendHostname = $"www.{BaseDomain}";
    private const string BackendHostname = $"siteapi.{BaseDomain}";
    private const string DashboardsHostname = $"dashboards.{BaseDomain}";
    private const string SleepTokenRuneGeneratorHostname = $"runegen.{BaseDomain}";

    //Routes
    private static readonly RouteConfig PersonalSiteFrontendRoute = new()
    {
        RouteId = nameof(PersonalSiteFrontendRoute),
        ClusterId = ClustersConfig.PersonalSiteFrontendId,
        Match = new()
        {
            Path = "{**catch-all}",
            Hosts = new []{ FrontendHostname }
        },
    };
    
    private static readonly RouteConfig PersonalSiteFrontendSitemapRoute = new()
    {
        RouteId = nameof(PersonalSiteFrontendSitemapRoute),
        ClusterId = ClustersConfig.PersonalSiteBackendId,
        Match = new()
        {
            Path = "/sitemap.xml",
            Hosts = new []{ FrontendHostname }
        }
    };
    
    private static readonly RouteConfig PersonalSiteBackendRoute = new()
    {
        RouteId = nameof(PersonalSiteBackendRoute),
        ClusterId = ClustersConfig.PersonalSiteBackendId,
        Match = new()
        {
            Path = "{**catch-all}",
            Hosts = new []{ BackendHostname }
        },
    };
    
    private static readonly RouteConfig PersonalSiteBackendRobotsRoute = new()
    {
        RouteId = nameof(PersonalSiteBackendRobotsRoute),
        ClusterId = ClustersConfig.SelfId,
        Match = new()
        {
            Path = "/robots.txt",
            Hosts = new []{ BackendHostname }
        },
    };

    private static readonly RouteConfig RedisCommanderRoute = new()
    {
        RouteId = nameof(RedisCommanderRoute),
        ClusterId = ClustersConfig.RedisCommanderId,
        Match = new()
        {
            Path = "redis-ui",
            Hosts = new []{ DashboardsHostname },
        }
    };
    
    private static readonly RouteConfig SleepTokenRuneGeneratorRoute = new()
    {
        RouteId = nameof(SleepTokenRuneGeneratorRoute),
        ClusterId = ClustersConfig.SleepTokenRuneGeneratorId,
        Match = new()
        {
            Path = "{**catch-all}",
            Hosts = new []{ SleepTokenRuneGeneratorHostname }
        }
    };
    
    public static readonly List<RouteConfig> Routes = new()
    {
        PersonalSiteFrontendSitemapRoute,
        PersonalSiteFrontendRoute,
        PersonalSiteBackendRoute,
        PersonalSiteBackendRobotsRoute,
        RedisCommanderRoute,
        SleepTokenRuneGeneratorRoute
    };
    
    
}