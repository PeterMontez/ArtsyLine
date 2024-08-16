using System;
using System.Drawing;
using System.Windows;

public class SVGMaker
{
    public int[] imageSize { get; set; }
    public string svgContent { get; set; }

    public SVGMaker(int[] imageSize)
    {
        this.imageSize = imageSize;
    }

    public void Create()
    {
        string svgContent = $@"
<svg width='{imageSize[0]}' height='{imageSize[1]}' xmlns='http://www.w3.org/2000/svg'>";
    }

    public void NewLine(PointD[] points)
    {
        svgContent += @"
    <polyline points='";
        foreach (var point in points)
        {
            svgContent += $"{point.X},{point.Y} ";
        }
        svgContent += $@"'
        style='fill:none;stroke:black;stroke-width:1' />";
    }

    public void Close()
    {
        svgContent += $@"'
        style='fill:none;stroke:black;stroke-width:2' />
</svg>";
    }

    public void Save(string filePath)
    {
        File.WriteAllText(filePath, svgContent);
        Console.WriteLine($"SVG file generated: {filePath}");
    }
}