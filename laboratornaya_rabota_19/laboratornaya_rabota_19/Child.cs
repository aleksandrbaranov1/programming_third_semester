using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornaya_rabota_19
{
    public class Child
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Group { get; set; }
        public Child() { }

        public Child(string name, int age, string gender, string group)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Group = group;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Пол: {Gender}, Группа: {Group}";
        }
    }
}
