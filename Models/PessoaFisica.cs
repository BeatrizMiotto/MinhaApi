namespace MinhaApi.Models;

public record PessoaFisica
{
    public int Id {get; set;} = default!;
    public string Nome  {get; set;} = default!;
    public string? Telefone  {get; set;}
    public string? Cpf {get; set;}
    public DateOnly DataCriacao {get; set;}    
}