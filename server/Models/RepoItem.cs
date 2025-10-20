namespace cryptipedia.Models;

// NOTE abstract denotes that this class can never be instantiated (newed up), it can only be inherited from
public abstract class RepoItem<T>
{
  public T Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}