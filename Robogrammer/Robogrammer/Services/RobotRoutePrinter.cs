namespace Robogrammer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Blazor.Extensions.Canvas.Canvas2D;
    using Robogrammer.Core.Models;

    public sealed class RobotRoutePrinter
    {
        private const int _robotWidth = 24;
        private const int _robotHeight = 24;

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
            await Clear();

            await PrintRobot(Width / 2, Height / 2);
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

            await Clear();

            int x = Width / 2;
            int y = Height / 2;

            foreach (RobotAction action in _robotActions)
            {
                if (action is RobotGoAction go)
                {
                    int ye = (int)Math.Round(y - go.Distance);
                    await PrintLine(x, y, x, ye);
                    await PrintLine(x+ _robotWidth, y, x+ _robotWidth, ye);
                    y += ye - y;
                }
                else if (action is RobotTurnAction turn)
                {

                }
                else if (action is RobotWaitAction wait)
                {

                }
            }

            await PrintRobot(x, y);
        }

        #region Drawing helpers
        private async Task Clear()
        {
            await _context.SetFillStyleAsync("#E8E3CC");
            await _context.FillRectAsync(0, 0, Width, Height);
        }

        private async Task PrintRobot(int x, int y)
        {
            await _context.SetFillStyleAsync("#DB3F29");

            await _context.FillRectAsync(x,
                                         y,
                                         _robotWidth,
                                         _robotHeight);

            await _context.FillRectAsync(x + (_robotWidth / 4),
                                         y - (_robotHeight / 4),
                                         _robotWidth / 2,
                                         _robotHeight / 4);
        }

        private async Task PrintLine(int xStart, int yStart, int xEnd, int yEnd)
        {
            await _context.SetStrokeStyleAsync("#0B1F65");

            await _context.BeginPathAsync();
            await _context.MoveToAsync(xStart, yStart);
            await _context.LineToAsync(xEnd, yEnd);
            await _context.StrokeAsync();
            await _context.ClosePathAsync();
        }
        #endregion
    }
}
