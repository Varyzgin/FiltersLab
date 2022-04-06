namespace FiltersLab
{
    public class MotionBlur : MatrixFilters
    {
        public MotionBlur()
        {
            int size = 9;
            
            kernel = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == j) kernel[i, j] = 1.0f / (float)(size);
                    else kernel[i, j] = 0f;
        }
    }
}

/*
// FOR SoftGrader:
namespace Filter
{
    public class Filter
    {
        public static int clamp(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        public static Bitmap Execute(Bitmap inImg)
        {
            Bitmap outImg = new Bitmap(inImg.Width, inImg.Height);

            int size = 9;
            float[,] kernel = new float[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == j) kernel[i, j] = 1.0f / (float)(size);
                    else kernel[i, j] = 0f;

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    double outImgR = 0, outImgG = 0, outImgB = 0;

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(i + k, 0, inImg.Width - 1); // copy border
                            int idY = clamp(j + l, 0, inImg.Height - 1);
                            Color neighColor = inImg.GetPixel(idX, idY);
                            outImgR += neighColor.R * kernel[k + radiusX, l + radiusY];
                            outImgG += neighColor.G * kernel[k + radiusX, l + radiusY];
                            outImgB += neighColor.B * kernel[k + radiusX, l + radiusY];
                        }
                    outImgR = clamp((int)outImgR, 0, 255);
                    outImgG = clamp((int)outImgG, 0, 255);
                    outImgB = clamp((int)outImgB, 0, 255);

                    Color outColor = Color.FromArgb(
                        clamp((int)outImgR, 0, 255), 
                        clamp((int)outImgG, 0, 255),
                        clamp((int)outImgB, 0, 255));
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}
*/
