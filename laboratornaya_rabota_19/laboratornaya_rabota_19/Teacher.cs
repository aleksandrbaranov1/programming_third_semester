using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornaya_rabota_19
{
    public class Teacher
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Group { get; set; }

        public Teacher() { }

        public Teacher(string name, string role, string group)
        {
            Name = name;
            Role = role;
            Group = group;
        }


        public override string ToString()
        {
            return $"Имя: {Name}, Роль: {Role}, Группа: {Group}";
        }
    }
}
