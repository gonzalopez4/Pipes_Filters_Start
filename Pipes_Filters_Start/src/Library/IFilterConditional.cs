namespace CompAndDel
{
    /// <summary>
    /// Un filtro grafico.
    /// </summary>
    /// <remarks>
    /// Un filtro procesa una imagen, creando opcionalmente una nueva imagen.
    /// </remarks>
    public interface IFilterConditional : IFilter
    {
        bool condition { get; set; }
    }
}
