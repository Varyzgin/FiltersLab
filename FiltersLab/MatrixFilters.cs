using System.Drawing;

namespace FiltersLab
{
    public class MatrixFilters : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilters() { }
        public MatrixFilters(float[,] kernel) { this.kernel = kernel; }
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float outImgR = 0, outImgG = 0, outImgB = 0;
            for (int l = -radiusY; l <= radiusX; l++)
                for (int k = -radiusX; k <= radiusY; k++)
                {
                    int idX = clamp(x + k, 0, inImg.Width - 1);
                    int idY = clamp(y + l, 0, inImg.Height - 1);
                    Color neighColor = inImg.GetPixel(idX, idY);
                    outImgR += neighColor.R * kernel[k + radiusX, l + radiusY];
                    outImgG += neighColor.G * kernel[k + radiusX, l + radiusY];
                    outImgB += neighColor.B * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb
            (
                clamp((int)outImgR, 0, 255),
                clamp((int)outImgG, 0, 255),
                clamp((int)outImgB, 0, 255)
            );
        }
    }
}

