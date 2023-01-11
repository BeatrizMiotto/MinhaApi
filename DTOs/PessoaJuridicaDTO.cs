
namespace MinhaApi.DTOs;

public record PessoaJuridicaDTO
{
    public int Id {get; set;} = default!;
    public string Nome  {get; set;} = default!;
    public string? Telefone  {get; set;}
    public string? Cnpj {get; set;}
    public DateOnly DataCriacao {get; set;}    
}