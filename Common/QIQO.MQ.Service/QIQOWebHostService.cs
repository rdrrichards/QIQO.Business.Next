using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using NLog;
using NLog.Web;

namespace QIQO.MQ.Service
{
    internal class QIQOWebHostService : WebHostService
    {
        private readonly Logger logger;

        //private readonly ILogger<QIQOWebHostService> _logger;

        public QIQOWebHostService(IWebHost host) : base(host)
        {
            logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
            logger.Info("QIQO.MQ.Service Starting");
        }

        protected override void OnStarted()
        {
            base.OnStarted();
            logger.Info("QIQO.MQ.Service Started");
        }

        protected override void OnStopping()
        {
            logger.Info("QIQO.MQ.Service Stopping");
            base.OnStopping();
            NLog.LogManager.Shutdown();
        }

    }
}
