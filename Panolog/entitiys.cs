using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panolog;
namespace Panolog
{
    public class entitiys
    {
        public static GraphicsPath CreateRoundedRegion(int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Sol üst köşe
            path.AddArc(0, 0, radius, radius, 180, 90);

            // Sağ üst köşe
            path.AddArc(width - radius, 0, radius, radius, 270, 90);

            // Sağ alt köşe
            path.AddArc(width - radius, height - radius, radius, radius, 0, 90);

            // Sol alt köşe
            path.AddArc(0, height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            return path;
        }
    }

}

