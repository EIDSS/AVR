// dbf library (sf.net/projects/dbase)
// License: zlib (opensource.org/licenses/zlib-license.php)

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FlatDatabase
{
  public class ColumnInfo
  {
    public string Name = string.Empty;
    public Type DataType = null;
    public int Length = 0;
    public int DecCount = 0;
  }
  
   public interface IOpenClose
   {
      bool IsOpen { get; }
      void Close();
   }

   public interface Interface : IOpenClose
   {
      string Filename { get; }
      string Fileext { get; }
      bool Open(string filename, FileMode mode);
      bool Create(string filename, ColumnInfo[] array);
      long Position { get; set; }
      void Clear();
      bool AppendRecord();
      bool SaveRecord();
      void Flush();
      long RecordCount { get; }
      string GetString(ColumnInfo field);
      List<ColumnInfo> Columns { get; }
      bool WriteField(ColumnInfo field, string str);
      bool WriteField(ColumnInfo field, char ch);
      bool WriteField(ColumnInfo field, int n);
      bool WriteField(ColumnInfo field, DateTimeOffset datetime);
      bool WriteField(ColumnInfo field, bool b);
      bool WriteField(ColumnInfo field, double n);
      System.Text.Encoding TextEncoding { get; set; }
   }
 }

/// <summary>
/// Driverless dbf access
/// </summary>
namespace FlatDatabase.DBase
{
#region Definitions
   public static class Const
   {
      public const int Pack = 1;
      public const int MemoBlockLen = 512;
      public const int MemoBlockTermLen = 2;
      public static int DefaultHeaderLen { get; private set; }
      public static int DefaultFieldLen { get; private set; }
      public const string DataTypes = "CNFDCCML";
      public const char CPM_TEXT_TERMINATOR = '\x1A';
      public const char FieldTerminator = '\r';
      public const int FieldTerminatorLen = 1;
      public const char FieldFillChar = ' ';
      public const char RecordDeletedMarker = '*';
      public const int FieldNameLen = 10;
      public const int FileTitleLen = 8;
      public const int MAGIC_DBASE3      = 0x03;
      public const int MAGIC_DBASE3_MEMO = 0x83;
      public const int MAGIC_DBASE3_MEMO_2 = 0x8B;
      public const int MAGIC_DBASE4 = 0x04;
      public const int MAGIC_DBASE4_MEMO = 0x84;
      public const int MAGIC_FOXPRO      = 0x30;
      public const int MAGIC_DBASE_DEFAULT = MAGIC_DBASE3;
      public const int MAGIC_DBASE_DEFAULT_MEMO = MAGIC_DBASE3_MEMO;
      public const int EnumeratorDefault = -1;
      public const string FileExt = "dbf";
      public const string FileExtMemo = "dbt";
      public const int RECORD_POS_DELETED = 0;
      public const int RECORD_POS_DATA = 1;
      public const string VersionString = "dbf library svn r202";

      static Const()
      {
         DefaultHeaderLen = Marshal.SizeOf(typeof(DBF_FILEHEADER_3));
         DefaultFieldLen  = Marshal.SizeOf(typeof(DBF_FILEFIELD_3));
      }

      public static void StructCheck<T>(int size_desired)
      {
         int size = Marshal.SizeOf(typeof(T));
         if (size != size_desired)
         {
            throw new Exception(string.Format("Size of struct {0} is wrong ({1} != {2})", typeof(T), size, size_desired));
         }
      }

      public static void StructCheck()
      {
         StructCheck<DBF_FILEHEADER_TIME>(3);
         StructCheck<DBF_FILEHEADER_3>(32);
         StructCheck<DBF_FILEHEADER_4>(68);
         StructCheck<DBT_FILEHEADER>(MemoBlockLen);
         StructCheck<DBF_FILEFIELD_3>(32);
         StructCheck<DBF_FILEFIELD_4>(48);
      }
   }

   [StructLayout(LayoutKind.Sequential, Pack = Const.Pack)]
   internal struct DBF_FILEHEADER_TIME
   {
      public Byte yy;
      public Byte mm;
      public Byte dd;
   }

   [StructLayout(LayoutKind.Sequential, Pack = Const.Pack)]
   internal struct DBF_FILEHEADER_3
   {
      public Byte version;
      public DBF_FILEHEADER_TIME lastupdate;
      public UInt32 recordcount;
      public UInt16 headerlength;
      public UInt16 recordlength;
      public UInt16 unused_0;
      public Byte incomplete;
      public Byte crypt;

      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      public Byte[] unused;
   }

