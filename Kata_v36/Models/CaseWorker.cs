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

        public CaseWorker()
        {
            Meetings = new List<Meeting>();
            int workHours = 8;
            DateTime startOfWork = DateTime.Today.AddHours(8);
            DateTime endOfWork = startOfWork.AddHours(9);
            DateTime startOfBreak = startOfWork.AddHours(4);
            DateTime endOfBreak = startOfWork.AddHours(5);
            for (int i = 0; i < workHours; i++)
            {
                if (i==4)
                {
                    continue;
                }
                DateTime startOfMeeting = startOfWork.AddHours(i);
                Meeting meeting = new Meeting(startOfMeeting);

                Meetings.Add(meeting);
            }
        }

        public void NewDateAdded(DateTime start)
        {
            Meeting newMeeting = new Meeting(start);

            foreach (Meeting meeting in Meetings)
            {
                if (meeting.Overlap(newMeeting))
                {
                    throw new MeetingOverlapException(meeting);
                }

                // TODO kasta MeetingOverlapException om två möten överlappar
            }            
            Meetings.Add(newMeeting);
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

        }
    }
}
