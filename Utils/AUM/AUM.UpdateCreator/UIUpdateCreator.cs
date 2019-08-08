namespace AUM.UpdateCreator
{
  using System.Windows.Forms;


  internal sealed class UIUpdateCreator : IUpdateCreator
  {
    #region IUpdateCreator Members

    public int CreatePackage(PatchOptions options)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new FUpdateCreator());
      return 0;
    }

    #endregion
  }
}