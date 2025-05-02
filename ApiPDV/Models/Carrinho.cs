using ApiPDV.Models.Enum;

namespace ApiPDV.Models;

public class Carrinho
{
    public int Id { get; set; }
    public ICollection<ProdutoCarrinho>? Produtos { get; set; }
    public decimal ValorTotalCarrinho { get; set; }
    public StatusCarrinho Situacao { get; set; }
}
