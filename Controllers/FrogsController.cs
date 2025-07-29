namespace froggy_finder_api.Controllers;

[ApiController]
[Route("api/frogs")] // super('api/frogs')
public class FrogsController : ControllerBase // extends BaseController
{

  private readonly FrogsService _frogsService;

  // dependency injection 💉
  public FrogsController(FrogsService frogsService) // constructor
  {
    _frogsService = frogsService;
  }

  [HttpGet("test")] // .get('/test', this.Test) --> https://localhost:7045/api/frogs/test
  public string Test()
  {
    return "Froggy Finder API is so sick 🐸🐸🐸🐸🐸";
  }

  [HttpGet]
  public ActionResult<List<Frog>> GetFrogs()
  {
    try
    {
      List<Frog> frogs = _frogsService.GetFrogs();
      return Ok(frogs); // 200
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message); // 400
    }
  }

  [HttpGet("{frogId}")] // '/:frogId'
  public ActionResult<Frog> GetFrogById(int frogId) // req.params.frogId
  {
    try
    {
      Frog frog = _frogsService.GetFrogById(frogId);
      return Ok(frog);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message); // 400
    }
  }

  [HttpPost]
  public ActionResult<Frog> CreateFrog([FromBody] Frog frogData)
  {
    try
    {
      Frog frog = _frogsService.CreateFrog(frogData);
      return Ok(frog);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpDelete("{frogId}")]
  public ActionResult<string> DeleteFrog(int frogId)
  {
    try
    {
      _frogsService.DeleteFrog(frogId);
      return Ok("Frog was deleted");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}

