using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornaya_rabota_19
{
    public class Schedule
    {
        public string Group { get; set; }
        public string DayOfWeek { get; set; }
        public string Time { get; set; }
        public string Activity { get; set; }
        public string Room { get; set; }
        public Schedule() { }
        public Schedule(string group, string dayOfWeek, string time, string activity, string room)
        {
            Group = group;
            DayOfWeek = dayOfWeek;
            Time = time;
            Activity = activity;
            Room = room;
        }
        public override string ToString()
        {
            return $"Группа: {Group}, День недели: {DayOfWeek}, Время: {Time}, Занятие: {Activity}, Комната: {Room}";
        }
    }
}
