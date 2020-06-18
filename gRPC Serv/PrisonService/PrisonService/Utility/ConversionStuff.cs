using PrisonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonService.Utility
{
    public static class ConversionStuff
    {
        public static PrisonerMessage PrisonerToMessage(Prisoner p)
        {
            return new PrisonerMessage
            {
                Id = p.PrisonerID,
                Fname = p.FName,
                Lname = p.LName,
                Age = p.Age,
                LocationId = p.LocationID,
                SentenceDate = p.SentenceDate.Ticks,
                ReleaseDate = p.ReleaseDate.Ticks
            };
        }

        public static Prisoner MessageToPrisoner(PrisonerMessage pm)
        {
            return new Prisoner
            {
                PrisonerID = pm.Id,
                FName = pm.Fname,
                LName = pm.Lname,
                Age = pm.Age,
                LocationID = pm.LocationId,
                SentenceDate = new DateTime(pm.SentenceDate),
                ReleaseDate = new DateTime(pm.ReleaseDate)
            };
        }

        public static LocationMessage LocationToMessage(Location l)
        {
            return new LocationMessage
            {
                Id = l.LocationID,
                Name = l.Name
            };
        }

        public static Location MessageToLocation(LocationMessage lm)
        {
            return new Location
            {
                LocationID = lm.Id,
                Name = lm.Name
            };
        }

        public static WorkerMessage WorkerToMessage(Worker w)
        {
            return new WorkerMessage
            {
                Id = w.WorkerID,
                Fname = w.FName,
                Lname = w.LName,
                LocationId = w.LocationID,
                JobId = w.JobID
            };
        }

        public static Worker MessageToWorker(WorkerMessage wm)
        {
            return new Worker
            {
                WorkerID = wm.Id,
                FName = wm.Fname,
                LName = wm.Lname,
                LocationID = wm.LocationId,
                JobID = wm.JobId
            };
        }

        public static JobMessage JobToMessage(Job j)
        {
            return new JobMessage
            {
                Id = j.JobID,
                Title = j.Title
            };
        }

        public static Job MessageToJob(JobMessage jm)
        {
            return new Job
            {
                JobID = jm.Id,
                Title = jm.Title,
            };
        }
    }
}
