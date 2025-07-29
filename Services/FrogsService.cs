namespace froggy_finder_api.Services;

public class FrogsService
{
  // NOTE you should only have one repository per service
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

  public Frog GetFrogById(int frogId)
  {
    Frog frog = _repository.GetFrogById(frogId);

    if (frog == null)
    {
      throw new Exception($"Invalid id: {frogId}");
    }

    return frog;
  }

  public Frog CreateFrog(Frog frogData)
  {
    Frog frog = _repository.CreateFrog(frogData);
    return frog;
  }

  internal void DeleteFrog(int frogId)
  {
    _repository.DeleteFrog(frogId);
  }
}