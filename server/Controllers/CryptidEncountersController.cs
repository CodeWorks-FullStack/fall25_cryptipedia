namespace cryptipedia.Controllers;

public class CryptidEncountersController
{
  private readonly CryptidEncountersService _cryptidEncountersService;
  private readonly Auth0Provider _auth0Provider;

  public CryptidEncountersController(CryptidEncountersService cryptidEncountersService, Auth0Provider auth0Provider)
  {
    _cryptidEncountersService = cryptidEncountersService;
    _auth0Provider = auth0Provider;
  }
}