using System.Drawing;

namespace FiltersLab
{
    public class AutoContrast
    {
        public static Bitmap Filter(Bitmap inImg)
        {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            int Rmin = 255, Rmax = 0, Gmin = 255, Gmax = 0, Bmin = 255, Bmax = 0;
            Color inColor, outColor;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    inColor = inImg.GetPixel(i, j);
                    if (inColor.R < Rmin) Rmin = inColor.R;
                    if (inColor.G < Gmin) Gmin = inColor.G;
                    if (inColor.B < Bmin) Bmin = inColor.B;
                    if (inColor.R > Rmax) Rmax = inColor.R;
                    if (inColor.G > Gmax) Gmax = inColor.G;
                    if (inColor.B > Bmax) Bmax = inColor.B;
                }
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    inColor = inImg.GetPixel(i, j);
                    outColor = Color.FromArgb(
                        (int)((inColor.R - Rmin) * (255 - 0) / (Rmax - Rmin)),
                        (int)((inColor.G - Gmin) * (255 - 0) / (Gmax - Gmin)),
                        (int)((inColor.B - Bmin) * (255 - 0) / (Bmax - Bmin))
                        );
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
