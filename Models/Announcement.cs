namespace AnnouncementApi.Models;

public class Announcement
{
    public string Title{ get; set; }
    public string Description{ get; set; }
    public DateTime AnnouncementTime { get; set; }
    public bool HaveSameWords(Announcement announcement)
    {
        var doesTitleMatch = Title.Split(' ')
            .Intersect(announcement.Title.Split(' '), StringComparer.OrdinalIgnoreCase)
            .Any();
        var doesDescriptionMatch = Description.Split(' ')
            .Intersect(announcement.Description.Split(' '), StringComparer.OrdinalIgnoreCase)
            .Any();

        return doesTitleMatch && doesDescriptionMatch;
    }
}