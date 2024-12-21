using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace laboratornaya_rabota_19
{
    public partial class laboratornaya_rabota_19 : Form
    {
        public List<Child> childrenList;
        public List<Teacher> teachersList;
        public List<Schedule> scheduleList;
        public List<Group> groupList;
        public string[] listOfGroups = { "показывать список детей указанной группы",
        "показывать список детей указанного возраста",
        "показывать занятость указанного воспитателя",
        "показывать занятость указанной группы в указанный день недели",
        "показывать процентное отношение мальчиков и девочек в указанной группе",
        "находить название (и/или №) группы по Ф.И.О. ребёнка"};

        public string[] days = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};

        public laboratornaya_rabota_19()
        {
            InitializeComponent();

            childrenList = new List<Child>();
            teachersList = new List<Teacher>();
            scheduleList = new List<Schedule>();

            LoadDataFromCsv();

            selectFilter.Items.AddRange(listOfGroups);
            choiceOfDay.Items.AddRange(days);

        }
        private void LoadDataFromCsv()
        {
            childrenList = new List<Child>();
            teachersList = new List<Teacher>();
            scheduleList = new List<Schedule>();
            groupList = new List<Group>();

            string[] childrenLines = File.ReadAllLines("children.txt");
            for (int i = 0; i < childrenLines.Length; i++) 
            {
                string[] data = childrenLines[i].Split(';');
                childrenList.Add(new Child(int.Parse(data[0]),
                    data[1],
                    int.Parse(data[2]),
                    data[3],
                    data[4]));
            }

            string[] teachersLines = File.ReadAllLines("teachers.csv", Encoding.Default);
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
            string[] groupLines = File.ReadAllLines("groups.csv", Encoding.Default);
            for (int i = 0; i < groupLines.Length; i++)
            {
                string[] data = groupLines[i].Split(';');
                groupList.Add(new Group(
                    int.Parse(data[0]),
                    data[1],
                    data[2],  
                    data[3],  
                    data[4], 
                    data[5],  
                    int.Parse(data[6]),  
                    data[7]  
                ));
            }
            choiceOfDay.Enabled = false;
        }
        private void filter_Click(object sender, EventArgs e)
        {
            switch (selectFilter.SelectedItem.ToString())
            {
                case "показывать список детей указанного возраста":
                    ShowChildrenByGroup();
                    break;
                case "показывать список детей указанной группы":
                    ShowChildrenByAge(); 
                    break;
                case "показывать занятость указанного воспитателя":
                    ShowTeacherSchedulet();
                    break;
                case "показывать занятость указанной группы в указанный день недели":
                    ShowGroupScheduleByDay();
                    break;
                case "показывать процентное отношение мальчиков и девочек в указанной группе":
                    ShowGenderRatio();
                    break;
                case "находить название (и/или №) группы по Ф.И.О. ребёнка":
                    FindGroupByChildName();
                    break;
                default:
                    break;

            }
        }
        private void ShowChildrenByGroup()
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
        private void ShowChildrenByAge()
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
        private void ShowTeacherSchedulet()
        {
            resultList.Items.Clear();

            var enteredName = parameterFilter.Text;

            var teacher = teachersList.FirstOrDefault(t => t.Name.Equals(enteredName, StringComparison.OrdinalIgnoreCase));

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
        private void ShowGroupScheduleByDay()
        {
            resultList.Items.Clear();
            
            string group = parameterFilter.Text;
            string dayOfWeek = choiceOfDay.SelectedItem.ToString();

            var schedule = groupList
                .Where(g => g.GroupName == group && g.DayOfWeek == dayOfWeek)
                .ToList();

            foreach (var item in schedule)
            {
                resultList.Items.Add($"{item.Time}: {item.Activity} в {item.Location}");
            }
        }
        private void ShowGenderRatio()
        {
            resultList.Items.Clear();

            string groupName = parameterFilter.Text;

            var childrenInGroup = childrenList.Where(c => c.Group == groupName).ToList();

            int boysCount = childrenInGroup.Count(c => c.Gender == "Мальчик");
            int girlsCount = childrenInGroup.Count(c => c.Gender == "Девочка");

            int total = boysCount + girlsCount;

            double boysPercentage = (double)boysCount / total * 100;
            double girlsPercentage = (double)girlsCount / total * 100;

            resultList.Items.Add($"Группа: {groupName}");
            resultList.Items.Add($"Мальчики: {boysPercentage:F2}%");
            resultList.Items.Add($"Девочки: {girlsPercentage:F2}%");
        }
        private void FindGroupByChildName()
        {
            resultList.Items.Clear();

            string childName = parameterFilter.Text;

      
            foreach (var child in childrenList)
            {
                if (child.Name.Contains(childName))
                {
                    resultList.Items.Add($"Ребёнок: {child.Name}");
                    resultList.Items.Add($"Группа: {child.Group}");
                    break; 
                }
            }
        }

        private void selectFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectFilter.SelectedItem.ToString() == "показывать занятость указанной группы в указанный день недели")
            {
                choiceOfDay.Enabled = true; 
            }
            else
            {
                choiceOfDay.Enabled = false; 
            }
        }
    }
}
