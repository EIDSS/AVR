namespace AUM.UpdateCreator
{
  internal static class UpdateCreatorFactory
  {
    internal static IUpdateCreator GetUpdateCreator(bool isQuiet)
    {
      return isQuiet ? (IUpdateCreator) new ConsoleUpdateCreator() : new UIUpdateCreator();
    }
  }
}