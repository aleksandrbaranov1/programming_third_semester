using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laboratornaya_rabota_19
{
    public partial class laboratornaya_rabota_19 : Form
    {
        public List<Child> childrenList;
        public List<Teacher> teachersList;
        public List<Schedule> scheduleList;
        public string[] listOfGroups = {"Ясли", "Гуппа 1", "Группа 2", "Группа 3"};

        public laboratornaya_rabota_19()
        {
            InitializeComponent();
            selectGroup.Items.AddRange(listOfGroups);
            foreach (var teacher in teachersList)
            {
                comboBoxTeachers.Items.Add(teacher.Name);
            }
        }
        private void LoadDataFromCsv()
        {
            // Инициализация списков
            childrenList = new List<Child>();
            teachersList = new List<Teacher>();
            scheduleList = new List<Schedule>();

            // Загрузка данных о детях
            string[] childrenLines = File.ReadAllLines("children.txt");
            for (int i = 0; i < childrenLines.Length; i++) // начинаем с 0 строки
            {
                string[] data = childrenLines[i].Split(';');
                childrenList.Add(new Child(data[0], int.Parse(data[1]), data[2], data[3]));
            }

            // Загрузка данных о воспитателях
            string[] teachersLines = File.ReadAllLines("teachers.csv");
            for (int i = 0; i < teachersLines.Length; i++)
            {
                string[] data = teachersLines[i].Split(';');
                teachersList.Add(new Teacher(data[0], data[1], data[2]));
            }

            // Загрузка данных о расписании
            string[] scheduleLines = File.ReadAllLines("schedule.csv");
            for (int i = 0; i < scheduleLines.Length; i++)
            {
                // Проверяем строку и выводим её для отладки
                Console.WriteLine($"Строка {i + 1}: {scheduleLines[i]}");

                string[] data = scheduleLines[i].Split(';');

                // Проверка длины массива после Split
                Console.WriteLine($"Количество элементов в строке: {data.Length}");

                if (data.Length == 5) // Проверяем, что строка корректно разделилась
                {
                    scheduleList.Add(new Schedule(data[0], data[1], data[2], data[3], data[4]));
                }
                else
                {
                    MessageBox.Show($"Ошибка в строке {i + 1}: {scheduleLines[i]}\nКоличество элементов: {data.Length}");
                }
            }

        }
        private void ShowChildrenByGroup(string groupName)
        {
            var childrenInGroup = from child in childrenList
                                  where child.Group == groupName
                                  select child;

            listOfChildren.Items.Clear();

            // Добавляем детей в ListBox
            foreach (var child in childrenInGroup)
            {
                listOfChildren.Items.Add(child.ToString());
            }
        }
        private void selectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataFromCsv();
            string selectedGroup = selectGroup.SelectedItem.ToString();
            ShowChildrenByGroup(selectedGroup);

        }

        private void numericUpDownAge_ValueChanged(object sender, EventArgs e)
        {
            LoadDataFromCsv();
            int selectedAge = (int)numericUpDownAge.Value;
            var filteredChildren = childrenList
                .Where(child => child.Age == selectedAge) 
                .ToList();

            // Очистка и обновление ListBox
            listOfChildren.Items.Clear();

            if (filteredChildren.Count > 0)
            {
                foreach (var child in filteredChildren)
                {
                    listOfChildren.Items.Add(child.ToString());
                }
            }
            else
            {
                listOfChildren.Items.Add("Детей с указанным возрастом не найдено");
            }
        }

        private void comboBoxTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
