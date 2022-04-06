using System.Drawing;

namespace FiltersLab
{
    public class Erosion
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
            kernel[0, 0] = kernel[0, 2] = kernel[2, 0] = kernel[2, 2] = 0;
            kernel[0, 1] = kernel[1, 0] = kernel[1, 1] = kernel[1, 2] = kernel[2, 1] = 1;

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    int min = 255;
                    for (int l = -radiusX; l <= radiusX; l++)
                        for (int k = -radiusY; k <= radiusY; k++)
                        {
                            int idX = clamp(i + l, 0, inImg.Width - 1); // copy border
                            int idY = clamp(j + k, 0, inImg.Height - 1);
                            if (kernel[l + 1, k + 1] > 0 && inImg.GetPixel(idX, idY).B < min)
                                min = inImg.GetPixel(idX, idY).B;
                        }
                    Color outColor = Color.FromArgb(min, min, min);
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}