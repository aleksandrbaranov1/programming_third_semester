public class Schedule
{
    public string Group { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public string Activity { get; set; }
    public string Location { get; set; }

    public Schedule(string group, string day, string time, string activity, string location)
    {
        Group = group;
        Day = day;
        Time = time;
        Activity = activity;
        Location = location;
    }
}
