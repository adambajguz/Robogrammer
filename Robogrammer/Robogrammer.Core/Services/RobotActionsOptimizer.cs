namespace Robogrammer.Core.Services
{
    using System.Collections.Generic;
    using Robogrammer.Core.Models;

    public class RobotActionsOptimizer : IRobotActionsOptimizer
    {
        public RobotActionsOptimizer()
        {

        }

        public List<RobotAction>? Optimize(IReadOnlyList<RobotAction> robotActions)
        {
            if (robotActions.Count < 2)
                return null;

            List<RobotAction> optimized = new List<RobotAction>
            {
                robotActions[0]
            };

            for (int i = 1; i < robotActions.Count; ++i)
            {
                RobotAction current = robotActions[i];
                RobotAction lastOptimized = optimized[^1];

                if (current.GetType() == lastOptimized.GetType())
                {
                    if (current is RobotGoAction go0 && lastOptimized is RobotGoAction go1)
                    {
                        go1.Distance += go0.Distance;
                    }
                    else if (current is RobotTurnAction turn0 && lastOptimized is RobotTurnAction turn1)
                    {
                        turn1.Angle += turn0.Angle;
                    }
                    else if (current is RobotWaitAction wait0 && lastOptimized is RobotWaitAction wait1)
                    {
                        wait1.Duration += wait0.Duration;
                    }
                }
                else
                {
                    optimized.Add(current);
                }
            }

            return robotActions.Count == optimized.Count ? null : optimized;
        }
    }
}
