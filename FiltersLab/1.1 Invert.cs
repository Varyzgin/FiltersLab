using System.Drawing;

namespace FiltersLab
{
    public class Invert : Filters
    {
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            Color inColor = inImg.GetPixel(x, y);

            Color outColor = Color.FromArgb(255 - inColor.R, 255 - inColor.G, 255 - inColor.B);

            return outColor;
        }
    }
}
/*
// FOR SoftGrader:
namespace Filter {
    public class Filter {
        public static Bitmap Execute(Bitmap inImg) {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++) {
                    Color inColor = inImg.GetPixel(i, j);

                    Color outColor = Color.FromArgb(255 - inColor.R, 255 - inColor.G, 255 - inColor.B);

                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
*/