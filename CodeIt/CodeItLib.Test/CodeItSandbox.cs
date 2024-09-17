using CodeItLib.Models;
using CodeItLib.Test;
using System.Runtime.CompilerServices;

[assembly: AssemblyFixture(typeof(CodeItSandbox))]
namespace CodeItLib.Test;

public class CodeItSandbox: IDisposable
{
  public Dictionary<string, int> RequestedSandboxProjects = [];
  public static readonly string SandboxRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CodeIt", "Unit Tests");
  public static readonly string TestFilesRoot = Path.Combine(SandboxRoot, "Test Files");

  public CodeItSandbox()
  {
    ClearSandbox();
  }

  public void Dispose()
  {
#if !DEBUG
                // Keep the sandbox in debug mode to inspect the state of the sandbox after test run
                ClearSandbox();
#endif
  }

  public void ClearSandbox()
  {
    if (Directory.Exists(SandboxRoot))
      Directory.Delete(SandboxRoot, true);
  }

  public CodeIt NewCodeIt([CallerMemberName] string testName = "")
  {
    if (RequestedSandboxProjects.ContainsKey(testName))
      throw new InvalidOperationException($"""CodeIt with name "{testName}" is already used by another test method. If this is a theory, use the auto increment version.""");

    RequestedSandboxProjects.Add(testName, 1);

    return new CodeIt
    {
      CodeItRoot = SandboxRoot,
      Name = testName,
      InputContentType = ContentType.Text,
      OutputContentType = ContentType.Text,
      DefaultInputPath = Path.Combine(TestFilesRoot, "TextMultiline.txt")
    };
  }
}
