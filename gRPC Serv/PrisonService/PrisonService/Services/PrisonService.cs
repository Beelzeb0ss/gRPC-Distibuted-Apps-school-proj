using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PrisonService.DA.Context;
using PrisonService.DA.UnitOfWork;
using PrisonService.Models;
using PrisonService.Utility;

namespace PrisonService
{
    [Authorize]
    public class PrisonService : PrisonSrv.PrisonSrvBase
    {
        private readonly ILogger<GreeterService> logger;
        private IConfiguration config;

        private UnitOfWork unitOfWork;

        public PrisonService(ILogger<GreeterService> logger, IConfiguration config, PrisonDbContext dbContext)
        {
            this.logger = logger;
            this.config = config;

            unitOfWork = new UnitOfWork(dbContext);
        }

        [AllowAnonymous]
        public override Task<AccessReplyMessage> AccessRequest(AccessReqMessage request, ServerCallContext context)
        {
            string token = "";
            if (request.Name == "1" && request.Pass == "1")
            {
                token = SecUtility.GenerateJWT(request, config);
            }

            return Task.FromResult(new AccessReplyMessage { Token = token });
        }

        #region Prisoner CRUD
        public override Task<PrisonerArrayMessage> GetAllPrisoners(Empty e, ServerCallContext callContext)
        {
            PrisonerArrayMessage pam = new PrisonerArrayMessage();
            List<Prisoner> pList = unitOfWork.PrisonerRepo.Get(p => true, null, "Location").ToList();
            List<PrisonerMessage> pmList = new List<PrisonerMessage>();
            foreach(Prisoner p in pList)
            {
                Console.WriteLine(p.Location.Name);
                pmList.Add(ConversionStuff.PrisonerToMessage(p));
            }
            pam.Prisoners.AddRange(pmList);
            return Task.FromResult(pam);
        }

        public override Task<PrisonerArrayMessage> GetPrisonersByName(SearchParamMessage request, ServerCallContext context)
        {
            PrisonerArrayMessage pam = new PrisonerArrayMessage();
            List<Prisoner> pList = unitOfWork.PrisonerRepo.Get(p => p.LName.ToLower().Contains(request.Value.ToLower()), null, "").ToList();
            List<PrisonerMessage> pmList = new List<PrisonerMessage>();
            foreach (Prisoner p in pList)
            {
                pmList.Add(ConversionStuff.PrisonerToMessage(p));
            }
            pam.Prisoners.AddRange(pmList);
            return Task.FromResult(pam);
        }

        public override Task<PrisonerMessage> GetPrisonerByID(IdMessage request, ServerCallContext context)
        {
            Prisoner p = unitOfWork.PrisonerRepo.GetByID(request.Id);
            return Task.FromResult(ConversionStuff.PrisonerToMessage(p));
        }

