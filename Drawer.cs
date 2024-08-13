using System;
using System.Drawing;

public class Drawer
{
    public int[] imageSize { get; set; }
    public byte[] byteArr { get; set; }
    public int compression { get; set; }
    private SVGMaker maker { get; set; }

    public Drawer(byte[] byteArr, int[] imageSize, int compression)
    {
        this.imageSize = imageSize;
        this.byteArr = byteArr;
        this.compression = compression;
        maker = new SVGMaker(imageSize);
    }

    public void Draw()
    {
        
    }
}