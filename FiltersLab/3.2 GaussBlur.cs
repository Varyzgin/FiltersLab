using System;

namespace FiltersLab
{
    public class GaussBlur : MatrixFilters
    {
        public void GaussKernel(int r, float q)
        {
            // определение размера ядра
            int size = 2 * r + 1;
            // создание ядра
            kernel = new float[size, size];
            // коэф нормировки ядра
            float norm = 0.0f;
            // расчет самого ядра
            for (int i = -r; i < r; i++)
                for (int j = -r; j < r; j++)
                {
                    kernel[i + r, j + r] = (float)(Math.Exp(-(i * i + j * j) / (2 * q * q)));
                    norm += kernel[i + r, j + r];
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
        public GaussBlur()
        {
            GaussKernel(3, 2);
        }
    }
}