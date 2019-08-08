namespace AUM.UpdateCreator
{
  using System;
  using System.IO;
  using Core;


  internal sealed class ScriptOrderBuilder : FileOrderBuilder
  {
    public ScriptOrderBuilder(string fileOrderConfig) : base(fileOrderConfig)
    {
    }

    protected override void AddFile(string file, bool isChecked)
    {
      // ReSharper disable PossibleNullReferenceException
      if (Path.HasExtension(file) && Path.GetExtension(file).Equals(".sql", StringComparison.OrdinalIgnoreCase))
      {
        m_files.Add(new RunScriptData{FileName = file, Checked = isChecked});
      }
      // ReSharper restore PossibleNullReferenceException
    }
  }
}