
namespace froggy_finder_api.Repositories;

public class FrogsRepository
{
  private readonly IDbConnection _db;

  public FrogsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Frog> GetFrogs()
  {
    string sql = "SELECT * FROM frogs;";

    List<Frog> frogs = _db.Query<Frog>(sql).ToList();

    return frogs;
  }

  public Frog GetFrogById(int frogId)
  {
    // string sql = $"SELECT * FROM frogs WHERE id = {frogId};"; ❌
    string sql = $"SELECT * FROM frogs WHERE id = @FrogId;"; // ✅
    //                                    {FrogId: 6}
    Frog frog = _db.Query<Frog>(sql, new { FrogId = frogId }).SingleOrDefault();

    return frog;
  }
}