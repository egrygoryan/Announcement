using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnouncementsController : ControllerBase
{
    private readonly IAnnouncementService _srvc;

    public AnnouncementsController(IAnnouncementService announcementService) => _srvc = announcementService;
    [HttpGet("{id}")]
    public IActionResult Get(int id) {
        var result = _srvc.GetAnnouncementById(id); 
        
        return Ok(result);
    }
    [HttpGet]
    public ActionResult<IEnumerable<AnnouncementModel>> GetAll() {
        var result = _srvc.GetAnnouncements();

        return Ok(result);
    }
    [HttpGet("{id}/top-three-similar")]
    public ActionResult<IEnumerable<Announcement>> GetSimilar(int id)
    {
        var result = _srvc.GetSimilarAnnouncements(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Announcement request) {
        _srvc.AddAnnouncement(request);
        return Ok(new { Message = "Operation completed succesfully" });
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Announcement request) {
        _srvc.EditAnnouncement(id, request);
        return Ok(new { Message = "Operation completed succesfully" });
    }
    [HttpDelete]
    public IActionResult Delete(int id) {
        return _srvc.DeleteAnnouncement(id)
            ? Ok(new { Message = "Succesfully deleted" })
            : NotFound(new { Message = "Couldn't find announcement" });
    }

}