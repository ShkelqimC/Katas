using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Scheduler.Exceptions;

namespace Scheduler.Models
{
    public class CaseWorker
    {
        public string Name;
        public List<Meeting> Meetings;
        public int CompareMeetings(Meeting a, Meeting b)
        {
            return a.Start.CompareTo(b.Start);
        }

        public CaseWorker()
        {
            Meetings = new List<Meeting>();
            int workHours = 8;
            DateTime startOfWork = DateTime.Today.AddHours(8);
            DateTime endOfWork = startOfWork.AddHours(9);

            for (int i = 0; i < workHours; i++)
            {
                DateTime startOfMeeting = startOfWork.AddHours(i);
                Meeting meeting = new Meeting(startOfMeeting);

                Meetings.Add(meeting);
            }
            Meetings.Sort(CompareMeetings);
           
        }

        public void NewDateAdded(DateTime start)
        {

            
            Meeting newMeeting = new Meeting(start);
            //bool lunch = newMeeting.Start.Hour.Equals(12) && 

            foreach (Meeting meeting in Meetings)
            {
                if (meeting.Overlap(newMeeting))
                {
                    throw new MeetingOverlapException(meeting);
                }

                // TODO kasta MeetingOverlapException om två möten överlappar
            }            
            Meetings.Add(newMeeting);
            Meetings.Sort(CompareMeetings);
        }

        public void ChangeMeeting(int index, DateTime newStart)
        {
            Meeting meetingToChange = Meetings[index];
            Meeting attemptMeeting = new Meeting(newStart, meetingToChange.Duration);

            foreach (Meeting meeting in Meetings)
            {
                if (meeting.Overlap(attemptMeeting))
                {
                    throw new MeetingOverlapException(meeting);
                }
                // TODO kasta MeetingOverlapException om två möten överlappar
            }
            meetingToChange.Start = newStart;
            Meetings.Sort(CompareMeetings);
        }
    }
}
