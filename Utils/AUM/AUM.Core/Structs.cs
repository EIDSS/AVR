namespace AUM.Core
{
  public struct CopyDirData
  {
    public string SourceDir { get; set; }
    public string DestinationDir { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class RunScriptData : IFile
  {
    #region IFile Members

    public string FileName { get; set; }
    public bool Checked { get; set; }

    #endregion

    public override string ToString()
    {
      return FileName;
    }
  }

  public interface IFile
  {
    string FileName { get; set; }
    bool Checked { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class ExecuteData : IFile
  {
    /// <summary>
    /// Нужно ли ждать окончания выполнения перед тем, как приступать к следующему файлу
    /// </summary>
    public bool NeedWait { get; set; }

    #region IFile Members

    public string FileName { get; set; }
    public bool Checked { get; set; }

    #endregion

    public override string ToString()
    {
      return FileName;
    }
  }

  public struct ChangeConfigData
  {
    public string FileName { get; set; }
    public string Path { get; set; }

    /// <summary>
    /// Название атрибута-ключа
    /// </summary>
    public string AttributeKey { get; set; }

    /// <summary>
    /// Название атрибута-значения
    /// </summary>
    public string AttributeValue { get; set; }

    /// <summary>
    /// Значение ключа, который находится в атрибуте-ключе
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Значение, которое находится в атрибуте-значении
    /// </summary>
    public string Value { get; set; }

    public bool ValueIsRegularExpression { get; set; }

    /// <summary>
    /// Если true, то этот нод подлежит удалению
    /// </summary>
    public bool DeleteThisNode { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public enum OverwriteFiles
  {
    No,
    Older,
    All,
  }

  /// <summary>
  /// Аргументы запуска апдейтера
  /// </summary>
  public static class Args
  {
    public static string Sync
    {
      get { return "/d"; }
    }

    public static string Admin
    {
      get { return "/a"; }
    }
  }
}