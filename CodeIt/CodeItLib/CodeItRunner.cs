using CodeItLib.Models;

namespace CodeItLib;

public class CodeItRunner : ICodeItRunner
{
    public CodeItRunner(CodeIt codeIt)
    {
        CodeIt = codeIt;
    }

    public CodeIt CodeIt { get; }

    public bool Run()
    {
        throw new NotImplementedException();
    }
}
