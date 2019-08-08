using System;

namespace AUM.Diagnostics
{
    public class ConsoleOutput : IDebugOutput
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }

}
