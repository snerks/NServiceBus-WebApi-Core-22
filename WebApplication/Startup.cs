using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NServiceBus;
using NServiceBus.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var endpointConfiguration = new EndpointConfiguration("Samples.ASPNETCore.Sender");
        var transport = endpointConfiguration.UseTransport<LearningTransport>();
        //endpointConfiguration.SendOnly();

        var routing = transport.Routing();
        routing.RouteToEndpoint(
            assembly: typeof(MyMessage).Assembly,
            //destination: "Samples.ASPNETCore.Endpoint");
            destination: "Samples.ASPNETCore.Sender");

        services.AddNServiceBus(endpointConfiguration);

        services.AddMvc();
        services.AddLogging(loggingBuilder => loggingBuilder.AddDebug());
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc(routeBuilder => routeBuilder.MapRoute(name: "default",
            template: "{controller=SendMessage}/{action=Get}"));
    }
}