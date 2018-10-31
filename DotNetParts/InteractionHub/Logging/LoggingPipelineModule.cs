using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Linq;

namespace InteractionHub.Logging
{
    
    public class LoggingPipelineModule
        : HubPipelineModule
    {

        protected override bool OnBeforeAuthorizeConnect(HubDescriptor hubDescriptor, IRequest request)
        {
            Console.WriteLine("*** Authorize: " + request.Url.PathAndQuery.PadRight(150));
            return base.OnBeforeAuthorizeConnect(hubDescriptor, request);
        }

        protected override bool OnBeforeConnect(IHub hub)
        {
            Console.WriteLine("*** Connect: " + hub.GetType().ToString().PadRight(150));
            return base.OnBeforeConnect(hub);
        }

        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            var parameters = context.MethodDescriptor.Parameters
                .Select(p => p.Name + "=" + context.Args[context.MethodDescriptor.Parameters.IndexOf(p)].ToString());
            Console.WriteLine(string.Format("*** Incoming: {0:HH:mm:ss.fff} {1}({2})",
                DateTime.Now,
                context.MethodDescriptor.Name,
                string.Join(", ", parameters)
                ));
            //
            return base.OnBeforeIncoming(context);
        }
    }
}