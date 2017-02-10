using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace AaSampleService
{
    public partial class AaSampleService : ServiceBase
    {
        private Timer _timer;
        public AaSampleService()
        {
            InitializeComponent();
        }
        
        protected override void OnStart(string[] args)
        {
            _timer = new Timer();
            //_timer.Enabled = true;
            _timer.Interval = 10 * 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            eventLog1.WriteEntry("Service started successfully", EventLogEntryType.Information);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            eventLog1.WriteEntry("Service runs", EventLogEntryType.Information);
        }
        
        protected override void OnStop()
        {
            _timer.Stop();
            eventLog1.WriteEntry("Service stopped successfully", EventLogEntryType.Information);
        }
    }
}
