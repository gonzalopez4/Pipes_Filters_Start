# Universidad Católica del Uruguay
# Facultad de Ingeniería y Tecnologías
# Programación II
## Libreria de Reconocimiento Facial
Esta libreria utiliza el servico de Face detection de los Cognitive Services (https://azure.microsoft.com/en-us/services/cognitive-services/face/) para encontrar caras en las fotos.
Para ello, se utiliza la clase ```CognitiveFace```, la cual recibe por parametro una imagen (path donde se ubica en disco) y la envia a traves de una llamada REST a la API para detectar si la misma contiene o no una cara. 
En caso de encotrar una, la propiedad ```FaceFound``` de la clase anterior indicará el resultado. Si además, se indicó mendiante la propiedad ```MarkFaces = true```, la libreria almacenará una nueva copia de la imagen bajo el nombre tmpFace.jpg con un recuadro dibujado alrededor del rostro encontrado.
Adicionalmente, si se detecta una sonrisa en la cara encontrada, esto se indicará marcando la propiedad ```SmileFound``` como ```true```

### Ejemplo de uso:
```c#
static void Main(string[] args)
{
    //Se debe pasar por parametro la API Key y el color del recuadro a dibujar 
    //en caso de encontrar una cara en la foto
    CognitiveFace cog = new CognitiveFace("<api-key>", true, Color.GreenYellow);
    cog.Recognize(@"bill.jpg");
    FoundFace(cog);
    cog.Recognize(@"yacht.jpg");
    FoundFace(cog);
    cog.Recognize(@"bill2.jpg");
    FoundFace(cog);
}
static void FoundFace(CognitiveFace cog)
{
    if (cog.FaceFound)
    {
        Console.WriteLine("Face Found!");
        if (cog.SmileFound)
        {
            Console.WriteLine("Found a Smile :)");
        }
        else
        {
            Console.WriteLine("No smile found :(");
        }
    }
    else
        Console.WriteLine("No Face Found");
}
```