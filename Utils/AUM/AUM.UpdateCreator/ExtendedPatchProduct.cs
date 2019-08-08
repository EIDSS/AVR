namespace AUM.UpdateCreator
{
  using System;
  using System.Collections.Generic;
  using Core;


  internal class ExtendedPatchProduct : PatchProduct
  {
    internal ExtendedPatchProduct(IEnumerable<string> version, IEnumerable<string> cortege, IFileManager patchFileManager)
      : base(version, cortege)
    {
      if (null == patchFileManager)
      {
        throw new ArgumentNullException("patchFileManager");
      }
      FileManager = patchFileManager;
    }

    public ExtendedPatchProduct(bool isIncluded, IFileManager patchFileManager)
      : base(isIncluded)
    {
      if (null == patchFileManager)
      {
        throw new ArgumentNullException("patchFileManager");
      }
      FileManager = patchFileManager;
    }

    internal IFileManager FileManager { get; private set; }
  }

  internal interface IFileManager
  {
    List<IFile> Files { get; }
  }
}