namespace froggy_finder_api.Repositories;

// NOTE the repository layer is specifically for database logic to happen. Business logic should be handled by the service layer. Only the service layer should have access to the repository layer
public class FrogsRepository
{
  // creates a connection to our sql database
  // dapper is our ORM
  private readonly IDbConnection _db;

  public FrogsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Frog> GetFrogs()
  {
    // sql for dapper to run and execute on database
    string sql = "SELECT * FROM frogs;";

    // Query is a dapper method that allows to request information back from our database
    // the Type Argument passed to Query (Frog) is what Dapper will cast each row of data returned into. Dapper will match up sql columns with snake_case to C# class properties with PascalCase ex: is_single --> IsSingle
    //  Query must be passed a string argument to indicate the sql to execute
    // Query will always return an IEnumerable data type, which is a very basic form of an array. We can convert the IEnumerable into a List by calling the ToList method
    List<Frog> frogs = _db.Query<Frog>(sql).ToList();

    return frogs;
  }

  public Frog GetFrogById(int frogId)
  {
    // It is a very bad idea to inject anything coming from the client directly into our sql statement, because this can open up our server to sql injection attacks
    // string sql = $"SELECT * FROM frogs WHERE id = {frogId};"; ❌

    // The @ sign signifies a sql variable. Dapper can create variables for us, sanitize them, and safely insert the value into the sql statement for us
    string sql = $"SELECT * FROM frogs WHERE id = @FrogId;"; // ✅

    // the second argument passed to Dapper is an object that we want dapper to sanitize and parameterize. It must must be an object, and the key in the object must match the name of the sql variable from the above sql statement
    // SingleOrDefault will convert the IEnumerable returned into a single object. If there is more than one row returned from the sql statement, it will throw an error. If no rows are returned, it will return `null`
    //                                    {FrogId: 6}
    Frog frog = _db.Query<Frog>(sql, new { FrogId = frogId }).SingleOrDefault();

    return frog;
  }

  internal Frog CreateFrog(Frog frogData)
  {
    // possible to run multiple sql actions at once, but they must be separated by semi-colons ';'
    // LAST_INSERT_ID is a sql function that will get the unique identifier of the last inserted row (id)
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
    // REVIEW don't forget your WHERE clause here!
    string sql = "DELETE FROM frogs WHERE id = @FrogId LIMIT 1;";

    // Execute is a dapper method that will run a sql statement on your database, and is useful for when you aren't selecting data out. It will return how many rows were affected by the sql statement
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