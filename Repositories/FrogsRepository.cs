


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

  internal Frog CreateFrog(Frog frogData)
  {
    string sql = @"
    INSERT INTO
    frogs (name, color, is_poisonous, is_single, number_of_toes, species)
    VALUES (@Name, @Color, @IsPoisonous, @IsSingle, @NumberOfToes, @Species);
    
    SELECT * FROM frogs WHERE id = LAST_INSERT_ID();";

    Frog frog = _db.Query<Frog>(sql, frogData).SingleOrDefault();

    return frog;
  }

  internal void DeleteFrog(int frogId)
  {
    string sql = "DELETE FROM frogs WHERE id = @FrogId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { FrogId = frogId });

    if (rowsAffected == 0)
    {
      throw new Exception($"Invalid id: {frogId} (or your sql sucks)");
    }

    if (rowsAffected > 1)
    {
      throw new Exception($"{rowsAffected} rows have been deleted and that ain't good");
    }

  }
}