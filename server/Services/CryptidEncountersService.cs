



namespace cryptipedia.Services;

public class CryptidEncountersService
{
  private readonly CryptidEncountersRepository _repository;

  public CryptidEncountersService(CryptidEncountersRepository repository)
  {
    _repository = repository;
  }

  internal CryptidEncounterProfile CreateCryptidEncounter(CryptidEncounter cryptidEncounterData)
  {
    CryptidEncounterProfile cryptidEncounter = _repository.CreateCryptidEncounter(cryptidEncounterData);
    return cryptidEncounter;
  }

  internal void DeleteCryptidEncounter(int cryptidEncounterId, string userId)
  {
    CryptidEncounter cryptidEncounter = GetCryptidEncounterById(cryptidEncounterId);

    if (cryptidEncounter.AccountId != userId)
    {
      throw new Exception("YOU CANNOT DELETE ANOTHER USER'S CRYPTID ENCOUNTER");
    }

    _repository.DeleteCryptidEncounter(cryptidEncounterId);
  }

  private CryptidEncounter GetCryptidEncounterById(int cryptidEncounterId)
  {
    CryptidEncounter cryptidEncounter = _repository.GetCryptidEncounterById(cryptidEncounterId);
    if (cryptidEncounter == null) throw new Exception("No cryptid encounter found with the id of: " + cryptidEncounterId);
    return cryptidEncounter;
  }

  internal List<EncounteredCryptid> GetCryptidEncountersByAccountId(string accountId)
  {
    List<EncounteredCryptid> cryptids = _repository.GetCryptidEncountersByAccountId(accountId);
    return cryptids;
  }

  internal List<CryptidEncounterProfile> GetCryptidEncountersByCryptidId(int cryptidId)
  {
    List<CryptidEncounterProfile> cryptidEncounterProfiles = _repository.GetCryptidEncountersByCryptidId(cryptidId);
    return cryptidEncounterProfiles;
  }
}