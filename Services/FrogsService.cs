namespace froggy_finder_api.Services;

public class FrogsService
{
  private readonly FrogsRepository _repository;

  public FrogsService(FrogsRepository repository)
  {
    _repository = repository;
  }

  public List<Frog> GetFrogs()
  {
    List<Frog> frogs = _repository.GetFrogs();
    return frogs;
  }
}