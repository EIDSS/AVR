namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Diagnostics;
  using System.IO;
  using Core.Enums;
  using Core.Helper;
  using Ionic.Zip;


  internal class UpdateAvrFilter : BaseTask
  {
    protected override bool ExecuteInternal()
    {
      var success = false;

      try
      {
        var globalList = GetGlobalLayoutV6IdList();
        AddInfoString("{0} global layouts need to be updated", globalList.Count);
        foreach (var layout in globalList)
        {
          AddInfoString("{0} - starting update", layout);

          if (layout.ZippedSettings != null && layout.ZippedSettings.Length > 0)
          {
            layout.Settings = Unzip(layout.ZippedSettings);
          }
          UpdateGlobalLayoutV6(layout);
          AddInfoString("{0} - update finished", layout);
        }


        var localList = GetLocalLayoutV6IdList();
        AddInfoString("{0} local layouts need to be updated", localList.Count);
        foreach (var layout in localList)
        {
          AddInfoString("{0} - starting update", layout);

          if (layout.ZippedSettings != null && layout.ZippedSettings.Length > 0)
          {
            layout.Settings = Unzip(layout.ZippedSettings);
          }
          UpdateLocalLayoutV6(layout);
          AddInfoString("{0} - update finished", layout);
        }

        success = true;
      }
      catch (Exception ex)
      {
        AddErrorString(GetFullError(ex));
      }
      return success;
    }

    private static void UpdateGlobalLayoutV6(LayoutDTO layout)
    {
      using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
      {
        if (null == conn)
        {
          return;
        }

        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = @"update	tasglLayout
                                    set		intPivotGridXmlVersion = 7,
                                        blbPivotGridSettings = @blbPivotGridSettings
                                    where	idfsLayout = @idfsLayout";
        cmd.Parameters.AddWithValue("idfsLayout", layout.Id);
        cmd.Parameters.AddWithValue("blbPivotGridSettings", layout.Settings ?? new byte[0]);
        cmd.ExecuteNonQuery();
      }
    }

    private static List<LayoutDTO> GetGlobalLayoutV6IdList()
    {
      using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
      {
        if (null == conn)
        {
          return new List<LayoutDTO>(0);
        }

        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = @"select	l.idfsLayout, 
                                        tr.strTextString,
                                        l.blbPivotGridSettings
    
                                    from	tasglLayout l
                                    inner join trtStringNameTranslation tr
                                    on l.idfsLayout = tr.idfsBaseReference
                                    and tr.idfsLanguage = 10049003
                                    where	l.intPivotGridXmlVersion = 6";
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          var result = new List<LayoutDTO>();
          while (reader.Read())
          {
            var layout = new LayoutDTO
            {
              Id = (long)reader["idfsLayout"],
              Name = reader["strTextString"] as string,
              ZippedSettings = reader["blbPivotGridSettings"] is byte[]
                ? (byte[])reader["blbPivotGridSettings"]
                : new byte[0]
            };

            result.Add(layout);
          }
          return result;
        }
      }
    }

    private static void UpdateLocalLayoutV6(LayoutDTO layout)
    {
      using (SqlConnection conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
      {
        if (null == conn)
        {
          return;
        }

        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = @"update	tasLayout
                                    set		intPivotGridXmlVersion = 7,
                                        blbPivotGridSettings = @blbPivotGridSettings
                                    where	idflLayout = @idflLayout";
        cmd.Parameters.AddWithValue("idflLayout", layout.Id);
        cmd.Parameters.AddWithValue("blbPivotGridSettings", layout.Settings ?? new byte[0]);
        cmd.ExecuteNonQuery();
      }
    }

    public override string GetName()
    {
      return "Update Avr filter";
    }

    public override Guid GetID()
    {
      return new Guid("{FFCD6445-B614-477F-8DA7-78B406D30EF9}");
    }

    private static List<LayoutDTO> GetLocalLayoutV6IdList()
    {
      using (var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbMain))
      {
        if (null == conn)
        {
          return new List<LayoutDTO>(0);
        }

        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"select	l.idflLayout, 
                                        tr.strTextString,
                                        l.blbPivotGridSettings
                                    from	tasLayout l
                                    inner join locStringNameTranslation tr
                                    on l.idflLayout = tr.idflBaseReference
                                    and tr.idfsLanguage = 10049003
                                    where	l.intPivotGridXmlVersion = 6";
        using (var reader = cmd.ExecuteReader())
        {
          var result = new List<LayoutDTO>();
          while (reader.Read())
          {
            var layout = new LayoutDTO
            {
              Id = (long)reader["idflLayout"],
              Name = reader["strTextString"] as string,
              ZippedSettings = reader["blbPivotGridSettings"] is byte[]
                ? (byte[])reader["blbPivotGridSettings"]
                : new byte[0]
            };

            result.Add(layout);
          }
          return result;
        }
      }
    }

    private static byte[] Unzip(byte[] sourceBuffer)
    {
      const string EntryName = "EntryName";
      using (Stream stream = new MemoryStream())
      {
        stream.Write(sourceBuffer, 0, sourceBuffer.Length);
        stream.Flush();
        stream.Seek(0, SeekOrigin.Begin);

        using (var zip = ZipFile.Read(stream))
        {
          var e = zip[EntryName];
          using (var outputStream = new MemoryStream())
          {
            e.Extract(outputStream);
            outputStream.Flush();
            outputStream.Seek(0, SeekOrigin.Begin);
            var uncompressedBuffer = new byte[outputStream.Length];
            var readed = outputStream.Read(uncompressedBuffer, 0, (int)outputStream.Length);
            Debug.Assert(outputStream.Length == readed, "not all bytes readed");
            return uncompressedBuffer;
          }
        }
      }
    }
  }
}
