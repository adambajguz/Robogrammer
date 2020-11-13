namespace Robogrammer.Core
{
    using Microsoft.Extensions.DependencyInjection;
    using Robogrammer.Core.Services;

    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IRobotActionsOptimizer, RobotActionsOptimizer>();
            services.AddSingleton<IRobotActionsCodeGenerator, RobotActionsCodeGenerator>();

            return services;
        }
    }
}
