using System.Drawing;

// FOR All:
namespace FiltersLab
{
    public class GrayWorld
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
            double outColorR = 0, outColorG = 0, outColorB = 0;
            int N = inImg.Width*inImg.Height;
            Color inColor;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    inColor = inImg.GetPixel(i, j);
                    outColorR += (1.0 / N) * inColor.R;
                    outColorG += (1.0 / N) * inColor.G;
                    outColorB += (1.0 / N) * inColor.B;
                }
            double avgC = (outColorR + outColorG + outColorB) / 3.0;
            outColorR = avgC / outColorR; outColorG = avgC / outColorG; outColorB = avgC / outColorB;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    inColor = inImg.GetPixel(i, j);
                    Color outColor = Color.FromArgb(
                        clamp((int)(inColor.R * outColorR), 0, 255),
                        clamp((int)(inColor.G * outColorG), 0, 255),
                        clamp((int)(inColor.B * outColorB), 0, 255)
                        );
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
