using System;
using CompAndDel.Filters;
using CompAndDel.Pipes;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            PictureProvider pictureProv = new PictureProvider();
            IPicture picture = pictureProv.GetPicture(@"wade.png");

            IFilter filtro1 = new FilterGreyscale();
            IFilter filtro2 = new FilterNegative();

            IPipe pipeFinal = new PipeNull();
            IPipe pipe2 = new PipeSerial(filtro2, pipeFinal);
            IPipe pipeFirst = new PipeSerial(filtro1, pipe2);

            pipeFirst.Send(picture);
            
            // Ejercicio 2
            pictureProv.SavePicture(picture, @"wade1.png");
            pipeFirst = new PipeSerial(filtro1, pipeFinal);
            picture = pipeFirst.Send(picture);
            pictureProv.SavePicture(picture, @"wade2.png");
            pipeFirst = new PipeSerial(filtro1, pipe2);
            picture = pipeFirst.Send(picture);
            pictureProv.SavePicture(picture, @"wade3.png");

        }
    }
}
