using PrisonService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonServClient.Models.Utility
{
    class ConversionStuff
    {
        public static PrisonerMessage PrisonerToMessage(Prisoner p)
        {
            return new PrisonerMessage
            {
                Id = p.Id,
                Fname = p.FName,
                Lname = p.LName,
                Age = p.Age,
                LocationId = p.LocationId,
                SentenceDate = p.SentencedOn.Ticks,
                ReleaseDate = p.ReleaseDate.Ticks
            };
        }

        public static Prisoner MessageToPrisoner(PrisonerMessage pm)
        {
            return new Prisoner
            {
                Id = pm.Id,
                FName = pm.Fname,
                LName = pm.Lname,
                Age = pm.Age,
                LocationId = pm.LocationId,
                SentencedOn = new DateTime(pm.SentenceDate),
                ReleaseDate = new DateTime(pm.ReleaseDate)
            };
        }

        public static LocationMessage LocationToMessage(Location l)
        {
            return new LocationMessage
            {
                Id = l.Id,
                Name = l.Name
            };
        }

        public static Location MessageToLocation(LocationMessage lm)
        {
            return new Location
            {
                Id = lm.Id,
                Name = lm.Name
            };
        }

        public static WorkerMessage WorkerToMessage(Worker w)
        {
            return new WorkerMessage
            {
                Id = w.Id,
                Fname = w.FName,
                Lname = w.LName,
                LocationId = w.LocationId,
                JobId = w.Job.Id
            };
        }

        public static Worker MessageToWorker(WorkerMessage wm)
        {
            return new Worker
            {
                Id = wm.Id,
                FName = wm.Fname,
                LName = wm.Lname,
                LocationId = wm.LocationId,
                JobId = wm.JobId
            };
        }

        public static JobMessage JobToMessage(Job j)
        {
            return new JobMessage
            {
                Id = j.Id,
                Title = j.Title
            };
        }

        public static Job MessageToJob(JobMessage jm)
        {
            return new Job
            {
                Id = jm.Id,
                Title = jm.Title,
            };
        }
    }
}
