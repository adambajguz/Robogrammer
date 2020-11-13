namespace Robogrammer.Core.Services
{
    using System.Collections.Generic;
    using Robogrammer.Core.Models;

    public interface IRobotActionsOptimizer
    {
        /// <summary>
        /// Returns new optimized list of actions or null when failed to optimize.
        /// </summary>
        List<RobotAction>? Optimize(IReadOnlyList<RobotAction> robotActions);
    }
}