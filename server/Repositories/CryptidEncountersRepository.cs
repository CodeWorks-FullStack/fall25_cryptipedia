




namespace cryptipedia.Repositories;

public class CryptidEncountersRepository
{
  private readonly IDbConnection _db;

  public CryptidEncountersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal CryptidEncounterProfile CreateCryptidEncounter(CryptidEncounter cryptidEncounterData)
  {
    string sql = @"
    INSERT INTO
    cryptid_encounters(account_id, cryptid_id)
    VALUES(@AccountId, @CryptidId);
    
    SELECT
    accounts.*,
    cryptid_encounters.id AS cryptid_encounter_id,
    cryptid_encounters.created_at AS encountered_at
    FROM cryptid_encounters
    INNER JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.id = LAST_INSERT_ID();";

    CryptidEncounterProfile cryptidEncounter = _db.Query<CryptidEncounterProfile>(sql, cryptidEncounterData).SingleOrDefault();

    return cryptidEncounter;
  }

  internal void DeleteCryptidEncounter(int cryptidEncounterId)
  {
    string sql = "DELETE FROM cryptid_encounters WHERE id = @cryptidEncounterId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { cryptidEncounterId });

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows are now gone and UH OH.");
    }
  }

  internal CryptidEncounter GetCryptidEncounterById(int cryptidEncounterId)
  {
    string sql = "SELECT * FROM cryptid_encounters WHERE id = @cryptidEncounterId;";

    CryptidEncounter cryptidEncounter = _db.Query<CryptidEncounter>(sql, new { cryptidEncounterId }).SingleOrDefault();

    return cryptidEncounter;
  }

  internal List<EncounteredCryptid> GetCryptidEncountersByAccountId(string accountId)
  {
    string sql = @"
    SELECT
    cryptids.*,
    cryptid_encounters.created_at AS encountered_at,
    cryptid_encounters.id AS cryptid_encounter_id,
    accounts.*
    FROM cryptid_encounters
    INNER JOIN cryptids ON cryptids.id = cryptid_encounters.cryptid_id
    INNER JOIN accounts ON accounts.id = cryptids.discoverer_id
    WHERE account_id = @accountId;";

    List<EncounteredCryptid> cryptids = _db.Query(
      sql,
      (EncounteredCryptid cryptid, Profile account) =>
      {
        cryptid.Discoverer = account;
        return cryptid;
      },
      new { accountId }).ToList();

    return cryptids;
  }

  internal List<CryptidEncounterProfile> GetCryptidEncountersByCryptidId(int cryptidId)
  {
    string sql = @"
    SELECT
    accounts.*,
    cryptid_encounters.id AS cryptid_encounter_id,
    cryptid_encounters.created_at AS encountered_at
    FROM cryptid_encounters
    INNER JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.cryptid_id = @cryptidId;";

    List<CryptidEncounterProfile> cryptidEncounterProfiles = _db.Query<CryptidEncounterProfile>(sql, new { cryptidId }).ToList();
    return cryptidEncounterProfiles;
  }
}