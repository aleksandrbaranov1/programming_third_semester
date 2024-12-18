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
        public string[] listOfGroups = { "показывать список детей указанной группы",
        "показывать список детей указанного возраста",
        "показывать занятость указанного воспитателя",
        "показывать занятость указанной группы в указанный день недели",
        "показывать процентное отношение мальчиков и девочек в указанной группе",
        "находить название (и/или №) группы по Ф.И.О. ребёнка"};

        public laboratornaya_rabota_19()
        {
            InitializeComponent();

            childrenList = new List<Child>();
            teachersList = new List<Teacher>();
            scheduleList = new List<Schedule>();

            LoadDataFromCsv();

            selectFilter.Items.AddRange(listOfGroups);
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
                childrenList.Add(new Child(int.Parse(data[0]),
                    data[1],
                    int.Parse(data[2]),
                    data[3],
                    data[4]));
            }

            // Загрузка данных о воспитателях
            string[] teachersLines = File.ReadAllLines("teachers.csv");
            for (int i = 0; i < teachersLines.Length; i++)
            {
                string[] data = teachersLines[i].Split(';');
                teachersList.Add(new Teacher(
                    int.Parse(data[0]),
                    data[1],
                    data[2],
                    data[3],
                    data[4]));
            }
                // Загрузка данных о расписании
            string[] scheduleLines = File.ReadAllLines("schedule.csv");
            for (int i = 0; i < scheduleLines.Length; i++)
            {
                string[] data = scheduleLines[i].Split(';');
                scheduleList.Add(new Schedule(data[0],
                    data[1],
                    data[2],
                    data[3],
                    data[4]));
            }

        }
        private void ShowChildrenByGroup(string groupName)
        {
            var childrenInGroup = from child in childrenList
                                  where child.Group == groupName
                                  select child;

            resultList.Items.Clear();

            // Добавляем детей в ListBox
            foreach (var child in childrenInGroup)
            {
                resultList.Items.Add(child.ToString());
            }
        }

        private void filter_Click(object sender, EventArgs e)
        {
            switch (selectFilter.SelectedItem.ToString())
            {
                case "показывать список детей указанного возраста":
                    firstRequest();
                    break;
                case "показывать список детей указанной группы":
                    secondRequest(); 
                    break;
                case "показывать занятость указанного воспитателя":
                    thirdRequest();
                    break;
                default:
                    break;

            }
            //firstRequest();
        }
        private void firstRequest()
        {
            string selectedFilter = selectFilter.SelectedItem.ToString();
            resultList.Items.Clear();

            if (selectedFilter == "показывать список детей указанного возраста")
            {
                int selectedAge;

                if (int.TryParse(parameterFilter.Text, out selectedAge))
                {
                    var filteredChildren = childrenList.Where(child => child.Age == selectedAge).ToList();

                    foreach (var child in filteredChildren)
                    {
                        resultList.Items.Add($"ID: {child.Id}, Имя: {child.Name}, Возраст: {child.Age}, Пол: {child.Gender}, Группа: {child.Group}");
                    }

                    if (filteredChildren.Count == 0)
                    {
                        resultList.Items.Add("Дети указанного возраста не найдены.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректный возраст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void secondRequest()
        {
            string selectedGroup = parameterFilter.Text.Trim();

            var filteredChildren = childrenList
                .Where(child => child.Group.Equals(selectedGroup, StringComparison.OrdinalIgnoreCase))
                .ToList();

            resultList.Items.Clear();

            if (filteredChildren.Count == 0)
            {
                resultList.Items.Add($"Дети из группы '{selectedGroup}' не найдены.");
                return;
            }

            foreach (var child in filteredChildren)
            {
                resultList.Items.Add($"ID: {child.Id}, Имя: {child.Name}, Возраст: {child.Age}, Группа: {child.Group}");
            }
        }
        private void thirdRequest()
        {
            resultList.Items.Clear();

            // Выполняем запрос LINQ для поиска воспитателя
            var teacher = teachersList.FirstOrDefault(t => t.Name == Name);

            // Проверка, найден ли воспитатель
            if (teacher != null)
            {
                resultList.Items.Add($"Занятость для: {teacher.Name}");
                resultList.Items.Add($"Смена: {teacher.Shift}");
                resultList.Items.Add($"Группа: {teacher.Group}");
                resultList.Items.Add($"Расписание: {teacher.Schedule}");
            }
            else
            {
                resultList.Items.Add("Воспитатель не найден.");
            }
        }
    }
}
