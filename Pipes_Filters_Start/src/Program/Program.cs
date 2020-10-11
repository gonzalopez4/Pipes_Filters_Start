using System;
using CompAndDel.Filters;
using CompAndDel.Pipes;
using TwitterUCU;

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

            // pipeFirst.Send(picture);
            
            // Ejercicio 2
            IFilter guardar = new Persistent();
            
            IPipe pipe5 = new PipeSerial(guardar, pipeFinal);
            IPipe pipe4 = new PipeSerial(filtro2, pipe5);
            IPipe pipe3 = new PipeSerial(guardar, pipe4);
            pipe2 = new PipeSerial(filtro1, pipe3);
            pipeFirst = new PipeSerial(guardar, pipe2);

            // pipeFirst.Send(picture);

            // Ejercicio 3
            IFilter publish = new Publish();
            
            IPipe pipe8 = new PipeSerial(publish, pipeFinal);
            IPipe pipe7 = new PipeSerial(guardar, pipe8);
            IPipe pipe6 = new PipeSerial(filtro2, pipe7);
            pipe5 = new PipeSerial(publish, pipe6);
            pipe4 = new PipeSerial(guardar, pipe5);
            pipe3 = new PipeSerial(filtro1, pipe4);
            pipe2 = new PipeSerial(publish, pipe3);
            pipeFirst = new PipeSerial(guardar, pipe2);

            // pipeFirst.Send(picture);

            // Ejercicio 4
            IFilterConditional filtro3 = new FilterConditional();
            
            pipe4 = new PipeSerial(guardar, pipeFinal);
            IPipe pipeB = new PipeSerial(filtro2, pipe4);
            IPipe pipeA = new PipeSerial(filtro1, pipe4);
            pipe2 = new PipeConditional(filtro3, pipeA, pipeB);
            pipeFirst = new PipeSerial(guardar, pipe2);
            
            pipeFirst.Send(picture);
        }
    }
}
