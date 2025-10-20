


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

    Cryptid createdCryptid = _db.Query<Cryptid, Profile, Cryptid>(sql, JoinDiscoverer, cryptidData).SingleOrDefault();

    return createdCryptid;
  }

  internal List<Cryptid> GetAllCryptids()
  {
    string sql = @"
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    INNER JOIN accounts ON accounts.id = cryptids.discoverer_id
    ORDER BY cryptids.id ASC;";

    List<Cryptid> cryptids = _db.Query<Cryptid, Profile, Cryptid>(sql, JoinDiscoverer).ToList();

    return cryptids;
  }

  internal Cryptid GetCryptidById(int cryptidId)
  {
    string sql = @"
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    INNER JOIN accounts ON accounts.id = cryptids.discoverer_id
    WHERE cryptids.id = @cryptidId;";

    Cryptid cryptid = _db.Query<Cryptid, Profile, Cryptid>(sql, JoinDiscoverer, new { cryptidId }).SingleOrDefault();

    return cryptid;
  }

  private static Cryptid JoinDiscoverer(Cryptid cryptid, Profile account)
  {
    cryptid.Discoverer = account;
    return cryptid;
  }
}