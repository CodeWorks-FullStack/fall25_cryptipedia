
namespace cryptipedia.Repositories;

public class CryptidsRepository
{
  private readonly IDbConnection _db;

  public CryptidsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Cryptid CreateCryptid(Cryptid cryptidData)
  {
    string sql = @"
    INSERT INTO
    cryptids (name, threat_level, size, img_url, origin, description, discoverer_id)
    VALUES(@Name, @ThreatLevel, @Size, @ImgUrl, @Origin, @Description, @DiscovererId);
    
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    INNER JOIN accounts ON accounts.id = cryptids.discoverer_id
    WHERE cryptids.id = LAST_INSERT_ID();";

    Cryptid createdCryptid = _db.Query(
      sql,
      (Cryptid cryptid, Profile account) =>
      {
        cryptid.Discoverer = account;
        return cryptid;
      },
      cryptidData).SingleOrDefault();

    return createdCryptid;
  }
}