#pragma warning disable CS1591
public class DefaultResponse
{
    /// <summary>
    /// Status da Requisição, pode ser "Sucesso" ou "Erro"
    /// </summary>
    public string? status { get; set; }

    /// <summary>
    /// Lista de erros caso o status da requisição for de "Erro"
    /// </summary>
    public List<Erro> erros { get; set; }
}