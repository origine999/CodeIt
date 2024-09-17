namespace CodeItLib.Test;

public class CodeItManagerTest
{
  public CodeItManagerTest(CodeItSandbox sandbox)
  {
    Sandbox = sandbox;
  }

  public CodeItSandbox Sandbox { get; }

  [Fact]
  public async Task CreateTextCodeIt_FolderStructureIsCreated()
  {
    var codeIt = Sandbox.NewCodeIt();
    var manager = new CodeItManager();
    Assert.True(await manager.InitializeNewCodeIt(codeIt));
    Assert.True(Directory.Exists(codeIt.CodeItLocation));
  }
}
