namespace Robogrammer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blazor.Extensions.Canvas.Canvas2D;

    public sealed class RobotRoutePrinter
    {
        private readonly Canvas2DContext _context;

        public RobotRoutePrinter(Canvas2DContext context)
        {
            _context = context;
        }


        public async Task Initialize()
        {
            await _context.SetFillStyleAsync("#E8E3CC");
            await _context.FillRectAsync(0, 0, 400, 400);

            await _context.SetStrokeStyleAsync("#DB3F29");
            await _context.StrokeRectAsync(200, 200, 20, 20);
        }
    }
}
