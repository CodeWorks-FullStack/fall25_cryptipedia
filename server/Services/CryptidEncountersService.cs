
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
}