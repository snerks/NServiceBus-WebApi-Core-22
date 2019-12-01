using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

public class ReceiveMessageController : Controller
{
    IMessageSession messageSession;

    public ReceiveMessageController(IMessageSession messageSession)
    {
        this.messageSession = messageSession;
    }

    [HttpGet]
    public async Task<string> Get(MyMessage myMessage)
    {
        //var message = new MyMessage();

        //await 
        //    messageSession
        //    .Send(message)
        //    .ConfigureAwait(false);

        return $"Message received at ReceiveMessageController : {myMessage?.GetType().Name}";
    }
}
