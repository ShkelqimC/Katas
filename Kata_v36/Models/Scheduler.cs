using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KataHelper;

namespace Scheduler.Models
{
    public class Scheduler
    {
        public List<Applicant> UnassignedApplicants;
        public List<CaseWorker> CaseWorkers;

        public Scheduler()
        {
            UnassignedApplicants = new List<Applicant>();
            CaseWorkers = new List<CaseWorker>();

            string[] randomNames = Helper.GetRandomNames(14, 123);

            for (int i = 0; i < 10; i++)
            {
                Applicant applicant = new Applicant();
                applicant.Name = randomNames[i];
                UnassignedApplicants.Add(applicant);
            }

            for (int i = 0; i < 4; i++)
            {
                CaseWorker caseWorker = new CaseWorker();
                caseWorker.Name = randomNames[10 + i];
                CaseWorkers.Add(caseWorker);
            }
            UnassignedApplicants.Sort(Applicant.Compare);
        }


        public void RandomlyFillUpMeetings()
        {
            Random rnd = new Random();

            while (UnassignedApplicants.Count != 0)
            {
                int randomIndex = rnd.Next(0, UnassignedApplicants.Count);
                int randomCaseWorker = rnd.Next(0, CaseWorkers.Count);
                CaseWorker caseworker = CaseWorkers[randomCaseWorker];
                
                foreach (var meeting in caseworker.Meetings)
                {
                    if (meeting.Applicant==null)
                    {
                        meeting.Applicant = UnassignedApplicants[randomIndex];
                        UnassignedApplicants.RemoveAt(randomIndex);
                        break;
                    }
                }

            }

        }
    }
}