   [StructLayout(LayoutKind.Sequential, Pack = Const.Pack)]
   internal struct DBF_FILEHEADER_4
   {
      public Byte version;
      public DBF_FILEHEADER_TIME lastupdate;
      public UInt32 recordcount;
      public UInt16 headerlength;
      public UInt16 recordlength;
      public UInt16 unused_0;
      public Byte incomplete;
      public Byte crypt;

      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      public Byte[] unused_1;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
      public Byte[] unused_2;
   }

   [StructLayout(LayoutKind.Sequential, Pack = Const.Pack)]
   internal struct DBT_FILEHEADER
   {
      public UInt32 next;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public Byte[] unused0;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = Const.FileTitleLen)]
      public Byte[] title; // char array really, only not zeroterminated
      public Byte flag;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
      public Byte[] unused1;
      public UInt16 blocksize;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = Const.MemoBlockLen - 22)]
      public Byte[] unused2;
   }

   [StructLayout(LayoutKind.Sequential, Pack = Const.Pack)]
   internal struct DBF_FILEFIELD_3
   {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Const.FieldNameLen + 1)] // zero term
      public string title;
      public char type;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public Byte[] unused0;
      public Byte length;
      public Byte deccount;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
      public Byte[] unused1;
   }
   
   [StructLayout(LayoutKind.Sequential, Pack = Const.Pack)]
   internal struct DBF_FILEFIELD_4
   {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Const.FieldNameLen + 1)] // zero term
      public string title;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
      public Byte[] unused0;
      public char type;
      public Byte length;
      public Byte deccount;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
      public Byte[] unused1;
   }

   public enum DataType
   {
      Char,
      Integer,
      Float,
      Date,
      Time,  /* non standard */
      DateTime, /* non standard */
      Memo,
      Boolean,
      EnumCount,
      Logical = Boolean,
      Unknown = -1,
      Any = -2
   }

#endregion Definitions

#region Convert
   public static class Convert
   {
      public static class Time
      {
         /// <summary>
         /// time_t/__time64_t is Unix UTC time, seconds since 1970.1.1
         /// </summary>
         public static readonly DateTime OffsetTimeT = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
         public static Int64 TimeT(DateTimeOffset time)
         {
            Int64 time_t = System.Convert.ToInt64((time - OffsetTimeT).TotalSeconds);
            return time_t;
         }
         public static DateTimeOffset TimeT(Int64 time_t, int ms)
         {
            DateTimeOffset time = OffsetTimeT.AddSeconds(time_t);
            return time.AddMilliseconds(ms);
         }
      }

      public static Type Type(DataType datatype)
      {
        Type type;
        switch (datatype)
        {
          case DataType.Date:
            type = typeof(DateTimeOffset);
            break;
          case DataType.Float:
            type = typeof(double);
            break;
          case DataType.Integer:
            type = typeof(int);
            break;
          case DataType.Boolean:
            type = typeof(bool);
            break;
          case DataType.Memo:
            type = typeof(byte[]);
            break;
          case DataType.Char:
          default:
            type = typeof(string);
            break;
        }
        return type;
      }

      public static DataType Type(Type type, int Length)
      {
        DataType DataType;
        if (type == typeof(DateTimeOffset))
        {
          DataType = DataType.Date;
        }
        else if (type == typeof(bool))
        {
          DataType = DataType.Boolean;
        }
        else if ((type == typeof(float))
                 || (type == typeof(double))
                )
        {
          DataType = DataType.Float;
        }
        else if (   (type == typeof(byte))
                 || (type == typeof(sbyte))
                 || (type == typeof(Int16))
                 || (type == typeof(Int32))
                 || (type == typeof(Int64))
                 || (type == typeof(UInt16))
                 || (type == typeof(UInt32))
                 || (type == typeof(UInt64))
                )
        {
          DataType = DataType.Integer;
        }
        else if (type == typeof(byte[]))
        {
          DataType = DataType.Memo;
        }
        else if ((type == typeof(string))
                 || (type == typeof(char))
                )
        {
          if (Length <= 255)
          {
            DataType = DataType.Char;
          }
          else
          {
            Length = 10;
            DataType = DataType.Memo;
          }
        }
        else
        {
          throw new Exception("Unknown type");
        }
        return DataType;
      }
   }
#endregion Convert

