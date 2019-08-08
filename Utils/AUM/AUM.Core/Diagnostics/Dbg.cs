namespace AUM.Core.Diagnostics
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Diagnostics;
  using System.Reflection;
  using AUM.Configuration;
  using AUM.Diagnostics;
  using Configuration;
  using Core;


  public class Dbg
    {
        /*
        private static Regex s_DebugMethodFilterRegexp;
        private static bool s_DebugMethodFilterRegexpDefined;
        */
        private static int s_DefaultDetailLevel;

        private Dbg()
        {
            // NOOP
        }

        private static readonly StandardOutput s_StandardOutput = new StandardOutput();
        private static IDebugOutput CreateDefaultOutputMethod()
        {
            // TODO: allow configurable output to log file
            s_DefaultDetailLevel = BaseSettings.DebugDetailLevel;
            if (!BaseSettings.DebugOutput)
            {
                return null;
            }
            if (Utils.Str(BaseSettings.DebugLogFile) != "")
            {
                if (System.IO.File.Exists(BaseSettings.DebugLogFile))
                {
                    return new DebugFileOutput(BaseSettings.DebugLogFile, false);
                }
                try
                {
                    System.IO.FileStream fs = System.IO.File.Create(BaseSettings.DebugLogFile);
                    fs.Close();
                    return new DebugFileOutput(BaseSettings.DebugLogFile, false);
                }
                catch (Exception)
                {
                    return s_StandardOutput;
                }
            }
            return s_StandardOutput;
        }

        private static string FormatDataRow(DataRow row)
        {
            List<string> @out = new List<string>();
            foreach (DataColumn col in row.Table.Columns)
            {
                @out.Add(string.Format(":{0} <{1}>", col.ColumnName, FormatValue(row[col])));
            }
            return string.Format("#<DataRow {0}>", Utils.Join(" ", @out));
        }

        public static string FormatValue(object value)
        {
            if (value == null)
            {
                return "*Nothing*";
            }
            if (value == DBNull.Value)
            {
                return "*DBNull*";
            }
            if (value is DataRow)
            {
                return FormatDataRow((DataRow)value);
            }
            if (value is DataRowView)
            {
                return FormatDataRow(((DataRowView)value).Row);
            }
            return value.ToString();
        }

        private static IDebugOutput s_OutputMethod;
        public static IDebugOutput OutputMethod
        {
            get
            {
                if (!Config.IsInitialized)
                {
                    return s_StandardOutput;
                }
                if (s_OutputMethod == null)
                {
                    s_OutputMethod = CreateDefaultOutputMethod();
                }
                return s_OutputMethod;
                //Dim result As IDebugOutput = Nothing
                //If InitSlot() Then
                //    result = CType(Thread.GetData(s_OutputMethodSlot), IDebugOutput)
                //Else
                //    result = CreateDefaultOutputMethod()
                //    Thread.SetData(s_OutputMethodSlot, result)
                //End If
                //Return result
            }
            set
            {
                s_OutputMethod = value;
                //InitSlot()
                //Thread.SetData(s_OutputMethodSlot, value)
            }
        }

        private static void DoDbg(int DetailLevel, string fmt, params object[] args)
        {
            if (OutputMethod != null)
            {
                StackTrace trace = new StackTrace(2, true);
                MethodBase method = trace.GetFrame(0).GetMethod();
                if (ShouldIgnore(DetailLevel, method))
                {
                    return;
                }
                if (args == null || args.Length == 0)
                {
                    OutputMethod.WriteLine(string.Format("{0}.{1}(): {2}", method.DeclaringType.Name, method.Name, fmt));
                    return;
                }
                string[] newArgs = new string[args.Length];
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    newArgs[i] = FormatValue(args[i]);
                }
                OutputMethod.WriteLine(string.Format("{0}.{1}(): {2}", method.DeclaringType.Name, method.Name, string.Format(fmt, newArgs)));
            }
        }

        public static void WriteLine(string fmt, params object[] args)
        {
            if (OutputMethod != null)
            {
                string[] newArgs = new string[args.Length];
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    newArgs[i] = FormatValue(args[i]);
                }
                if (args.Length == 0)
                {
                    OutputMethod.WriteLine(fmt);
                }
                else
                {
                    OutputMethod.WriteLine(string.Format(fmt, newArgs));
                }
            }
        }

        public static void Debug(string fmt, params object[] args)
        {
            DoDbg(0, fmt, args);
        }
        public static void ConditionalDebug(int DetailLevel, string fmt, params object[] args)
        {
            DoDbg(DetailLevel, fmt, args);
        }
        public static void ConditionalDebug(DebugDetalizationLevel DetailLevel, string fmt, params object[] args)
        {
            DoDbg((int)DetailLevel, fmt, args);
        }

        public static void Fail(string fmt, params object[] args)
        {
            string message = "Assertion failed: " + string.Format(fmt, args);
            DoDbg(0, "{0}", message); // TODO: always print failure messages
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            throw (new InternalErrorException(message));
        }

        public static void Assert(bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(0, "{0}", message);
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                throw (new InternalErrorException(message));
            }
        }

        public static void DbgAssert(bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(0, "{0}", message);
            }
        }

        public static void DbgAssert(int DetailLevel, bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(DetailLevel, "{0}", message);
            }
        }
        // TODO: probably System.Diagnostics.SymbolStore.* can be used to display extended error information
        public static void Require(params object[] values)
        {
            for (int i = 0; i <= values.Length - 1; i++)
            {
                if (values[i] == null)
                {
                    // we duplicate Fail here to make DoDbg work correctly
                    string message = string.Format("Require: value #{0} (starting from 1) is Nothing", i + 1);
                    DoDbg(0, "{0}", message);
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                    throw (new InternalErrorException(message));
                }
            }
        }

        private static bool ShouldIgnore(int DetailLevel, MethodBase method)
        {
            if (DetailLevel <= s_DefaultDetailLevel)
            {
                return false;
            }
            return true; //TODO: should be implemented to skip some output
        }

        public static void Trace(params object[] argValues)
        {
#if USE_TRACE
            if (OutputMethod == null)
            {
                return;
            }
            StackTrace trace = new StackTrace(1, true);
            MethodBase method = trace.GetFrame(0).GetMethod();
            List<string> argStrings = new List<string>();
            if (argValues != null && argValues.Length != 0)
            {
                ParameterInfo[] @params = method.GetParameters();
                int numArgs = Math.Min(@params.Length, argValues.Length);
                for (int i = 0; i <= numArgs - 1; i++)
                {
                    string valString = FormatValue(argValues[i]);
                    argStrings.Add(string.Format("{0} = <{1}>", @params[i].Name, valString));
                }
            }
            OutputMethod.WriteLine(string.Format("--> {0}.{1}({2})", method.DeclaringType.Name, method.Name, Utils.Join(", ", argStrings)));
#endif
        }
    }
}
