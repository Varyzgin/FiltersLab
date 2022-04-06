using System;
using System.Drawing;

namespace FiltersLab
{
    public class Sharr
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
            float[,] kernelGx = new float[3, 3], kernelGy = new float[3, 3];
            int radiusX = 1;
            int radiusY = 1;
            kernelGx[0, 2] = kernelGx[2, 2] = kernelGy[2, 0] = kernelGy[2, 2] = 3;
            kernelGx[0, 0] = kernelGx[2, 0] = kernelGy[0, 0] = kernelGy[0, 2] = -3;
            kernelGx[1, 2] = kernelGy[2, 1] = 10;
            kernelGx[1, 0] = kernelGy[0, 1] = -10;
            kernelGx[0, 1] = kernelGx[1, 1] = kernelGx[2, 1] = kernelGy[1, 0] = kernelGy[1, 1] = kernelGy[1, 2] = 0;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    double outImgRX = 0, outImgGX = 0, outImgBX = 0, outImgRY = 0, outImgGY = 0, outImgBY = 0;
                    for (int k = -radiusX; k <= radiusX; k++)
                        for (int l = -radiusY; l <= radiusY; l++)
                        {
                            int idX = clamp(i + k, 0, inImg.Width - 1);
                            int idY = clamp(j + l, 0, inImg.Height - 1);
                            Color neighColor = inImg.GetPixel(idX, idY);
                            outImgRX += neighColor.R * kernelGx[k + radiusX, l + radiusY];
                            outImgGX += neighColor.G * kernelGx[k + radiusX, l + radiusY];
                            outImgBX += neighColor.B * kernelGx[k + radiusX, l + radiusY];
                        }
                    for (int k = -radiusX; k <= radiusX; k++)
                        for (int l = -radiusY; l <= radiusY; l++)
                        {
                            int idX = clamp(i + k, 0, inImg.Width - 1);
                            int idY = clamp(j + l, 0, inImg.Height - 1);
                            Color neighColor = inImg.GetPixel(idX, idY);
                            outImgRY += neighColor.R * kernelGy[k + radiusX, l + radiusY];
                            outImgGY += neighColor.G * kernelGy[k + radiusX, l + radiusY];
                            outImgBY += neighColor.B * kernelGy[k + radiusX, l + radiusY];
                        }
                    Color outColor = Color.FromArgb(
                        clamp((int)Math.Sqrt(outImgRX * outImgRX + outImgRY * outImgRY), 0, 255),
                        clamp((int)Math.Sqrt(outImgGX * outImgGX + outImgGY * outImgGY), 0, 255),
                        clamp((int)Math.Sqrt(outImgBX * outImgBX + outImgBY * outImgBY), 0, 255)
                        );
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
