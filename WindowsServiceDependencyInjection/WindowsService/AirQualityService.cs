using Infrastructure.Services;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService
{
    public partial class AirQualityService : ServiceBase
    {
        private readonly IAirQualityRecorder airQualityRecorder;
        private readonly Timer timer;

        public AirQualityService(IAirQualityRecorder airQualityRecorder)
        {
            InitializeComponent();
            this.airQualityRecorder = airQualityRecorder;
            this.timer = new Timer();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(OnTimerTick);
            timer.Interval = 3600000;
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        private void OnTimerTick(object source, ElapsedEventArgs e)
        {
            airQualityRecorder.Record();
        }
    }
}
