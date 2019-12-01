using System.Net.Http;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class MyWebHostedHandler : IHandleMessages<MyMessage>
{
    static ILog log = LogManager.GetLogger<MyWebHostedHandler>();

    public async Task Handle(MyMessage message, IMessageHandlerContext context)
    {
        log.Info("Message received at endpoint : [MyWebHostedHandler]");

        var client = new HttpClient();
        var path = "http://localhost:58117/receivemessage";

        HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            log.Info($"responseMessage received from Web API : [receivemessage] : [{responseMessage}]");
        }

        //return Task.CompletedTask;
    }
}
