using System;
using System.Drawing;


public static class ImgProcess
{
    public static Bitmap ImgToBmp(string imagePath)
    {
        Bitmap image = new Bitmap(imagePath);
        return image;
    }

    public static byte[] BmpToArr(Bitmap image, bool BW)
    {
        int width = image.Width;
        int height = image.Height;
        byte[] pixelValues = new byte[width * height];

        int index = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color pixelColor = image.GetPixel(x, y);
                byte brightness = BW ? pixelColor.R : (byte)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                pixelValues[index++] = brightness;
            }
        }

        return pixelValues;
    }

    public static int[] GetSize(Bitmap image)
    {
        return [image.Width, image.Height];
    }
}
