using Grpc.Core;
using GrpcWPF_Client_Server;

namespace GrpcWPF_Client_Server.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = $"{DateTime.UtcNow.ToShortTimeString()} || Server :  " + request.Name
            });
        }
    }
}
