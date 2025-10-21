


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