        public override Task<Empty> AddPrisoner(PrisonerMessage request, ServerCallContext context)
        {
            Prisoner p = ConversionStuff.MessageToPrisoner(request);
            if (!ValidationUtility.IsPrisonerValid(p)) { return Task.FromResult(new Empty()); }
            unitOfWork.PrisonerRepo.Insert(p);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdatePrisoner(PrisonerMessage request, ServerCallContext context)
        {
            Prisoner p = ConversionStuff.MessageToPrisoner(request);
            if (!ValidationUtility.IsPrisonerValid(p)) { return Task.FromResult(new Empty()); }
            unitOfWork.PrisonerRepo.Update(p);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeletePrisonerByID(IdMessage request, ServerCallContext context)
        {
            unitOfWork.PrisonerRepo.Delete(request.Id);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }
        #endregion

        #region Location CRUD
        public override Task<LocationArrayMessage> GetAllLocations(Empty request, ServerCallContext context)
        {
            LocationArrayMessage lam = new LocationArrayMessage();
            List<Location> locationList = unitOfWork.LocationRepo.Get(l => true).ToList();
            List<LocationMessage> lmList = new List<LocationMessage>();
            foreach(Location l in locationList) 
            {
                lmList.Add(ConversionStuff.LocationToMessage(l));
            }
            lam.Locations.AddRange(lmList);
            return Task.FromResult(lam);
        }

        public override Task<LocationArrayMessage> GetLocationsByName(SearchParamMessage request, ServerCallContext context)
        {
            LocationArrayMessage lam = new LocationArrayMessage();
            List<Location> locationList = unitOfWork.LocationRepo.Get(l => l.Name.ToLower().Contains(request.Value.ToLower())).ToList();
            List<LocationMessage> lmList = new List<LocationMessage>();
            foreach (Location l in locationList)
            {
                lmList.Add(ConversionStuff.LocationToMessage(l));
            }
            lam.Locations.AddRange(lmList);
            return Task.FromResult(lam);
        }

        public override Task<LocationMessage> GetLocationByID(IdMessage request, ServerCallContext context)
        {
            return Task.FromResult(ConversionStuff.LocationToMessage(unitOfWork.LocationRepo.GetByID(request.Id)));
        }

        public override Task<Empty> AddLocation(LocationMessage request, ServerCallContext context)
        {
            Location l = ConversionStuff.MessageToLocation(request);
            if (!ValidationUtility.IsLocationValid(l)) { return Task.FromResult(new Empty()); }
            unitOfWork.LocationRepo.Insert(l);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateLocation(LocationMessage request, ServerCallContext context)
        {
            Location l = ConversionStuff.MessageToLocation(request);
            if (!ValidationUtility.IsLocationValid(l)) { return Task.FromResult(new Empty()); }
            unitOfWork.LocationRepo.Update(l);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteLocationByID(IdMessage request, ServerCallContext context)
        {
            unitOfWork.LocationRepo.Delete(request.Id);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }
        #endregion

        #region Worker CRUD
        public override Task<WorkerArrayMessage> GetAllWorkers(Empty request, ServerCallContext context)
        {
            WorkerArrayMessage wam = new WorkerArrayMessage();
            List<Worker> wList = unitOfWork.WorkerRepo.Get(w => true).ToList();
            List<WorkerMessage> wmList = new List<WorkerMessage>();
            foreach(Worker w in wList)
            {
                wmList.Add(ConversionStuff.WorkerToMessage(w));
            }
            wam.Workers.AddRange(wmList);
            return Task.FromResult(wam);
        }

        public override Task<WorkerArrayMessage> GetWorkersByName(SearchParamMessage request, ServerCallContext context)
        {
            WorkerArrayMessage wam = new WorkerArrayMessage();
            List<Worker> wList = unitOfWork.WorkerRepo.Get(w => w.LName.ToLower().Contains(request.Value.ToLower())).ToList();
            List<WorkerMessage> wmList = new List<WorkerMessage>();
            foreach (Worker w in wList)
            {
                wmList.Add(ConversionStuff.WorkerToMessage(w));
            }
            wam.Workers.AddRange(wmList);
            return Task.FromResult(wam);
        }

        public override Task<WorkerMessage> GetWorkerByID(IdMessage request, ServerCallContext context)
        {
            return Task.FromResult(ConversionStuff.WorkerToMessage(unitOfWork.WorkerRepo.GetByID(request.Id)));
        }

        public override Task<Empty> AddWorker(WorkerMessage request, ServerCallContext context)
        {
            Worker w = ConversionStuff.MessageToWorker(request);
            if (!ValidationUtility.IsWorkerValid(w)) { return Task.FromResult(new Empty()); }
            unitOfWork.WorkerRepo.Insert(w);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateWorker(WorkerMessage request, ServerCallContext context)
        {
            Worker w = ConversionStuff.MessageToWorker(request);
            if (!ValidationUtility.IsWorkerValid(w)) { return Task.FromResult(new Empty()); }
            unitOfWork.WorkerRepo.Update(w);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteWorkerByID(IdMessage request, ServerCallContext context)
        {
            unitOfWork.WorkerRepo.Delete(request.Id);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }
        #endregion

        #region Job CRUD
        public override Task<JobArrayMessage> GetAllJobs(Empty request, ServerCallContext context)
        {
            JobArrayMessage jam = new JobArrayMessage();
            List<Job> jList = unitOfWork.JobRepo.Get(j => true).ToList();
            List<JobMessage> jmList = new List<JobMessage>();
            foreach(Job j in jList)
            {
                jmList.Add(ConversionStuff.JobToMessage(j));
            }
            jam.Jobs.AddRange(jmList);
            return Task.FromResult(jam);
        }

        public override Task<JobArrayMessage> GetJobsByName(SearchParamMessage request, ServerCallContext context)
        {
            JobArrayMessage jam = new JobArrayMessage();
            List<Job> jList = unitOfWork.JobRepo.Get(j => j.Title.ToLower().Contains(request.Value.ToLower())).ToList();
            List<JobMessage> jmList = new List<JobMessage>();
            foreach (Job j in jList)
            {
                jmList.Add(ConversionStuff.JobToMessage(j));
            }
            jam.Jobs.AddRange(jmList);
            return Task.FromResult(jam);
        }

        public override Task<JobMessage> GetJobByID(IdMessage request, ServerCallContext context)
        {
            return Task.FromResult(ConversionStuff.JobToMessage(unitOfWork.JobRepo.GetByID(request.Id)));
        }

        public override Task<Empty> AddJob(JobMessage request, ServerCallContext context)
        {
            Job j = ConversionStuff.MessageToJob(request);
            if (!ValidationUtility.IsJobValid(j)) { return Task.FromResult(new Empty()); }
            unitOfWork.JobRepo.Insert(j);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateJob(JobMessage request, ServerCallContext context)
        {
            Job j = ConversionStuff.MessageToJob(request);
            if (!ValidationUtility.IsJobValid(j)) { return Task.FromResult(new Empty()); }
            unitOfWork.JobRepo.Update(j);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteJobByID(IdMessage request, ServerCallContext context)
        {
            unitOfWork.JobRepo.Delete(request.Id);
            unitOfWork.Save();
            return Task.FromResult(new Empty());
        }
        #endregion
    }
}
