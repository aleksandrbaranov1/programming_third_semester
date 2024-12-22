using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornaya_rabota_19
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Group { get; set; }
        public string Schedule { get; set; }
        public string Shift { get; set; }
        public Teacher() { }

        public Teacher(int id, string name, string shift, string group, string schedule)
        {
            Id = id;
            Name = name;
            Group = group;
            Schedule = schedule;
            Shift = shift;
        }


        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Name}, Смена: {Shift}, Группа: {Group}, Расписание: {Schedule}";
        }
    }
}
