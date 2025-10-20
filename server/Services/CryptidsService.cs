


namespace cryptipedia.Services;

public class CryptidsService
{
  private readonly CryptidsRepository _repository;

  public CryptidsService(CryptidsRepository repository)
  {
    _repository = repository;
  }

  internal Cryptid CreateCryptid(Cryptid cryptidData)
  {
    Cryptid cryptid = _repository.CreateCryptid(cryptidData);
    return cryptid;
  }

  internal List<Cryptid> GetAllCryptids()
  {
    List<Cryptid> cryptids = _repository.GetAllCryptids();
    return cryptids;
  }

  internal Cryptid GetCryptidById(int cryptidId)
  {
    Cryptid cryptid = _repository.GetCryptidById(cryptidId);

    if (cryptid == null)
    {
      throw new Exception("Invalid cryptid id: " + cryptidId);
    }

    return cryptid;
  }
}