namespace CustomActions.Utils.PropertyContainers
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;


  public sealed class CustomActionDataWrapper : IPropertyContainer
  {
    private readonly CustomActionData m_customActionData;

    public CustomActionDataWrapper(CustomActionData customActionData)
    {
      if (null == customActionData)
      {
        throw new ArgumentNullException("customActionData");
      }

      m_customActionData = customActionData;
    }

    public string this[string key]
    {
      get { return m_customActionData[key]; }
      set { throw new NotSupportedException("The CustomActionDataWrapper class doesn't support property setting!"); }
    }
  }
}