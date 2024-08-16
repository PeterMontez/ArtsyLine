using System;
using System.Drawing;

Bitmap BMP = ImgProcess.ImgToBmp("C:/Users/peter/OneDrive/Área de Trabalho/ArtsyLine/img/test2.jpg");

byte[] ByteArr = ImgProcess.BmpToArr(BMP, true);

Drawer drawer = new Drawer(ByteArr, ImgProcess.GetSize(BMP), 140, 100, 4);

drawer.Draw();
drawer.Save("C:/Users/peter/OneDrive/Área de Trabalho/ArtsyLine/img/test.svg");

