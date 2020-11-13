namespace Robogrammer.Core.Services
{
    using System.Collections.Generic;
    using System.Text;
    using Robogrammer.Core.Models;

    public class RobotActionsCodeGenerator : IRobotActionsCodeGenerator
    {
        public RobotActionsCodeGenerator()
        {

        }

        public string Generate(IReadOnlyList<RobotAction> robotActions)
        {
            StringBuilder sb = new StringBuilder();

            AddDefines(sb);
            BeginMain(sb);

            for (int i = 1; i < robotActions.Count; ++i)
            {
                RobotAction current = robotActions[i];

                if (current is RobotGoAction go)
                {

                }
                else if (current is RobotTurnAction turn)
                {

                }
                else if (current is RobotWaitAction wait)
                {

                }
            }

            EndMain(sb);

            return sb.ToString();
        }

        #region Helpers
        public static void AddDefines(StringBuilder sb)
        {

        }

        public static void BeginMain(StringBuilder sb)
        {

        }

        public static void EndMain(StringBuilder sb)
        {

        }
        #endregion
    }
}
