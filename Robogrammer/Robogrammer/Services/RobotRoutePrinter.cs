namespace Robogrammer.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Blazor.Extensions.Canvas.Canvas2D;
    using Robogrammer.Core.Models;

    public sealed class RobotRoutePrinter
    {
        private const int _robotWidth = 20;
        private const int _robotHeight = 20;

        private readonly Canvas2DContext _context;

        private IReadOnlyList<RobotAction>? _robotActions;

        private int Width { get; }
        private int Height { get; }

        public RobotRoutePrinter(Canvas2DContext context, int width, int height)
        {
            _context = context;

            Width = width;
            Height = height;
        }

        public async Task Reset()
        {
            await _context.SetFillStyleAsync("#E8E3CC");
            await _context.FillRectAsync(0, 0, Width, Height);

            await _context.SetFillStyleAsync("#DB3F29");
            await _context.SetStrokeStyleAsync("#DB3F29");

            await _context.StrokeRectAsync(Width / 2,
                                           Height / 2,
                                           _robotWidth,
                                           _robotHeight);

            await _context.FillRectAsync((Width / 2) + (_robotWidth / 2),
                                         (Height / 2) - (_robotHeight / 8),
                                         _robotWidth,
                                         _robotHeight / 8);

            await PrintRoute();
        }

        public void BindData(IReadOnlyList<RobotAction> robotActions)
        {
            _robotActions = robotActions;
        }

        public async Task PrintRoute()
        {
            if (_robotActions is null)
                return;

            foreach (RobotAction action in _robotActions)
            {
                if (action is RobotGoAction go)
                {

                }
                else if (action is RobotTurnAction turn)
                {

                }
                else if (action is RobotWaitAction wait)
                {

                }
            }
        }
    }
}
