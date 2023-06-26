namespace AnnouncementApi.Mappings;

public class AnnouncementProfile : Profile
{
    public AnnouncementProfile()
    {
        CreateMap<Announcement, AnnouncementModel>()
            .ForMember(am => am.Title, opt => opt.MapFrom(a => a.Title))
            .ForMember(am => am.Description, opt => opt.MapFrom(a => a.Description))
            .ForMember(am => am.AnnouncementTime, opt => opt.MapFrom(a => a.AnnouncementTime));
        CreateMap<AnnouncementModel, Announcement>()
            .ForMember(a => a.Title, opt => opt.MapFrom(am => am.Title))
            .ForMember(a => a.Description, opt => opt.MapFrom(am => am.Description))
            .ForMember(a => a.AnnouncementTime, opt => opt.MapFrom(am => am.AnnouncementTime));
    }
}
