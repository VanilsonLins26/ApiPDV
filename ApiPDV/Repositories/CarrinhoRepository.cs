using ApiPDV.Context;
using ApiPDV.Models;

namespace ApiPDV.Repositories
{
    public class CarrinhoRepository : Repository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(AppDbContext context) : base(context) { }


    }
}
