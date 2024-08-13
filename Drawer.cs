using System;
using System.Drawing;

public class Drawer
{
    public int[] imageSize { get; set; }
    public byte[] byteArr { get; set; }
    public int lines { get; set; }
    public double amplitude { get; set; }
    public int hCompression { get; set; }
    private SVGMaker maker { get; set; }

    public Drawer(byte[] byteArr, int[] imageSize, int lines, double amplitude, int hCompression)
    {
        if (lines > imageSize[1])
        {
            throw new ArgumentException("The number of lines must be equal or lower than the image height.");
        }

        this.imageSize = imageSize;
        this.byteArr = byteArr;
        this.lines = lines;
        this.amplitude = amplitude;
        this.hCompression = hCompression;
        maker = new SVGMaker(imageSize);
    }

    public void Draw()
    {
        int RowsPerLine = (int)Math.Floor((double)imageSize[1] / lines);
        int BytesPerRow = (int)Math.Floor((double)imageSize[0] / hCompression) * hCompression;
        int BytesPerLine = RowsPerLine * imageSize[0];


        for (int i = 0; i < lines; i++)
        {
            Point[] points = new Point[BytesPerRow * 2];
            
            for (int j = 0; j < BytesPerRow; j+=BytesPerRow/hCompression)
            {
                for (int k = 0; k < hCompression; k++)
                {
                    
                }    
            }
        }
    }
}