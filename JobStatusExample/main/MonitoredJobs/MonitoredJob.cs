namespace MonitoredJobs
{
    public interface IMonitoredJob
    {
        event MonitoredJob.JobStartedHandler JobStarted; 
        event MonitoredJob.JobFailedHandler JobFailed;
        event MonitoredJob.JobCompletedHandler JobCompleted;
        event MonitoredJob.JobProgressHandler JobProgressed;
        event MonitoredJob.JobOverallStatusHandler JobOverallStatusUpdated;
        event MonitoredJob.JobOverallCompletedHandler JobOverallCompleted; 
        void Start();
    }

    public class MonitoredJob
    {
        public delegate void JobCompletedHandler(string name, string msg); //Starts it ADDS IT TO THE GRID VIEW
        public delegate void JobFailedHandler(string name, string msg); //Flags as Failed (RED)
        public delegate void JobStartedHandler(string name, string msg); //Flags as Completed (GREEN)
        public delegate void JobProgressHandler(string name, string msg, int percent); //Moves the progress box
        public delegate void JobOverallStatusHandler(string msg); //Updates the Task Bar
        public delegate void JobOverallCompletedHandler(string msg); //Displays a message Box
    }
}
