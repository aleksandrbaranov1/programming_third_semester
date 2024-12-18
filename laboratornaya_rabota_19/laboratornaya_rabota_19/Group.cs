using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornaya_rabota_19
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MorningTeacher { get; set; }
        public string EveningTeacher { get; set; }
        public string Nanny { get; set; }
        public int ChildrenCount { get; set; }

        public Group() { }

        public Group(int id, string name, string morningTeacher, string eveningTeacher, string nanny, int childrenCount)
        {
            Id = id;
            Name = name;
            MorningTeacher = morningTeacher;
            EveningTeacher = eveningTeacher;
            Nanny = nanny;
            ChildrenCount = childrenCount;
        }

        public override string ToString()
        {
            return $"Группа: {Name}, Утренний воспитатель: {MorningTeacher}, Вечерний воспитатель: {EveningTeacher}, Нянечка: {Nanny}, Кол-во детей: {ChildrenCount}";
        }

    }
}