#region Test
   public static class Test
   {
      public static bool CreateDatabase(string filename)
      {
         var columns = new ColumnInfo[]
         { 
            new ColumnInfo() { Name="TITLE"  , DataType=typeof(string), Length= 5 },
            new ColumnInfo() { Name="INTEGER", DataType=typeof(int), Length=10 },
            new ColumnInfo() { Name="BOOLEAN", DataType=typeof(bool), Length= 1 },
            new ColumnInfo() { Name="DATE"   , DataType=typeof(DateTimeOffset)   , Length= 8 },
            new ColumnInfo() { Name="FLOAT"  , DataType=typeof(float), Length=10, DecCount = 5 },
            new ColumnInfo() { Name="MEMO"   , DataType=typeof(byte[]), Length=10 },
         };
         var file = new DBase.File();
         bool ok = file.Create(filename, columns);
         if (ok)
         {
            file.AppendRecord();
            file.WriteField(columns[0], "sjov1");
            file.WriteField(columns[1], 10);
            file.WriteField(columns[2], true);
            file.WriteField(columns[3], DateTimeOffset.UtcNow);
            file.WriteField(columns[4], 11.1);
            file.WriteField(columns[5], "memo1");
            file.SaveRecord();

            file.AppendRecord();
            file.WriteField(columns[0], "sjov2");
            file.WriteField(columns[1], 20);
            file.WriteField(columns[2], false);
            file.WriteField(columns[3], DateTimeOffset.UtcNow);
            file.WriteField(columns[4], 22.2);
            file.WriteField(columns[5], "memo2");
            file.SaveRecord();

            file.Close();
         }
         return ok;
      }
   }
#endregion Test

#region Utility

   public static class Utility
   {
      public static T PtrToStructure<T>(byte[] bytes)
      {
         GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
         T structure = (T)Marshal.PtrToStructure(pinned.AddrOfPinnedObject(), typeof(T));
         pinned.Free();
         return structure;
      }

      public static byte[] StructureToPtr<T>(T anything)
      {
         int rawsize = Marshal.SizeOf(typeof(T));
         byte[] rawdata = new byte[rawsize];
         GCHandle handle = GCHandle.Alloc(rawdata, GCHandleType.Pinned);
         Marshal.StructureToPtr(anything, handle.AddrOfPinnedObject(), false);
         handle.Free();
         return rawdata;
      }
   }
