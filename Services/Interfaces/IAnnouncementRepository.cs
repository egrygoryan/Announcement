namespace AnnouncementApi.Services.Interfaces;

public interface IAnnouncementRepository
{
    IEnumerable<AnnouncementModel> GetAnnouncements();
    AnnouncementModel GetAnnouncementById(int id);
    void AddAnnouncement(AnnouncementModel announcement);
    bool DeleteAnnouncement(int id);
    void EditAnnouncement(AnnouncementModel announcement);
}