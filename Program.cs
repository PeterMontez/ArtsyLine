using System;
using System.Drawing;

Bitmap BMP = ImgProcess.ImgToBmp("C:/Users/peter/OneDrive/Área de Trabalho/ArtsyLine/img/test1.jpg");

byte[] ByteArr = ImgProcess.BmpToArr(BMP, true);

Drawer drawer = new Drawer(ByteArr, ImgProcess.GetSize(BMP), 100, 100, 100);

drawer.Draw();
drawer.Save("/");

