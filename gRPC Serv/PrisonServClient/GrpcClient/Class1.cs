using Grpc.Net.Client;
using System;

namespace GrpcClient
{
    public class Class1
    {
        public static void NiggaTest()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = PrisonServ
        }
    }
}
