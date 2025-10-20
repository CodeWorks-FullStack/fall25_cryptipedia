namespace cryptipedia.Services;

public class CryptidsService
{
  private readonly CryptidsRepository _repository;

  public CryptidsService(CryptidsRepository repository)
  {
    _repository = repository;
  }
}