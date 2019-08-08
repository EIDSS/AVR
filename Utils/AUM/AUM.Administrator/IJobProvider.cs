namespace AUM.Administrator
{
    public interface IJobProvider
    {
        int Run(string aJobName);
        bool IsRunning { get; }
        string LastError { get; }
        string JobName { get; }
    }
}
