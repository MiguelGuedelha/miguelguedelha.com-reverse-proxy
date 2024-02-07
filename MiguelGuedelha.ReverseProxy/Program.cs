using LettuceEncrypt;
using MiguelGuedelha.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromMemory(RoutesConfig.Routes, ClustersConfig.Clusters);

if (builder.Environment.IsProduction())
{
    builder.Services
        .AddLettuceEncrypt()
        .PersistDataToDirectory(new("/data/LettuceEncrypt"), string.Empty);
}

var app = builder.Build();

app.UseStaticFiles();

app.MapReverseProxy();

app.Run();
