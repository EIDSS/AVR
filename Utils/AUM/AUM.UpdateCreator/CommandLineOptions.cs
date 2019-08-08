namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using CommandLine;
  using CommandLine.Text;


  internal sealed class CommandLineOptions
  {
    [Option('q', "noui", DefaultValue = false, HelpText = "Turns off user UI and runs in silent (console) mode.")]
    public bool IsQuiet { get; set; }

    [Option('t', "total", DefaultValue = true, HelpText = "Selects patch type - total or small")]
    public bool IsTotal { get; set; }

    [Option('u', "updatesource", HelpText = "Folder with update sources.")]
    public string UpdateSource { get; set; }

    [Option('o', "output", HelpText = "Output folder")]
    public string OutputPath { get; set; }

    [OptionList('v', "totalversion", Separator = '.', HelpText = "Total patch version")]
    public IList<string> TotalVersion { get; set; }

    [ParserState]
    public IParserState LastParserState { get; set; }

    #region aum

    [OptionList("aum", Separator = '.', HelpText = "Includes AUM in patch, and sets its version")]
    public IList<string> AumVersion { get; set; }

    [OptionList("aumcortege", Separator = '|', HelpText = "Specifies AUM cortege version")]
    public IList<string> AumCortege { get; set; }

    #endregion aum

    #region x

    [Option("x", HelpText = "Includes Custom tasks in patch")]
    public bool CustomTasks { get; set; }

    [Option("xfiles", HelpText = "Configuration file specifying custom tasks order")]
    public string CustomTasksFiles { get; set; }

    #endregion x

    #region db

    [OptionList("db", Separator = '.', HelpText = "Includes SQL scripts in patch, and sets db patch version")]
    public IList<string> DbVersion { get; set; }

    [OptionList("dbcortege", Separator = '|', HelpText = "Specifies Db cortege version")]
    public IList<string> DbCortege { get; set; }

    [Option("dbfiles", HelpText = "Configuration file specifying SQL scripts order")]
    public string DbFiles { get; set; }

    #endregion db

    #region dba

    [OptionList("dba", Separator = '.', HelpText = "Includes SQL scripts for archive db in patch, and sets archive db patch version")]
    public IList<string> DbaVersion { get; set; }

    [OptionList("dbacortege", Separator = '|', HelpText = "Specifies archive db cortege version")]
    public IEnumerable<string> DbaCortege { get; set; }

    [Option("dbafiles", HelpText = "Configuration file specifying archive db SQL scripts order")]
    public string DbaFiles { get; set; }

    #endregion dba

    #region dbavr

    [OptionList("dbavr", Separator = '.', HelpText = "Includes SQL scripts for AVR db in patch, and sets AVR db patch version")]
    public IList<string> DbAvrVersion { get; set; }

    [OptionList("dbavrcortege", Separator = '|', HelpText = "Specifies AVR db cortege version")]
    public IEnumerable<string> DbAvrCortege { get; set; }

    [Option("dbavrfiles", HelpText = "Configuration file specifying AVR db SQL scripts order")]
    public string DbAvrFiles { get; set; }

    #endregion dbavr

    #region avrs

    [OptionList("avrs", Separator = '.', HelpText = "Includes AVR Service in patch, and sets service version")]
    public IList<string> AvrsVersion { get; set; }

    [OptionList("avrscortege", Separator = '|', HelpText = "Specifies AVR Service cortege version")]
    public IList<string> AvrsCortege { get; set; }

    #endregion avrs

    #region e

    [OptionList("e", Separator = '.', HelpText = "Includes EIDSS Desktop in patch, and sets its version")]
    public IList<string> EVersion { get; set; }

    [OptionList("ecortege", Separator = '|', HelpText = "Specifies desktop cortege version")]
    public IList<string> ECortege { get; set; }

    #endregion e

    #region ns

    [OptionList("ns", Separator = '.', HelpText = "Includes Notification Service in patch, and sets its version")]
    public IList<string> NsVersion { get; set; }

    [OptionList("nscortege", Separator = '.', HelpText = "Specifies Notification Service cortege version")]
    public IList<string> NsCortege { get; set; }

    #endregion ns

    [HelpOption]
    public string GetUsage()
    {
      var help = HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));

      if (!LastParserState.Errors.Any())
      {
        return help;
      }

      var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
      if (!string.IsNullOrEmpty(errors))
      {
        help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
        help.AddPreOptionsLine(errors);
      }
      return help;
    }
  }
}