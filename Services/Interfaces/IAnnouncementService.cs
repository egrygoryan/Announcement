namespace AnnouncementApi.Services.Interfaces;

public interface IAnnouncementService
{
    IEnumerable<Announcement> GetAnnouncements();
    Announcement GetAnnouncementById(int id);
    void AddAnnouncement(Announcement announcement);
    bool DeleteAnnouncement(int id);
    void EditAnnouncement(int id, Announcement announcement);
    IEnumerable<Announcement> GetSimilarAnnouncements(int id);
}