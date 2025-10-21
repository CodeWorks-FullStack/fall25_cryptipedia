namespace cryptipedia.Models;

public class CryptidEncounter : RepoItem<int>
{
  public int CryptidId { get; set; }
  public string AccountId { get; set; }
}

// DTO data transfer object
public class CryptidEncounterProfile : Profile
{
  public int CryptidEncounterId { get; set; }
  public DateTime EncounteredAt { get; set; }
}

public class EncounteredCryptid : Cryptid
{
  public int CryptidEncounterId { get; set; }
  public DateTime EncounteredAt { get; set; }

}