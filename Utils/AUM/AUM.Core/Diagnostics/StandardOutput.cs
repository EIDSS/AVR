using System.Diagnostics;

namespace AUM.Diagnostics
{
    public class StandardOutput : IDebugOutput
    {
        public void WriteLine(string line)
        {
            Debug.WriteLine(line);
        }
    }
}
