using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

public class SendMessageController : Controller
{
    IMessageSession messageSession;

    public SendMessageController(IMessageSession messageSession)
    {
        this.messageSession = messageSession;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        var message = new MyMessage();

        await 
            messageSession
            .Send(message)
            .ConfigureAwait(false);

        return "Message sent to endpoint";
    }
}
