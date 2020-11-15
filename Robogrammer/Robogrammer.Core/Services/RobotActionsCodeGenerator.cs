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

        public string Generate(IReadOnlyList<RobotAction> robotActions, CodeSettings settings)
        {
            StringBuilder sb = new StringBuilder();

            AddDefines(sb, settings);
            BeginMain(sb);

            for (int i = 0; i < robotActions.Count; ++i)
            {
                RobotAction current = robotActions[i];

                if (current is RobotGoAction go)
                {
                    double distance = go.Distance * 19.5d;

                    sb.AppendLine($"// #{i + 1:D4} START");
                    sb.AppendLine("ClearScreen();");
                    sb.AppendLine($"TextOut(0, LCD_LINE1, \"#{i + 1:D4}\");");
                    sb.AppendLine($"TextOut(0, LCD_LINE2, \"GO({go.Distance})\");");
                    sb.AppendLine($"RotateMotor(LR, PWR_LR, {distance})");
                    sb.AppendLine("Wait(100);");
                }
                else if (current is RobotTurnAction turn)
                {
                    double angle = ((340 * 4) / 360) * turn.Angle;

                    sb.AppendLine($"// #{i + 1:D4} START");
                    sb.AppendLine("ClearScreen();");
                    sb.AppendLine($"TextOut(0, LCD_LINE1, \"#{i + 1:D4}\");");
                    sb.AppendLine($"TextOut(0, LCD_LINE2, \"TURN({turn.Angle})\");");
                    sb.AppendLine($"RotateMotorEx(LR, PWR_LR, {angle}, true, true);");
                    sb.AppendLine("Wait(100);");
                }
                else if (current is RobotWaitAction wait)
                {
                    sb.AppendLine($"// #{i + 1:D4} START");
                    sb.AppendLine("ClearScreen();");
                    sb.AppendLine($"TextOut(0, LCD_LINE1, \"#{i + 1:D4}\");");
                    sb.AppendLine($"TextOut(0, LCD_LINE2, \"WAIT({wait.Duration})\");");
                    sb.AppendLine($"Wait({wait.Duration});");
                }
            }

            EndMain(sb, robotActions.Count + 1);

            return sb.ToString();
        }

        #region Helpers
        public static void AddDefines(StringBuilder sb, CodeSettings settings)
        {
            sb.AppendLine("#define TURN_RATIO 45");

            sb.Append("#define L OUT_");
            sb.AppendLine(GetPortLetter(settings.LeftEnginePort));

            sb.Append("#define R OUT_");
            sb.AppendLine(GetPortLetter(settings.RightEnginePort));

            sb.Append("#define LR OUT_");
            sb.Append(GetPortLetter(settings.LeftEnginePort));
            sb.AppendLine(GetPortLetter(settings.RightEnginePort));

            sb.AppendLine("#define PWR_LR 50");
        }

        public static void BeginMain(StringBuilder sb)
        {
            sb.AppendLine("task main() {");
            sb.AppendLine("// #0000 START");
            sb.AppendLine("ClearScreen();");
            sb.AppendLine("TextOut(0, LCD_LINE1, \"#0000\");");
            sb.AppendLine("TextOut(0, LCD_LINE2, \"START\");");
        }

        public static void EndMain(StringBuilder sb, int id)
        {
            sb.AppendLine($"// #{id:D4} END");
            sb.AppendLine("ClearScreen();");
            sb.AppendLine($"TextOut(0, LCD_LINE1, \"#{id:D4}\");");
            sb.AppendLine("TextOut(0, LCD_LINE2, \"FINISHED\");");
            sb.AppendLine("Wait(10000);");
            sb.AppendLine("}");
        }

        public static string GetPortLetter(Ports port)
        {
            return port switch
            {
                Ports.PortA => "A",
                Ports.PortB => "B",
                Ports.PortC => "C",
                Ports.PortD => "D",
                _ => "A",
            };
        }
        #endregion
    }
}
