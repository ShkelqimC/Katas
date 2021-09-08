namespace Scheduler.Models
{
    public class Applicant
    {
        public string Name;

        public static int Compare(Applicant a, Applicant b)
        {
            return a.Name.CompareTo(b.Name);
        }
        
    }
}
