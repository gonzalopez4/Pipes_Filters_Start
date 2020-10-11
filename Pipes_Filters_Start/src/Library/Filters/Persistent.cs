using System;
using System.Drawing;
using System.Diagnostics;
using CompAndDel;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CompAndDel.Filters
{
    public class Persistent : IFilter
    {
        /// <summary>
        /// Recibe una imagen, la guarda y la retorna
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado</returns>

        private int saves = 0;
        private int numReplace = 4;
        public IPicture Filter(IPicture image)
        {
            if(saves > 0)
            {
                numReplace = 5;
            }
            string format = image.Path.Remove(0, image.Path.Length - 4); // format = ".png"
            new PictureProvider().SavePicture(image, image.Path = image.Path.Remove(image.Path.Length - numReplace) + saves.ToString() + format); // guarda la imagen con diferente nombre cada vez ( "nombre" + numero + ".png" )
            saves ++;
            return image;
        }
    }
}