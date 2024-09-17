namespace CodeItLib.Models;

public class CodeIt
{
  public string? CodeItRoot { get; set; }
  public string? Name { get; set; }
  public string? CodeItLocation => Path.Combine(CodeItRoot ?? string.Empty, Name ?? string.Empty);
  public string? DefaultInputPath { get; set; }
  public ContentType? InputContentType { get; set; }
  public ContentType? OutputContentType { get; set; }
  internal ICodeItProjectManager? ProjectManager { get; set; }
  internal ICodeItRunner? CodeRunner { get; set; }
}
