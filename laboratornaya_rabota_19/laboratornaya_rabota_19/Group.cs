public class Group
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public string DayOfWeek { get; set; }
    public string Time { get; set; }
    public string Activity { get; set; }
    public string Location { get; set; }
    public int ChildrenCount { get; set; }
    public string WalkSchedule { get; set; }

    public Group(int groupId, string groupName, string dayOfWeek, string time, string activity, string location, int childrenCount, string walkSchedule)
    {
        GroupId = groupId;
        GroupName = groupName;
        DayOfWeek = dayOfWeek;
        Time = time;
        Activity = activity;
        Location = location;
        ChildrenCount = childrenCount;
        WalkSchedule = walkSchedule;
    }
}
