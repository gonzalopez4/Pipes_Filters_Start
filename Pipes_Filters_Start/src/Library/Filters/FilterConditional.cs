using System;
using System.Drawing;
using System.Diagnostics;
using CompAndDel;
using SixLabors.ImageSharp;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilterConditional
    {
        /// <summary>
        /// Recibe una imagen y la retorna con un filtro de escala de grises aplicado.
        /// </summary>
        /// <param name="image">Imagen a la que se le va a aplicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado.</returns>
        
        public bool condition { get; set; }
        public IPicture Filter(IPicture image)
        {
            Debug.Assert(image != null);
            CognitiveFace cog = new CognitiveFace("a36648d3c5134ab692acd35605d491f7", false);
            cog.Recognize(image.Path);
            condition = false;
            if(cog.FaceFound)
            {
                condition = true;
            }
            return image;
        }
    }
}