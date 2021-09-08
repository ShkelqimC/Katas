using System;
using KataHelper;

namespace Scheduler.Models
{
    public class Applicant
    {
        public string Name;
        public Action _test;

        public void newApplicant()
        {
            string[] randomNames = Helper.GetRandomNames(14, 123);

        }

        public static int Compare(Applicant a, Applicant b)
        {
            return a.Name.CompareTo(b.Name);
        }
        
    }
}
