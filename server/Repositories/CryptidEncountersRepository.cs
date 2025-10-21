
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
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.id = LAST_INSERT_ID();";

    CryptidEncounterProfile cryptidEncounter = _db.Query<CryptidEncounterProfile>(sql, cryptidEncounterData).SingleOrDefault();

    return cryptidEncounter;
  }
}