namespace MinhaApi.Models;

public record Orcamento
{
    public int Id {get; set;} = default!;
    public int ClienteId  {get; set;} = default!;
    public int FornecedorId {get; set;}
    public string? DescricaoDoServico {get; set;}
    public int ValorTotal {get; set;}
    public string? DataCriacao {get; set;}
    //public DateOnly DataCriacao {get; set;}
    public string? DataExpiracao {get; set;}
    //public DateOnly DataExpiracao {get; set;}
    
}