using System;
using System.ServiceProcess;

namespace WindowsService2
{
    public partial class RattrServWindows : ServiceBase
    {
        private System.Timers.Timer timer;

        public RattrServWindows()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }

            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";

            timer = new System.Timers.Timer();
            timer.Interval = 6000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Coucou");
        }

        protected override void OnStop()
        {
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventLog1.WriteEntry("Coucou");
        }
    }
}