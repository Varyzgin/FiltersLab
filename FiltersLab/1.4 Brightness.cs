using System.Drawing;

// FOR All:
namespace FiltersLab
{
    public class Brightness
    {
        public static int clamp(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }
        public static Bitmap Filter(Bitmap inImg, int bright)
        {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    Color inColor = inImg.GetPixel(i, j);

                    Color outColor = Color.FromArgb(
                        clamp(inColor.R + bright, 0, 255),
                        clamp(inColor.G + bright, 0, 255),
                        clamp(inColor.B + bright, 0, 255));

                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}

/* 
namespace FiltersLab
{
    public class Brightness : Filters
    {
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            Color inColor = inImg.GetPixel(x, y);

            Color outColor = Color.FromArgb(
                        clamp(inColor.R + 20, 0, 255),
                        clamp(inColor.G + 20, 0, 255),
                        clamp(inColor.B + 20, 0, 255));
          
            /*  // (не работает) - конвертация в HSB формат и обратно
                HSBColor inHSBColor = PluginHSB.RGBtoHSB(inColor), outHSBColor = inHSBColor
                outHSBColor.b = PluginHSB.clamp(inHSBColor.b + 20, 0, 100);
                Color outColor = PluginHSB.HSBtoRGB(outHSBColor);
            *//* 
return outColor;
        }
    }
}
*/
