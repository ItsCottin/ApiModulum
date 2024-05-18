#pragma warning disable CS1591
public class Erro
{
    /// <summary>
    /// Código do erro
    /// </summary>
    public string? codigo { get; set; }

    /// <summary>
    /// Descrição do erro, pode ser uma mensagem de crítica ou Exception não tratada devidamente.
    /// </summary>
    public string? detalhe { get; set; }
}
