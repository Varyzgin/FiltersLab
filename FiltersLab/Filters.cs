using System.Drawing;

namespace FiltersLab
{
    public abstract class Filters
    {
        protected abstract Color calcPixel(Bitmap inImg, int x, int y);
        public Bitmap processImg(Bitmap inImg)
        {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                    outImg.SetPixel(i, j, calcPixel(inImg, i, j));
            return outImg;
        }
        public int clamp(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }
    }
}
