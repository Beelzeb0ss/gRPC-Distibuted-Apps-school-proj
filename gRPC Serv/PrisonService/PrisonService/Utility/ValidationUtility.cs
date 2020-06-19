using Microsoft.AspNetCore.Razor.TagHelpers;
using PrisonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonService.Utility
{
    public static class ValidationUtility
    {
        public static int maxTextLen = 50;

        public static bool IsJobValid(Job job)
        {
            if (job.Title.Length > maxTextLen)
            {
                return false;
            }
            if (String.IsNullOrEmpty(job.Title))
            {
                return false;
            }
            return true;
        }

        public static bool IsLocationValid(Location loc)
        {
            if(loc.Name.Length > maxTextLen)
            {
                return false;
            }
            if (String.IsNullOrEmpty(loc.Name))
            {
                return false;
            }
            return true;
        }

        public static bool IsPrisonerValid(Prisoner p)
        {
            if(p.FName.Length > maxTextLen || p.LName.Length > maxTextLen)
            {
                return false;
            }
            if(String.IsNullOrEmpty(p.FName) || String.IsNullOrEmpty(p.LName) || p.ReleaseDate == null || p.SentenceDate == null)
            {
                return false;
            }
            return true;
        }

        public static bool IsWorkerValid(Worker w)
        {
            if (w.FName.Length > maxTextLen || w.LName.Length > maxTextLen)
            {
                return false;
            }
            if (String.IsNullOrEmpty(w.FName) || String.IsNullOrEmpty(w.LName))
            {
                return false;
            }
            return true;
        }
    }
}
