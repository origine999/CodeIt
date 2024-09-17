namespace CodeItLib.Models;

public interface ICodeItProjectManager
{
  public Task<bool> CreateProject();
  public Task<bool> LaunchProject();
  public Task<bool> BuildProject();
}
