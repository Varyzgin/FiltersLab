using System.Drawing;

// FOR SoftGrader:
namespace FiltersLab
{
    public class Shift
    {
        public static Bitmap Filter(Bitmap inImg, int shift) {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            for (int i = 0; i < inImg.Width - shift; i++)
                for (int j = 0; j < inImg.Height; j++) {
                    Color inColor = inImg.GetPixel(i, j);
                    outImg.SetPixel(i + shift, j, inColor);
                }
            return outImg;
        }
    }
}

/*
namespace FiltersLab
{
    public class Shift : Filters
    {
        protected override Color calcPixel(Bitmap inImg, int x, int y)
        {
            Color inColor = inImg.GetPixel(x, y), outColor;

            if (x <= 50) outColor = Color.FromArgb(0, 0, 0);
            else outColor = inImg.GetPixel(x - 50, y); // сдвиг вправо

            return outColor;
        }
    }
}
*/