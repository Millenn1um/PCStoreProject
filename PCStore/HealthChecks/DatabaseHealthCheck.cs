using Microsoft.Extensions.Diagnostics.HealthChecks;
using PCStore.Data;

namespace PCStore.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly PcShopContext _context;

        public DatabaseHealthCheck(PcShopContext context)
        {
            _context = context;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return _context.CPUs.Any() ? Task.FromResult(HealthCheckResult.Healthy()) : Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}
