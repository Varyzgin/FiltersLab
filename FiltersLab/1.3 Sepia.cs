using System.Drawing;

// FOR All:
namespace FiltersLab
{
    public class Sepia
    {
        public static int clamp(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }
        public static Bitmap Filter(Bitmap inImg) {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++) {
                    Color inColor = inImg.GetPixel(i, j);
                    
                    int k = 20, intensity = (int)(0.299 * inColor.R + 0.587 * inColor.G + 0.114 * inColor.B);
                    Color outColor = Color.FromArgb(
                        clamp(intensity + 2 * k, 0, 255),
                        clamp((int)(intensity + 0.5 * k), 0, 255),
                        clamp(intensity - k, 0, 255));

                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}

/*namespace FiltersLab
{
    public class Sepia : Filters
    {
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            Color inColor = inImg.GetPixel(x, y);
            /* 
            k = 20;
            R = intensity + 2 * k;
            G = intensity + 0.5 * k;
            B = intensity - 1 * k; 
            *//* 

            int k = 20, intensity = (int)(0.299 * inColor.R + 0.587 * inColor.G + 0.114 * inColor.B);
            Color outColor = Color.FromArgb(
                 clamp(intensity + 2 * k, 0, 255),
                 clamp((int)(intensity + 0.5 * k), 0, 255), // (int) тк получается float значение
                 clamp(intensity - k, 0, 255));

            return outColor;
        }
    }
}
*/