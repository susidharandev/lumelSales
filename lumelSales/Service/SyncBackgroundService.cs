namespace lumelSales.Service
{
    public class SyncBackgroundService : BackgroundService
    {
        public SyncBackgroundService() { }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
        // implement background auto sycn with background service
    }
}
