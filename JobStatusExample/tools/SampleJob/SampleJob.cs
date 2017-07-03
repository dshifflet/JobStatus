using MonitoredJobs;


namespace SampleJobs
{

    public class SampleJob : IMonitoredJob
    {
        public event MonitoredJob.JobStartedHandler JobStarted;
        public event MonitoredJob.JobFailedHandler JobFailed;
        public event MonitoredJob.JobCompletedHandler JobCompleted;
        public event MonitoredJob.JobProgressHandler JobProgressed;
        public event MonitoredJob.JobOverallStatusHandler JobOverallStatusUpdated;
        public event MonitoredJob.JobOverallCompletedHandler JobOverallCompleted;

        public void Start()
        {
            if (JobStarted != null) JobStarted("Dave's Job", "dave");
            if (JobStarted != null) JobStarted("Bonnie's Job", "bonnie");
            if (JobStarted != null) JobStarted("Bettie's Job", "betty");
            if (JobProgressed != null) JobProgressed("Dave's Job", "Some Progress", 25);
            if (JobFailed != null) JobFailed("Dave's Job", "dave");
            if (JobCompleted != null) JobCompleted("Bonnie's Job", "bonnie");
            if (JobProgressed != null) JobProgressed("Bettie's Job", "Betty was here", 50);            
            if (JobOverallStatusUpdated != null) JobOverallStatusUpdated("Hello!");
            if (JobOverallCompleted != null) JobOverallCompleted("All the Jobs are Done!");
        }
    }
}
