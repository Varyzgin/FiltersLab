using System.Drawing;

namespace FiltersLab
{
    public class Sort
    {
        public static int partition(int[] A, int start, int end)
        {
            int pivot = A[(start + end) / 2];
            int i = start;
            int j = end;

            while (i <= j)
            {
                while (A[i] < pivot) i++;
                while (A[j] > pivot) j--;
                if (i <= j)
                {
                    int temp = A[i]; A[i] = A[j]; A[j] = temp;
                    i++; j--;
                }
            }
            return i;
        }

        public static void qSort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int temp = partition(A, start, end);
                qSort(A, start, temp - 1);
                qSort(A, temp, end);
            }
        }
    }
    public class Median
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

            int radiusX = 1;
            int radiusY = 1;
            for (int i = 0; i < inImg.Width; i++)
                for (int j = 0; j < inImg.Height; j++)
                {
                    int[] kernelR = new int[9];
                    int[] kernelG = new int[9];
                    int[] kernelB = new int[9];
                    int q = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(i + k, 0, inImg.Width - 1); // copy border
                            int idY = clamp(j + l, 0, inImg.Height - 1);
                            Color pixColor = inImg.GetPixel(idX, idY);
                            kernelR[q] = pixColor.R; kernelG[q] = pixColor.G; kernelB[q] = pixColor.B;
                            q++;
                        }
                    Sort.qSort(kernelR, 0, 8);
                    Sort.qSort(kernelG, 0, 8);
                    Sort.qSort(kernelB, 0, 8);

                    Color outColor = Color.FromArgb(kernelR[4], kernelG[4], kernelB[4]);
                    outImg.SetPixel(i, j, outColor);
                }
            return outImg;
        }
    }
}