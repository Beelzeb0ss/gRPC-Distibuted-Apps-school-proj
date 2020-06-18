using Grpc.Core;
using Grpc.Net.Client;
using PrisonService;
using System;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new PrisonSrv.PrisonSrvClient(channel);
            var reply = client.AccessRequest(new AccessReqMessage { Name = "1", Pass = "1" });
            Console.WriteLine("Reply: " + reply.Token);

            var headers = new Metadata();
            headers.Add("Authorization", $"Bearer {reply.Token}");

            var reply2 = client.GetAllJobs(new Google.Protobuf.WellKnownTypes.Empty(), headers);
            Console.WriteLine("Reply2: " + reply2.Jobs.Count);
        }
    }
}
