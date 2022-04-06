using System.Drawing;

// FOR All:
namespace FiltersLab
{
    public class GrayShades
    {
        public static Bitmap Filter(Bitmap inImg) {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++) {
                    Color inColor = inImg.GetPixel(i, j);

                    int intensity = (int)(0.299 * inColor.R + 0.587 * inColor.G + 0.114 * inColor.B);
                    Color outColor = Color.FromArgb(intensity, intensity, intensity);

                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}

/*
namespace FiltersLab
{
    internal class GrayShades : Filters
    {
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            Color inColor = inImg.GetPixel(x, y);
            
            //intensity = 0.299 * R + 0.587 * G + 0.114 * B
            

            int intensity = (int)(0.299 * inColor.R + 0.587 * inColor.G + 0.114 * inColor.B);
            Color outColor = Color.FromArgb(intensity, intensity, intensity);

            return outColor;
        }
    }
}
*/