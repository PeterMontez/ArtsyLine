using System;
using System.Drawing;

Bitmap BMP = ImgProcess.ImgToBmp("C:/Users/peter/OneDrive/Área de Trabalho/ArtsyLine/img/profile.jpg");

byte[] ByteArr = ImgProcess.BmpToArr(BMP, false);

Drawer drawer = new Drawer(ByteArr, ImgProcess.GetSize(BMP), 120, 100, 2);

drawer.Draw();
drawer.Save("C:/Users/peter/OneDrive/Área de Trabalho/ArtsyLine/img/test.svg");

