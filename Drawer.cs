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
        maker.Create();

        //row = original image row of pixels
        //line = final drawn line

        //Amount of original image pixel rows to be compressed per single drawn line
        int RowsPerLine = (int)Math.Floor((double)imageSize[1] / lines);

        //Amount of bytes in byteArr that compose 1 row, considering the compression
        int BytesPerRow = (int)Math.Floor((double)imageSize[0] / hCompression) * hCompression;

        //Amount of bytes in byteArr that compose 1 full line, not considering compression.
        int BytesPerLine = RowsPerLine * imageSize[0];

        PointD[] points = new PointD[hCompression * 2];

        for (int i = 0; i < lines; i++)
        {
            int count = 0;
            
            for (int j = 0; j < BytesPerRow; j+=hCompression)
            {
                double blockAvg = 0;

                for (int k = 0; k < hCompression; k++)
                {
                    for (int l = 0; l < RowsPerLine; l++)
                    {
                        blockAvg += byteArr[i*RowsPerLine + l*BytesPerLine + j + k];
                    }
                }
                blockAvg /= RowsPerLine * hCompression;
                double deviation = RowsPerLine/2 * blockAvg / 255;
                points[count] = new PointD(j,(RowsPerLine/2) + i + deviation);
                points[count+1] = new PointD(j+(hCompression/2),(RowsPerLine/2) + i - deviation);
                count += 2;
            }
            
            maker.NewLine(points);
        }
        maker.Close();
    }

    public void Save(string path)
    {
        maker.Save(path);
    }
}