using CliWrap;
using CliWrap.Buffered;
using CodeItLib.Models;

namespace CodeItLib;

public class CodeItDotNetCLIProjectManager: ICodeItProjectManager
{
  public CodeItDotNetCLIProjectManager(CodeIt codeIt)
  {
    CodeIt = codeIt ?? throw new ArgumentNullException(nameof(codeIt));

    ArgumentException.ThrowIfNullOrWhiteSpace(codeIt.CodeItRoot);
    ArgumentException.ThrowIfNullOrWhiteSpace(codeIt.Name);
  }

  public CodeIt CodeIt { get; private set; }

  public Task<bool> BuildProject()
  {
    throw new NotImplementedException();
  }

  public async Task<bool> CreateProject()
  {
    if (Directory.Exists(CodeIt.CodeItLocation))
      return false;

    if (!Directory.Exists(CodeIt.CodeItRoot))
    {
      Directory.CreateDirectory(CodeIt.CodeItRoot!);
    }

    Directory.CreateDirectory(CodeIt.CodeItLocation!);
    string cwd = CodeIt.CodeItLocation!;

    var response = await Cli.Wrap("dotnet")
      .WithArguments(["new", "classlib", "-o", CodeIt.Name!])
      .WithWorkingDirectory(cwd)
      .ExecuteBufferedAsync();

    return response.IsSuccess;
  }

  public Task<bool> LaunchProject()
  {
    throw new NotImplementedException();
  }
}
