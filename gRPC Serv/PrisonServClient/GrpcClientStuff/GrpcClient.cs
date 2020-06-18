using Grpc.Core;
using Grpc.Net.Client;
using PrisonService;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GrpcClientStuff
{
    public class GrpcClient:IDisposable
    {
        GrpcChannel channel;
        private PrisonSrv.PrisonSrvClient client;
        public string token = "";
        private string address;
        private Metadata headers;

        static void Main(string[] args)
        {

        }

        public GrpcClient(string address)
        {
            this.address = address;
            headers = new Metadata();
        }

        public async Task Start()
        {
            channel = GrpcChannel.ForAddress(address);
            client = new PrisonSrv.PrisonSrvClient(channel);
            await GetAccessToken();
            headers.Add("Authorization", $"Bearer {token}");
        }

        public void Dispose()
        {
            channel.Dispose();
        }

        private async Task GetAccessToken()
        {
            if(client == null) 
            {
                return; 
            }

            AccessReplyMessage reply = null;
            try
            {
                reply = await client.AccessRequestAsync(new AccessReqMessage { Name = "1", Pass = "1" });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            if (reply == null)
            {
                return;
            }

            token = reply.Token;
        }

        public async Task<PrisonerArrayMessage> GetAllPrisoners()
        {
            if(client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            PrisonerArrayMessage reply = null;
            try
            {
                reply = await client.GetAllPrisonersAsync(new Google.Protobuf.WellKnownTypes.Empty(), headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task<PrisonerArrayMessage> GetPrisonersByName(SearchParamMessage para)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            PrisonerArrayMessage reply = null;
            try
            {
                reply = await client.GetPrisonersByNameAsync(para, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task AddPrisoner(PrisonerMessage prisonerMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }
            try
            {
                await client.AddPrisonerAsync(prisonerMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public async Task UpdatePrisoner(PrisonerMessage prisonerMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.UpdatePrisonerAsync(prisonerMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task DeletePrisoner(IdMessage idMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.DeletePrisonerByIDAsync(idMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task<LocationArrayMessage> GetAllLocations()
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            LocationArrayMessage reply = null;
            try
            {
                reply = await client.GetAllLocationsAsync(new Google.Protobuf.WellKnownTypes.Empty(), headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task<LocationArrayMessage> GetLocationsByName(SearchParamMessage para)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            LocationArrayMessage reply = null;
            try
            {
                reply = await client.GetLocationsByNameAsync(para, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task AddLocation(LocationMessage locationMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.AddLocationAsync(locationMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task UpdateLocation(LocationMessage locationMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.UpdateLocationAsync(locationMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task DeleteLocation(IdMessage idMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.DeleteLocationByIDAsync(idMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task<JobArrayMessage> GetAllJobs()
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            JobArrayMessage reply = null;
            try
            {
                reply = await client.GetAllJobsAsync(new Google.Protobuf.WellKnownTypes.Empty(), headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task<JobArrayMessage> GetJobsByName(SearchParamMessage para)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            JobArrayMessage reply = null;
            try
            {
                reply = await client.GetJobsByNameAsync(para, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task AddJob(JobMessage jobMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.AddJobAsync(jobMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task UpdateJob(JobMessage jobMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.UpdateJobAsync(jobMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task DeleteJob(IdMessage idMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.DeleteJobByIDAsync(idMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task<WorkerArrayMessage> GetAllWorkers()
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            WorkerArrayMessage reply = null;
            try
            {
                reply = await client.GetAllWorkersAsync(new Google.Protobuf.WellKnownTypes.Empty(), headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task<WorkerArrayMessage> GetWorkersByName(SearchParamMessage para)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return null;
            }

            WorkerArrayMessage reply = null;
            try
            {
                reply = await client.GetWorkersByNameAsync(para, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return reply;
        }

        public async Task AddWorker(WorkerMessage workerMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.AddWorkerAsync(workerMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task UpdateWorker(WorkerMessage workerMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.UpdateWorkerAsync(workerMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task DeleteWorker(IdMessage idMessage)
        {
            if (client == null || token == "")
            {
                Debug.WriteLine("Null client or token");
                return;
            }

            try
            {
                await client.DeleteWorkerByIDAsync(idMessage, headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
