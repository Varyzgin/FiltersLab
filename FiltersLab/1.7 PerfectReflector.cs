using System.Drawing;

namespace FiltersLab
{
    public class PerfectReflector
    {
        public static Bitmap Filter(Bitmap inImg)
        {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            int Rmax = 0, Gmax = 0, Bmax = 0;
            Color inColor, outColor;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    inColor = inImg.GetPixel(i, j);
                    if (inColor.R > Rmax) Rmax = inColor.R;
                    if (inColor.G > Gmax) Gmax = inColor.G;
                    if (inColor.B > Bmax) Bmax = inColor.B;
                }
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    inColor = inImg.GetPixel(i, j);
                    outColor = Color.FromArgb(
                        (int)(inColor.R * 255 / Rmax),
                        (int)(inColor.G * 255 / Gmax),
                        (int)(inColor.B * 255 / Bmax)
                        );
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
