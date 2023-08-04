namespace TrabalhoBancoDeDados.Entities;

public class Cliente{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public Cidade? Cidade {get; set;}
    public int CidadeId {get; set;}
    public string Telefone {get; set;} = string.Empty;
    public string Endereco {get;set; } = string.Empty;
}