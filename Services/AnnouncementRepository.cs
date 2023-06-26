namespace AnnouncementApi.Services;

public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly AnnouncementContext _ctx;
    public AnnouncementRepository(AnnouncementContext context) => _ctx = context;
    public void AddAnnouncement(AnnouncementModel announcement)
    {
        _ctx.Announcements.AddAsync(announcement);
        _ctx.SaveChanges();
    } 

    public bool DeleteAnnouncement(int id)
    {
        var announcement =  _ctx.Announcements.FirstOrDefault(a => a.Id == id);

        if(announcement is not null)
        {
            _ctx.Announcements.Remove(announcement);
            _ctx.SaveChangesAsync();
            return true;
        }

        return false;
    }
    public void EditAnnouncement(AnnouncementModel announcement)
    {
        _ctx.Entry(announcement).State = EntityState.Modified;
        _ctx.SaveChanges();
    }

    public AnnouncementModel GetAnnouncementById(int id) =>  _ctx.Announcements.FirstOrDefault(a => a.Id == id);

    public IEnumerable<AnnouncementModel> GetAnnouncements() =>  _ctx.Announcements.ToList();
}
