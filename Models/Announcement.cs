namespace AnnouncementApi.Models;

public class Announcement
{
    public string Title{ get; set; }
    public string Description{ get; set; }
    public DateTime AnnouncementTime { get; set; }
    public bool HaveSameWords(Announcement announcement)
    {
        string[] primarySet = (Title + " " + Description).Split(" ");
        string[] announcementSet = (announcement.Title + " " + announcement.Description).Split(" ");

        return primarySet.Intersect(announcementSet).Any();
    }
}
