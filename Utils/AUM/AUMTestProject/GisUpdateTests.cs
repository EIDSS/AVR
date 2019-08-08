namespace AUMTestProject
{
  using System.IO;
  using System.Reflection;
  using AUM.Core.Helper;
  using AUM.XPatch;
  using Microsoft.VisualStudio.TestTools.UnitTesting;


  [TestClass]
  public class GisUpdateTests
  {
    private static string s_backup;
    private static string s_updateFilesPath;
    private static string s_basePath;

    [ClassInitialize]
    public static void PrepareGisUpdateFolder(TestContext context)
    {
      s_basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      s_updateFilesPath = Path.Combine(s_basePath, GisUpdate.UpdateFilesFolder);
      s_backup = Path.Combine(s_basePath, "TestGisUpdateBackup");

      if (!Directory.Exists(s_updateFilesPath))
      {
        return;
      }
      Directory.CreateDirectory(s_backup);
      FileHelper.CopyDirs(s_updateFilesPath, s_backup);
    }

    [TestCleanup]
    public void RestoreGisUpdateFolderAfterTest()
    {
      if (Directory.Exists(s_updateFilesPath))
      {
        Directory.Delete(s_updateFilesPath, true);
      }
      Directory.CreateDirectory(s_updateFilesPath);
      FileHelper.CopyDirs(s_backup, s_updateFilesPath);
    }

    [ClassCleanup]
    public static void RestoreGisUpdateFolder()
    {
      if (Directory.Exists(s_updateFilesPath))
      {
        Directory.Delete(s_updateFilesPath, true);
      }
      Directory.Move(s_backup, s_updateFilesPath);
    }

    [TestMethod]
    [DeploymentItem("UpdateFiles", "UpdateFiles")]
    public void TestGisUpdate1()
    {
      var tempDir = Path.Combine(s_basePath, "TestGisUpdateTemp");
      Directory.Move(s_updateFilesPath, tempDir);
      var result = new GisUpdate().Execute();
      Assert.AreEqual(false, result, "task can't be executed because upsate directory is absent");
      Directory.Delete(tempDir, true);
    }

    [TestMethod]
    [DeploymentItem("UpdateFiles", "UpdateFiles")]
    public void TestGisUpdate2()
    {
      File.Move(Path.Combine(s_updateFilesPath, GisUpdate.ScriptName), Path.Combine(s_updateFilesPath, "tmp.sql"));
      var result = new GisUpdate().Execute();
      Assert.AreEqual(false, result, "task can't be executed because sql script is absent");
    }

    [TestMethod]
    [DeploymentItem("UpdateFiles", "UpdateFiles")]
    public void TestGisUpdate3()
    {
      File.WriteAllText(Path.Combine(s_updateFilesPath, GisUpdate.ScriptName), "raiserror ('Script isn't installed', 16, 1)");
      var result = new GisUpdate().Execute();
      Assert.AreEqual(false, result, "task can't be executed because sql script contains error");
    }

    [TestMethod]
    [DeploymentItem("UpdateFiles", "UpdateFiles")]
    public void TestGisUpdate4()
    {
      File.Delete(Path.Combine(s_updateFilesPath, GisUpdate.ScriptName));
      File.Move(Path.Combine(s_updateFilesPath, GisUpdate.GisUpdateUtility), Path.Combine(s_updateFilesPath, "gis_update_tmp.exe"));
      var result = new GisUpdate().Execute();
      Assert.AreEqual(false, result, "task can't be executed because gis update utility is absent");
    }

    [TestMethod]
    [DeploymentItem("UpdateFiles", "UpdateFiles")]
    [ExpectedException(typeof(AssertFailedException))]
    public void TestGisUpdate5()
    {
      if (!new GisUpdate().Execute())
      {
        throw new AssertFailedException("task shall be executed successfully");
      }
    }
  }
}
