namespace CustomActions.Utils.PropertyContainers
{
  internal interface IPropertyContainer
  {
    string this[string key] { get; set; }
  }
}