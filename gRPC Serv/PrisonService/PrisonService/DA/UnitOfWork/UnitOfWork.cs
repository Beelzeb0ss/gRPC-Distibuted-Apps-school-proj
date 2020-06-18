using PrisonService.DA.Context;
using PrisonService.DA.Repos;
using PrisonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonService.DA.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private PrisonDbContext context;
        private GenericRepo<Models.Prisoner> prisonerRepo;
        private GenericRepo<Location> locationRepo;
        private GenericRepo<Worker> workerRepo;
        private GenericRepo<Job> jobRepo;

        public GenericRepo<Models.Prisoner> PrisonerRepo
        {
            get
            {
                if(prisonerRepo == null)
                {
                    prisonerRepo = new GenericRepo<Models.Prisoner>(context);
                }
                return prisonerRepo;
            }
        }

        public GenericRepo<Location> LocationRepo
        {
            get
            {
                if(locationRepo == null)
                {
                    locationRepo = new GenericRepo<Location>(context);
                }
                return locationRepo;
            }
        }

        public GenericRepo<Worker> WorkerRepo
        {
            get
            {
                if(workerRepo == null)
                {
                    workerRepo = new GenericRepo<Worker>(context);
                }
                return workerRepo;
            }
        }

        public GenericRepo<Job> JobRepo
        {
            get
            {
                if(jobRepo == null)
                {
                    jobRepo = new GenericRepo<Job>(context);
                }
                return jobRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UnitOfWork(PrisonDbContext context)
        {
            this.context = context;
        }
    }
}
