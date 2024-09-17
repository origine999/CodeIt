using CodeItLib.Models;

namespace CodeItLib;

public class CodeItManager
{
  public List<CodeIt> CodeIts { get; set; } = [];

  public async Task<bool> InitializeNewCodeIt(CodeIt definition)
  {
    AddMissingCodeItPropertiesWithDefaults(definition);
    CodeIts.Add(definition);
    return await definition.ProjectManager!.CreateProject();
  }

  public async Task<bool> LaunchCodeItEditor(CodeIt definition)
  {
    AddMissingCodeItPropertiesWithDefaults(definition);
    return await definition.ProjectManager!.LaunchProject();
  }

  private static void AddMissingCodeItPropertiesWithDefaults(CodeIt codeIt)
  {
    codeIt.CodeItRoot ??= CodeItConstants.CodeItRoot;

    codeIt.ProjectManager ??= new CodeItDotNetCLIProjectManager(codeIt);

    codeIt.CodeRunner ??= new CodeItRunner(codeIt);
  }
}
