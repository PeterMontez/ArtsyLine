
# ArtsyLine

ArtsyLine converts any picture to an artistic monochrome line art SVG.

The end result is a picture made from a group of horizontal lines with little *wiggles* (a triangular wave pattern), that when looked from a distance, result in lighter or darker areas depending in the amplitude of the wave.

The SVG format was chosen so it would be possible to later convert it to GCODE to run in a pen ploter or CNC machine.



## More Info

The program analyses the image pixel by pixel according to the number of lines and compression you wish to have.
- The number of lines is the amount of *drawn* lines you wish to have in your final file.
- The compression is how many pixels, horizontally, will be averaged together per *wiggle*.


Different parameters will generate completely different results.
During testing, I noticed that the best results were found between 120 and 150 lines, and the horizontal compression varies depending on the size of the original image.

It was also clear from multiple tests that the high resolution images don't yield better results. 500x500 pixels is more than enough, and anything higher will just result in more processing time with minimum improvements in detail in the final image.

## Demo

I used my profile picture as an example to demonstrate what it actually does.
This is a 400x400 image, converted to black and white. To yield better results, you can play with the image curves in order to accentuate the tones you want (although not necessary).
![Original Image](https://github.com/PeterMontez/ArtsyLine/blob/main/img/profile.jpg?raw=true)


This is a screenshot of the final generated image. The full size SVG generated file is on https://github.com/PeterMontez/ArtsyLine/blob/main/img/test.svg
![Generated Image]([https://github.com/PeterMontez/ArtsyLine/blob/main/img/test.svg](https://github.com/PeterMontez/ArtsyLine/blob/main/img/Generated%20Image%20Example.png)?raw=true)

## How to Run

Download this project to your machine.
I'm using dotnet 8, but it should work just fine in dotnet 7.

On program.cs, you will find everything you need to change to create your own image.

Change the original image path and also the path to save the generated SVG, and edit the parameters on line 8.

```c#
Drawer drawer = new Drawer(ByteArr, ImgProcess.GetSize(BMP), 120, 100, 2);
```

The only values that need adjustment are the last 3, which are, respectively:
- Amount of lines you want in your final drawing;
- General amplitude of the wave pattern (still not implemented, always considers 100%);
- Horizontal compression (see *More Info* section for explanation).
## Known bugs and issues

There are a few problems in this project I'm planning to fix in the future:

- The amount of drawn lines must be at least 30% of the original image height, or else the program fails (this changes a little depending on the original image size);
- If you try to use 1 as the horizontal compression, you get a sawtooth wave pattern instead of a triagular one;
- Unless your amount of lines is a perfect multiple of the image height, the remainder of lines will be ignored. I.E. if you choose to draw 100 lines in an image with height 1001, the last row of pixels on the original image will be ignored.

The program works fine for now (at least for the purpose I need), so I'm not in a hurry to fix these issues.
They shouldn't be hard to fix, so if you want a little challenge, feel free to tackle them!

