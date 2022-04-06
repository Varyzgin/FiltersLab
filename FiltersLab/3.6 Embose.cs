using System.Drawing;

// FOR All:
namespace FiltersLab
{
    public class Embose
    {
        public static int clamp(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        public static Bitmap Filter(Bitmap inImg)
        {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            int[,] kernel;
            int sizeX = 3;
            int sizeY = 3;
            kernel = new int[sizeX, sizeY];
            kernel[0, 0] = kernel[2, 0] = kernel[1, 1] = kernel[0, 2] = kernel[2, 2] = 0;
            kernel[1, 0] = kernel[2, 1] = -1;
            kernel[0, 1] = kernel[1, 2] = 1;
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    double outImgR = 0, outImgG = 0, outImgB = 0;

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(i + k, 0, inImg.Width - 1); // copy border
                            int idY = clamp(j + l, 0, inImg.Height - 1);
                            Color neighColor = inImg.GetPixel(idX, idY);
                            outImgR += neighColor.R * kernel[k + radiusX, l + radiusY];
                            outImgG += neighColor.G * kernel[k + radiusX, l + radiusY];
                            outImgB += neighColor.B * kernel[k + radiusX, l + radiusY];
                        }
                    outImgR = clamp((int)outImgR, 0, 255);
                    outImgG = clamp((int)outImgG, 0, 255);
                    outImgB = clamp((int)outImgB, 0, 255);

                    double intensity = outImgR * 0.299 + outImgG * 0.587 + outImgB * 0.114;
                    int intens = (int)intensity;

                    intens += 100;
                    intens = clamp(intens, 0, 255);
                    Color outColor = Color.FromArgb(intens, intens, intens);
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
/*
namespace FiltersLab
{
    /*  1.свертка с матрицей 
            ⎡  0 +1  0 ⎤
            ⎢ −1  0 +1 ⎥
            ⎣  0 −1  0 ⎦
        2.сдвиг по яркости 100
        3.фильтр оттенки серого
    *//*
    public class Embose : MatrixFilters
    {
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            float[,] kernel;
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            kernel[0, 0] = kernel[2, 0] = kernel[1, 1] = kernel[0, 2] = kernel[2, 2] = 0;
            kernel[1, 0] = kernel[2, 1] = -1;
            kernel[0, 1] = kernel[1, 2] = 1;
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            double outImgR = 0, outImgG = 0, outImgB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = clamp(x + k, 0, inImg.Width - 1); // copy border
                    int idY = clamp(y + l, 0, inImg.Height - 1);
                    Color neighColor = inImg.GetPixel(idX, idY);
                    outImgR += neighColor.R * kernel[k + radiusX, l + radiusY];
                    outImgG += neighColor.G * kernel[k + radiusX, l + radiusY];
                    outImgB += neighColor.B * kernel[k + radiusX, l + radiusY];
                }
            outImgR = clamp((int)outImgR, 0, 255);
            outImgG = clamp((int)outImgG, 0, 255);
            outImgB = clamp((int)outImgB, 0, 255);

            double intensity = outImgR * 0.299 + outImgG * 0.587 + outImgB * 0.114;
            int intens = (int)intensity;

            intens += 100;
            intens = clamp(intens, 0, 255);
            Color outColor = Color.FromArgb(intens, intens, intens);
            return outColor;
        }
    }
}
*/