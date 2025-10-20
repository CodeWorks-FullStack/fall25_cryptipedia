namespace cryptipedia.Repositories;

public class CryptidsRepository
{
  private readonly IDbConnection _db;

  public CryptidsRepository(IDbConnection db)
  {
    _db = db;
  }
}