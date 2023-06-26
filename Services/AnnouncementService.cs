namespace AnnouncementApi.Services;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _repository;
    private readonly IMapper _mapper;

    public AnnouncementService(IAnnouncementRepository repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

    public void AddAnnouncement(Announcement announcement)
    {
        var model = _mapper.Map<AnnouncementModel>(announcement);

        _repository.AddAnnouncement(model);
    }

    public bool DeleteAnnouncement(int id) => _repository.DeleteAnnouncement(id);

    public void EditAnnouncement(int id, Announcement announcement)
    {
        _ = _repository.GetAnnouncementById(id);
        var updatedModel = _mapper.Map<AnnouncementModel>(announcement);
        updatedModel.Id = id;

        _repository.EditAnnouncement(updatedModel);
    }

    public Announcement GetAnnouncementById(int id)
    {
        var entity =  _repository.GetAnnouncementById(id);
        if(entity is null)
        {
            throw new ArgumentException($"There is no an announcement with ID: {id}");
        }
        var announcement = _mapper.Map<Announcement>(entity);

        return announcement;
    }

    public IEnumerable<Announcement> GetAnnouncements()
    {
        var entities = _repository.GetAnnouncements();
        if (!entities.Any())
        {
            throw new InvalidOperationException($"There are no announcements");
        }

        var announcements = entities.Select(e => _mapper.Map<Announcement>(e)).ToList();

        return announcements;
    }

    public IEnumerable<Announcement> GetSimilarAnnouncements(int id)
    {
        var allModels = _repository.GetAnnouncements();
        var certainModel = _repository.GetAnnouncementById(id);

        var allAnnouncements = allModels.Select(e => _mapper.Map<Announcement>(e)).ToList();
        var chosenAnnouncement = _mapper.Map<Announcement>(certainModel);

        var similar = allAnnouncements.Where(a => chosenAnnouncement.HaveSameWords(a)).Take(3);
        return similar;
    }
}
