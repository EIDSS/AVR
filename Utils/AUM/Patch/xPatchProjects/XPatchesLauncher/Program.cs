namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  using System.Text;
  using Core;
  using Core.Helper;


  internal static class Program
  {
    private static void Main(string [] args)
    {
      var errorMessage = string.Empty;
      var isSuccess = true;

      try
      {
        isSuccess = RunXPatches(GetWorkingPath(args));
      }
      catch (Exception exc)
      {
        isSuccess = false;
        errorMessage = errorMessage.Length > 0
          ? string.Format(CultureInfo.InvariantCulture, "{0}; {1}", errorMessage, exc.Message)
          : exc.Message;
        AddErrorString(errorMessage);
      }
      finally
      {
        var settings = new ConfigSettings(Path.Combine(FileHelper.GetExecutingPath(), FileHelper.BVUpdaterConfigFileName));
        FileHelper.WriteLogFile(
          UpdHelper.AUMPath,
          isSuccess,
          s_report.ToString(),
          "customtasks",
          "customtasks",
          settings.Level,
          errorMessage);
      }
    }

    private static bool RunXPatches(string workingPath)
    {
      s_tasks = ReadTasks(workingPath);
      if (s_tasks.Any())
      {
        return RunEachTask(workingPath);
      }
      AddReportString("No tasks to run");
      return true;
    }

    private static bool RunEachTask(string workingPath)
    {
      var result = s_tasks.Aggregate(true, (current, taskDetails) => current & RunTask(taskDetails, workingPath));
      AddReportString(result
        ? "All tasks completed successfully"
        : "Some tasks are not executed successfully");
      return result;
    }

    private static bool RunTask(TaskDetail taskDetails, string workingPath)
    {
      var task = LoadTask(taskDetails, workingPath);
      if (null == task)
      {
        throw new TypeLoadException(string.Format(
          CultureInfo.InvariantCulture,
          "Failed to instantiate type '{0}'!",
          taskDetails.Type));
      }

      return ExecuteTask(task);
    }

    private static ITask LoadTask(TaskDetail taskDetails, string workingPath)
    {
      var domain = AppDomain.CreateDomain(taskDetails.Type);
      var pathToDll = Path.Combine(workingPath, taskDetails.Dll);
      if (!File.Exists(pathToDll))
      {
        throw new FileNotFoundException(
          string.Format(
            CultureInfo.InvariantCulture,
            "Task assembly '{0}' not found!",
            pathToDll));
      }

      var task = domain.CreateInstanceFromAndUnwrap(pathToDll, taskDetails.Type) as ITask;
      return task;
    }

    private static string GetWorkingPath(IList<string> args)
    {
      if (!args.Any())
      {
        throw new ArgumentException("XPatch working path (temporary unpacked folder) was not passed to XPatchLauncher");
      }
      return args[0];
    }

    private static IList<TaskDetail> ReadTasks(string workingPath)
    {
      var tasksKey = new ExtendedConfiguration(XPatchConfigurationFile(workingPath)).AppSettings["Tasks"].Value;
      var tasks = string.IsNullOrEmpty(tasksKey)
        ? new List<TaskDetail>(0)
        : tasksKey.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(pair => pair.Split(new[] { ';' }, 2))
        .Select(splitted => new TaskDetail(splitted.First().Trim(), splitted.Last().Trim()))
        .ToList();
      return tasks;
    }

    private static string XPatchConfigurationFile(string workingPath)
    {
      // ReSharper disable AssignNullToNotNullAttribute
      return Path.Combine(workingPath, Path.GetFileName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
      // ReSharper restore AssignNullToNotNullAttribute
    }

    private static bool ExecuteTask(ITask task)
    {
      var taskName = task.GetName();
      var taskId = task.GetID();
      //TODO: method IsXpatchInstalled must be (partially) here
      if (HasTaskBeenAlreadyApplied(taskId))
      {
        AddReportString("Task <{0}> with ID <{1}> has already been executed. Task execution is skipped.", taskName, taskId);
        return true;
      }
      AddReportString("Task started: {0}", taskName);

      var success = task.Execute();
      
      AddTaskLogs(task);
      AddReportString("Task finished: {0}", taskName);
      AddReportString(" ");
      AddReportString("RESULT: {0}", success ? "SUCCESS" : "FAIL");
      AddReportString(" ");

      MarkXpatchSucceded(success, taskId, taskName);
      return success;
    }

    private static bool HasTaskBeenAlreadyApplied(Guid taskId)
    {
      return !Guid.Empty.Equals(taskId) && RegistryHelper.IsXpatchInstalled(taskId);
    }

    private static void MarkXpatchSucceded(bool success, Guid taskId, string taskName)
    {
      if (success)
      {
        //TODO: this method must be (partially) here
        RegistryHelper.MarkXpatchSucceded(taskId, taskName);
      }
    }

    private static void AddTaskLogs(ITask task)
    {
      foreach (var str in task.GetLog())
      {
        AddReportString(str);
      }
    }

    private static void AddReportString(string message, params object[] args)
    {
      var fullMessage = string.Format(CultureInfo.InvariantCulture, message, args);
      s_report.AppendLine(fullMessage);
      Console.WriteLine(fullMessage);
    }

    /// <summary>
    /// Сюда собираем лог
    /// </summary>
    private static readonly StringBuilder s_report = new StringBuilder();

    private static IList<TaskDetail> s_tasks;

    private static void AddErrorString(string message)
    {
      AddReportString(string.Format(CultureInfo.InvariantCulture, "Error: {0}", message));
    }

    private static string GetStartupPath()
    {
      return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }


    private class TaskDetail
    {
      internal string Type { get; private set; }

      internal string Dll { get; private set; }

      internal TaskDetail(string dll, string taskClass)
      {
        if (string.IsNullOrEmpty(dll))
        {
          throw new ArgumentNullException("taskClass");
        }
        if (string.IsNullOrEmpty(taskClass))
        {
          throw new ArgumentNullException("dll");
        }

        Dll = dll;
        Type = taskClass;
      }
    }
  }
}
