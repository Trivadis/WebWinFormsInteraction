using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Shared;

namespace InteractionHub.Hubs
{
    [HubName("InteractionHub")]
    public class InteractionHub : Hub
    {
        public void DispatchAction(HubAction action)
        {
            // Broadcast incoming action to all OTHER clients
            Clients.Others.ActionRequested(action);
        }
    }
}