#endregion Utility

   /// <summary>
   /// dbf file class
   /// </summary>
   public class File : Interface, IDisposable
   {
#region Memo
      private class MemoFile
      {
         public Stream _Stream = null;
         public string Title;
         private const long FirstBlock = 1;
         private long Next = FirstBlock;
         private byte[] _Buf = new byte[Const.MemoBlockLen];
         private File File;

         public MemoFile(File file)
         {
           File = file;
         }
         public static string CreateFileName(string filename)
         {
            return Path.ChangeExtension(filename, FlatDatabase.DBase.Const.FileExtMemo);
         }

         private byte[] m_buf_read = new byte[64 * 1024];

         public string Read(long pos)
         {
            _Stream.Seek(pos * Const.MemoBlockLen, SeekOrigin.Begin);
            string str = string.Empty;
            for (;;)
            {
               int i; 
               int read = _Stream.Read(m_buf_read, 0, m_buf_read.Length);

               for (i = 0; i < read; i++)
               {
                  char c = (char)m_buf_read[i];
                  if (c == Const.CPM_TEXT_TERMINATOR)
                  {
                     break;
                  }
               }
               if (i == 0)
               {
                  break;
               }
               str+= File.TextEncoding.GetString(m_buf_read, 0, i);
               if (read < m_buf_read.Length)
               {
                  break;
               }
            }
            return str;
         }

         public long Write(string str)
         {
            long pos = Next;
            _Stream.Seek(pos * Const.MemoBlockLen, SeekOrigin.Begin);
            str += new string(Const.CPM_TEXT_TERMINATOR, Const.MemoBlockTermLen); // term
            byte[] bytes = File.TextEncoding.GetBytes(str);
            _Stream.Write(bytes, 0, bytes.GetLength(0));
            Next +=    (bytes.GetLength(0) / Const.MemoBlockLen)
                   + (((bytes.GetLength(0) % Const.MemoBlockLen) != 0) ? 1 : 0);
            return pos;
         }

         public bool ReadHeader()
         {
            int len = Marshal.SizeOf(typeof(DBT_FILEHEADER));
            byte[] bytes = new byte[len];

            bool ok = (len == _Stream.Read(bytes, 0, len));
            if (ok)
            {
               DBT_FILEHEADER header = Utility.PtrToStructure<DBT_FILEHEADER>(bytes);
               Next = header.next;
            }
            return ok;
         }

         public void WriteHeader()
         {
            _Stream.Seek(0, SeekOrigin.Begin);
            string title = Title;
            if (title.Length > Const.FileTitleLen) title = title.Substring(0, Const.FileTitleLen);
            else while (title.Length < Const.FileTitleLen) title += Const.FieldFillChar;
            DBT_FILEHEADER header = new DBT_FILEHEADER();
            header.next = (uint)Next;
            header.title = File.TextEncoding.GetBytes(title);
            header.flag = 0;
            header.blocksize = Const.MemoBlockLen;
            byte[] bytes = Utility.StructureToPtr<DBT_FILEHEADER>(header);
            _Stream.Write(bytes, 0, bytes.GetLength(0));
         }

         public void Clear()
         {
           Next = FirstBlock;
         }
      }
#endregion Memo

      public System.Text.Encoding TextEncoding { get; set; }
      
      private MemoFile _MemoFile;
      private Stream _Stream = null;

      public string Filename { get; private set; }
      public string Fileext { get { return Const.FileExt; } }
      public string TableName { get { return System.IO.Path.GetFileNameWithoutExtension(Filename); } }
      public bool IsOpen { get { return (_Stream != null); } }
      public bool HasMemo { get { return (_MemoFile._Stream != null); } }

      public List<ColumnInfo> Columns { get; private set; }

      public bool IsEditable { get { return (_Stream != null) && _Stream.CanWrite; } }
      public bool IsDirty { get; private set; }

      static File()
      {
         Const.StructCheck();
      }

      public File()
      {
         IsDirty = false;
         Columns = new List<ColumnInfo>();
         TextEncoding = System.Text.Encoding.Default;
         _MemoFile = new MemoFile(this);
      }

      private bool m_Disposed;
      public void Dispose()
      {
          if (!m_Disposed)
          {
              m_Disposed = true; 
              if (IsOpen)
                  Close();
              GC.SuppressFinalize(this);
          }
      }

      ~File()
      {
          Dispose();
      }

      private static bool sanity_check(DBF_FILEHEADER_3 header)
      {
         bool ok =    ((header.lastupdate.mm >= 1) && (header.lastupdate.mm <= 12))
                   && ((header.lastupdate.dd >= 1) && (header.lastupdate.dd <= 31))
                   ;
         return ok;
      }

      private static bool sanity_check(DBF_FILEHEADER_4 header)
      {
         bool ok = ((header.lastupdate.mm >= 1) && (header.lastupdate.mm <= 12))
                   && ((header.lastupdate.dd >= 1) && (header.lastupdate.dd <= 31))
                   ;
         return ok;
      }

      public bool Attach(Stream stream, string filename, bool read_header)
      {
         bool ok = (stream != null);
         if (ok && read_header)
         {
            byte[] bytes = new byte[Marshal.SizeOf(typeof(Byte))];
            ok = (bytes.Length == StreamRead(stream, bytes));
            if (ok)
            {
               Byte version = bytes[0];
               int len_header;
               int len_field;

               switch (version)
               {
                  case Const.MAGIC_DBASE4:
                  case Const.MAGIC_DBASE4_MEMO:
                     len_header = Marshal.SizeOf(typeof(DBF_FILEHEADER_4));
                     len_field = Marshal.SizeOf(typeof(DBF_FILEFIELD_4));
                     break;
                  case Const.MAGIC_DBASE3:
                  case Const.MAGIC_DBASE3_MEMO:
                  case Const.MAGIC_DBASE3_MEMO_2:
                  case Const.MAGIC_FOXPRO:
                  default:
                     len_header = Marshal.SizeOf(typeof(DBF_FILEHEADER_3));
                     len_field = Marshal.SizeOf(typeof(DBF_FILEFIELD_3));
                     break;
               }

               bytes = new byte[len_header];
               StreamSeek(stream, 0);

               ok = (len_header == StreamRead(stream, bytes));
               if (ok)
               {
                  switch (version)
                  {
                     case Const.MAGIC_DBASE4:
                     case Const.MAGIC_DBASE4_MEMO:
                     {
                        DBF_FILEHEADER_4 header = Utility.PtrToStructure<DBF_FILEHEADER_4>(bytes);
                        _RecordCount = header.recordcount;
                        RecordLength = header.recordlength;
                        HeaderLength = header.headerlength;
                        ok = sanity_check(header);
                        break;
                     }
                     case Const.MAGIC_DBASE3:
                     case Const.MAGIC_DBASE3_MEMO:
                     case Const.MAGIC_DBASE3_MEMO_2:
                     case Const.MAGIC_FOXPRO:
                     default:
                     {
                        DBF_FILEHEADER_3 header = Utility.PtrToStructure<DBF_FILEHEADER_3>(bytes);
                        _RecordCount = header.recordcount;
                        RecordLength = header.recordlength;
                        HeaderLength = header.headerlength;
                        ok = sanity_check(header);
                        break;
                     }
                  }
                  if (ok)
                  {
                     if ((RecordCount == 0) && (RecordLength != 0))
                     {
                        _RecordCount = (stream.Length - HeaderLength) / RecordLength;
                     }

                     int fieldcount = (HeaderLength - (len_header + 1)) / len_field;

                     bytes = new byte[len_field];

                     for (int i = 0; i < fieldcount; i++)
                     {
                        ColumnInfo field;

                        StreamRead(stream, bytes);
                        if ((bytes[0] >= 0) && (bytes[0] <= (byte)' '))
                        {
                           break;
                        }
                        switch (version)
                        {
                           case Const.MAGIC_DBASE4:
                           case Const.MAGIC_DBASE4_MEMO:
                           {
                              DBF_FILEFIELD_4 item = Utility.PtrToStructure<DBF_FILEFIELD_4>(bytes);
                              DataType type = (DataType)Const.DataTypes.IndexOf(item.type);
                              field = new ColumnInfo() { Name = item.title, DataType = Convert.Type(type), Length = item.length, DecCount = item.deccount };
                              break;
                           }
                           case Const.MAGIC_DBASE3:
                           case Const.MAGIC_DBASE3_MEMO:
                           case Const.MAGIC_DBASE3_MEMO_2:
                           case Const.MAGIC_FOXPRO:
                           default:
                           {
                              DBF_FILEFIELD_3 item = Utility.PtrToStructure<DBF_FILEFIELD_3>(bytes);
                              DataType type = (DataType)Const.DataTypes.IndexOf(item.type);
                              field = new ColumnInfo() { Name = item.title, DataType = Convert.Type(type), Length = item.length, DecCount = item.deccount };
                              break;
                           }
                        }
                        Columns.Add(field);
                     }
                  }
               }
            }
         }
         if (ok)
         {
           _Stream = stream;
           Filename = filename;
         }
         return ok;
      }

      public bool AttachMemo(Stream stream, string filename)
      {
         _MemoFile._Stream = stream;
         _MemoFile.Title = Path.GetFileNameWithoutExtension(filename);
         return _MemoFile.ReadHeader();
      }

      public void WriteHeader()
      {
         StreamSeek(_Stream, 0);

         DBF_FILEHEADER_3 header = new DBF_FILEHEADER_3();

         header.headerlength = (ushort)HeaderLength;
         header.crypt = 0;
         header.incomplete = 0;

         DateTimeOffset now = DateTimeOffset.UtcNow;

         header.lastupdate.yy = (byte)(now.Year - 1900);
         header.lastupdate.mm = (byte)now.Month;
         header.lastupdate.dd = (byte)now.Day;
         header.recordcount = (ushort)RecordCount;
         header.recordlength = (ushort)RecordLength;
         header.version = (byte)(HasMemo ? Const.MAGIC_DBASE_DEFAULT_MEMO : Const.MAGIC_DBASE_DEFAULT);
         header.unused_0 = 0;
         for (int i = 0; i < 16; i++)
         {
           //header.unused[i] = 0;
         }
         byte[] bytes = Utility.StructureToPtr<DBF_FILEHEADER_3>(header);
         StreamWrite(_Stream, bytes);
         StreamSeek(_Stream, HeaderLength + RecordCount * RecordLength);

         bytes = new byte[] { (byte)Const.CPM_TEXT_TERMINATOR };
         StreamWrite(_Stream, bytes);

         if (HasMemo)
         {
            _MemoFile.WriteHeader();
         }
      }
      
      public void Detach(out Stream stream, out Stream memostream)
      {
         if (IsDirty)
         {
            WriteHeader();
         }
         stream = _Stream;
         memostream = _MemoFile._Stream;
         _Stream = _MemoFile._Stream = null;
         Filename = string.Empty;
         IsDirty = false;
      }

      public bool Open(string filename, FileMode mode)
      {
         FileAccess access = (mode == FileMode.Open)
           ? FileAccess.Read      // non-exclusive
           : FileAccess.ReadWrite; // exclusive
         var stream = new FileStream(filename, mode, access);
         bool ok = (stream != null);
         if (ok)
         {
            ok = Attach(stream, filename, true);
            if (ok)
            {
               bool memo = false;
               foreach (ColumnInfo item in Columns)
               {
                  memo = memo || (Convert.Type(item.DataType, item.Length) == DataType.Memo);
               }
               if (memo)
               {
                  string filename_memo = MemoFile.CreateFileName(filename);
                  if (System.IO.File.Exists(filename_memo))
                  {
                     var stream_memo = new FileStream(filename_memo, mode, access);
                     ok = (stream_memo != null);
                     if (ok)
                     {
                        ok = AttachMemo(stream_memo, filename_memo);
                     }
                  }
                  if (!ok)
                  {
                     Close();
                  }
               }
            }
            else
            {
               stream.Close();
            }
         }
         return ok;
      }

      public bool Create(string filename, ColumnInfo[] array)
      {
         var list = new List<ColumnInfo>();
         foreach (ColumnInfo item in array)
         {
            list.Add(item);
         }
         return Create(filename, list);
      }

      public bool Create(string filename, List<ColumnInfo> fields, Stream stream = null, Stream stream_memo = null)
      {
         FileMode mode = FileMode.Create;
         FileAccess access = FileAccess.ReadWrite; // exclusive
         string filename_memo = string.Empty;
         bool memo = false;
         foreach (ColumnInfo item in fields)
         {
            memo = memo || (Convert.Type(item.DataType, item.Length) == DataType.Memo);
         }
          if(stream == null)
            stream = new FileStream(filename, mode, access);
         bool ok = (stream != null);

         if (ok && memo)
         {
            filename_memo = MemoFile.CreateFileName(filename);
             if(stream_memo == null)
                stream_memo = new FileStream(filename_memo, mode, access);
            ok = (stream_memo != null);
         }
         if (ok)
         {
            byte[] bytes;

            ok = Attach(stream, filename, false);
            if (ok)
            {
               HeaderLength = Const.DefaultHeaderLen + Const.FieldTerminatorLen + Const.DefaultFieldLen * fields.Count;
               IsDirty = true;
               stream.SetLength(HeaderLength);
               StreamSeek(stream, Const.DefaultHeaderLen);
               Columns = fields;

               RecordLength = Const.RECORD_POS_DATA;
               foreach (ColumnInfo item in fields)
               {
                  DBF_FILEFIELD_3 field = new DBF_FILEFIELD_3();
                  if (item.Name.Length > Const.FieldNameLen) throw new Exception("Name too long");
                  field.title = item.Name;
                  field.type = Const.DataTypes[(int)Convert.Type(item.DataType, item.Length)];
                  field.length = (byte)item.Length;
                  field.deccount = (byte)item.DecCount;
                  bytes = Utility.StructureToPtr<DBF_FILEFIELD_3>(field);
                  StreamWrite(stream, bytes);
                  RecordLength += item.Length;
               }
               bytes = new byte[] { (byte)Const.FieldTerminator };
               StreamWrite(stream, bytes);
            }
            if (stream_memo != null)
            {
               AttachMemo(stream_memo, filename_memo);
            }
         }
         return ok;
      }

      public void Close()
      {
         Stream stream;
         Stream memostream;
         Detach(out stream, out memostream);
         if (stream != null)
         {
             stream.Close();
             stream.Dispose();
         }
         if (memostream != null)
         {
             memostream.Close();
             memostream.Dispose();
         }
         Columns.Clear();
         _RecordCount = 0;
         RecordLength = 0;
         _Position = Const.EnumeratorDefault;
      }

      public void Flush()
      {
         WriteHeader();
         _Stream.Flush();
         if (HasMemo)
         {
            _MemoFile._Stream.Flush();
         }
      }

      private int StreamRead(Stream stream, byte[] bytes)
      {
         return stream.Read(bytes, 0, bytes.GetLength(0));
      }
      private void StreamWrite(Stream stream, byte[] bytes)
      {
         stream.Write(bytes, 0, bytes.GetLength(0));
      }
      private long StreamSeek(Stream stream, long offset)
      {
         return stream.Seek(offset, SeekOrigin.Begin);
      }      

      private string _RecordBuf = null;
      private long _Position = Const.EnumeratorDefault;
      public long Position
      {
         get
         { 
            return _Position;
         }
         set
         {
            if (value >= RecordCount)
            {
               //throw new Exception("Out of range");
            }
            if (_Position != value)
            {
               _Position = value;
               ReadRecord();
            }
         }
      }

      private void CheckEditable()
      {
        if (!IsEditable) throw new Exception("Table is read only");
      }

      private long _RecordCount = 0;
      public long RecordCount { get { return _RecordCount; } }
      public int RecordLength { get; private set; }
      private int HeaderLength { get; set; }

      public void Clear()
      {
        CheckEditable();
        _RecordCount = 0;
        _Position = Const.EnumeratorDefault;
        _MemoFile.Clear();
      }

      public bool AppendRecord()
      {
         _Position = RecordCount;
         _RecordBuf = new string(Const.FieldFillChar, RecordLength);
         _RecordCount++;
         IsDirty = true;
         return SaveRecord();
      }

      public bool SaveRecord()
      {
         if ((_Position + 1) < RecordCount) // if not appending
         {
            foreach (ColumnInfo item in Columns)
            {
               if (GetString(item).Length > (Const.MemoBlockLen - Const.MemoBlockTermLen))
               {
                  // if the memo string to be stored inside an existing record cannot fit inside one existing block:
                  // bail out instead of appending to the dbt file, as this leaves dead blocks inside it.
                  // -> Clear() and rewrite entire file instead.
                  return false;
               }
            }
         }

         StreamSeek(_Stream, HeaderLength + _Position * RecordLength);
         byte[] bytes = TextEncoding.GetBytes(_RecordBuf);
         StreamWrite(_Stream, bytes);
         IsDirty = true;
         return true;
      }

      private bool ReadRecord()
      {
         StreamSeek(_Stream, HeaderLength + _Position * RecordLength);
         byte[] bytes = new byte[RecordLength];
         StreamRead(_Stream, bytes);
         _RecordBuf = TextEncoding.GetString(bytes, 0, RecordLength);
         return true;
      }

      public bool WriteField(ColumnInfo field, string str)
      {
         switch (Convert.Type(field.DataType, field.Length))
         {
            case DataType.Memo:
            {
               string fmt = "{0:" + new string('0', field.Length) + "}";
               str = string.Format(fmt, _MemoFile.Write(str));
               break;
            }
         }
         int pos = GetRecordBufPos(field);
         string temp = str;
         while (temp.Length < field.Length) temp += Const.FieldFillChar;
         _RecordBuf = _RecordBuf.Remove(pos, field.Length);
         _RecordBuf = _RecordBuf.Insert(pos, temp);
         return true;
      }

      public bool WriteField(ColumnInfo field, char ch)
      {
         return WriteField(field, new string(new char[] { ch } ));
      }

      public bool WriteField(ColumnInfo field, int n)
      {
         return WriteField(field, n.ToString());
      }

      public bool WriteField(ColumnInfo field, DateTimeOffset date)
      {
         string str = string.Format("{0:0000}{1:00}{2:00}", date.Year, date.Month, date.Day);
         return WriteField(field, str);
      }

      public bool WriteField(ColumnInfo field, bool b)
      {
         return WriteField(field, b ? "T" : "F");
      }

      public bool WriteField(ColumnInfo field, double n)
      {
         string fmt = "{0:0";
         if (field.DecCount != 0)
         {
            fmt += "." + new string('0', field.DecCount);
         }
         fmt += "}";
         string str = string.Format(fmt, n);
         str = str.Replace(',', '.');
         return WriteField(field, str);
      }

      private int GetRecordBufPos(ColumnInfo field)
      {
         int pos = Const.RECORD_POS_DATA;
         foreach (ColumnInfo item in Columns)
         {
            if (item == field) break;
            pos += item.Length;
         }
         return pos;
      }

      public bool IsRecordDeleted
      {
         get
         {
            return (Const.RecordDeletedMarker == _RecordBuf[Const.RECORD_POS_DELETED]);
         }
         set
         {
            if (!IsEditable) throw new Exception("Table is read only");
            _RecordBuf = new string(new char[] { value ? Const.RecordDeletedMarker : Const.FieldFillChar} )
                        + _RecordBuf.Substring(Const.RECORD_POS_DELETED + 1);
         }
      }

      private static char[] _FieldDataTrim = new char[] { Const.FieldFillChar, '\0' };
      public string GetString(ColumnInfo field)
      {
         int pos = GetRecordBufPos(field);
         string str = _RecordBuf.Substring(pos, field.Length);
         str = str.TrimEnd(_FieldDataTrim);
         switch (Convert.Type(field.DataType, field.Length))
         {
            case DataType.Memo:
               if (_MemoFile._Stream != null)
               {
                  str = _MemoFile.Read(long.Parse(str));
               }
               else
               {
                  str = string.Empty;
               }
               break;
         }
         return str;
      }

      public object GetData(ColumnInfo field)
      {
         object obj = null;
         string str = GetString(field);
         switch (Convert.Type(field.DataType, field.Length))
         {
            case DataType.Char:
               obj = str;
               break;
            case DataType.Integer:
            {
               long n = 0;
                double d;
                if (double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out d))
                   obj = (int)d;
               break;
            }
            case DataType.Float:
            {
               double n = 0;
               if(double.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out n))
                    obj = n;
               break;
            }
            case DataType.Date:
            {
                if (string.IsNullOrEmpty(str))
                    return null;
               DateTimeOffset n = new DateTimeOffset(
                  int.Parse(str.Substring(0, 4)), 
                  int.Parse(str.Substring(4, 2)), 
                  int.Parse(str.Substring(6, 2)),
                  0,0,0, DateTimeOffset.Now.Offset
                  );
               obj = n;
               break;
            }
            case DataType.Boolean:
            {
               bool b = (-1 != str.IndexOfAny("YyTt".ToCharArray()));
               obj = b;
               break;
            }
            case DataType.Memo:
            {
               obj = str;
               break;
            }
         }
         return obj;
      }

   }

   #region Recordset
   // Adds a richer "syntactical sugar" api to File, supporting foreach
   public class Recordset : File, IEnumerable, IEnumerator
   {
      private Record _Record;

      public Recordset()
      {
         _Record = new Record(this);
      }

      #region IEnumerable Members
      public IEnumerator GetEnumerator()
      {
         return this;
      }
      #endregion

      #region IEnumerator Members
      public object Current { get { return _Record; } }

      public bool MoveNext()
      {
         _Record.Reset();
         Position++;
         return (Position < RecordCount);
      }

      public void Reset()
      {
         Position = Const.EnumeratorDefault;
      }
      #endregion

/*
   #region ToString
      public override String ToString()
      {
         return ToString(null, null);
      }
      public string ToString(string format, IFormatProvider formatProvider)
      {
         return string.Format(formatProvider, "{0}",
            Position);
         //(_Field != null) ? _Field.String : "");
      }
      #endregion ToString
   */
   }

   public class Record : IEnumerable, IEnumerator
   {
      public Recordset Recordset { get; private set; }
      private Column _Column;
      public int ColumnPosition { get; set; }
      public Record(Recordset recordset)
      {
         Recordset = recordset;
         _Column = new Column(this);
         Reset();
      }
      
      #region IEnumerable Members
      public IEnumerator GetEnumerator()
      {
         return this;
      }
      #endregion

      #region IEnumerator Members
      public object Current { get { return _Column; } }

      public bool MoveNext()
      {
         ColumnPosition++;
         return (ColumnPosition < Recordset.Columns.Count);
      }

      public void Reset()
      {
         ColumnPosition = Const.EnumeratorDefault;
      }
      #endregion
/*
   #region ToString
      public override String ToString()
      {
         return ToString(null, null);
      }
      public string ToString(string format, IFormatProvider formatProvider)
      {
         return string.Format(formatProvider, "{0}",
            Recordset.Position);
            //(_Field != null) ? _Field.String : "");
      }
   #endregion ToString
*/
   }

   public class Column
   {
      public Record Record { get; private set; }
      public Column(Record record)
      {
         Record = record;
      }
      public object Data
      { 
         get { return Record.Recordset.GetData(Record.Recordset.Columns[Record.ColumnPosition]); } 
      }
      public string String
      { 
         get { return Record.Recordset.GetString(Record.Recordset.Columns[Record.ColumnPosition]); } 
      }
      public double Float
      {
         get { return (double)Data; }
      }
      public int Integer
      {
         get { return (int)Data; }
      }
      public DateTimeOffset DateTimeOffset
      {
         get { return (DateTimeOffset)Data; }
      }
      public DateTime DateTime
      {
         get { return DateTimeOffset.DateTime; }
      }
      public bool Boolean
      {
         get { return (bool)Data; }
      }
/*
      #region ToString
      public override String ToString()
      {
         return ToString(null, null);
      }
      public string ToString(string format, IFormatProvider formatProvider)
      {
         return string.Format(formatProvider, "{0}",
            Record.Recordset.Position);
         //(_Field != null) ? _Field.String : "");
      }
      #endregion ToString
*/
   }

   #endregion Recordset
}
