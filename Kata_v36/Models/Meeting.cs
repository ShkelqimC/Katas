﻿using System;
using System.Windows.Forms;

namespace Scheduler.Models
{
    public class Meeting
    {
        public DateTime Start;
        public TimeSpan Duration;
        public Applicant Applicant;
        

        public Meeting(DateTime start)
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(30);
            Applicant = null;
        }
        public Meeting(DateTime start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
            Applicant = null;
        }

        public bool Overlap(Meeting meeting)
        {
            bool endIsBefore = (Start + Duration) < meeting.Start;
            bool startIsAfter = (meeting.Start + meeting.Duration) < Start;
            bool isDuringBreak = (meeting.Start )
            bool test = !(endIsBefore || startIsAfter);
            return test;
        }

        public override string ToString()
        {
            string date = Start.ToLongDateString() + Start.ToString(" HH:mm") + " - " + Start.Add(Duration).ToString("HH:mm");

            if (Applicant != null)
                date += " with: " + Applicant.Name;

            return date;
        }
    }
}
