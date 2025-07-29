namespace froggy_finder_api.Controllers;

[ApiController]
[Route("api/frogs")] // super('api/frogs')
public class FrogsController : ControllerBase // extends BaseController
{
  // public FrogsController() // constructor
  // {

  // }

  [HttpGet] // .get('', this.Test)
  public string Test()
  {
    return "Froggy Finder API is so sick 🐸🐸🐸🐸🐸";
  }

}