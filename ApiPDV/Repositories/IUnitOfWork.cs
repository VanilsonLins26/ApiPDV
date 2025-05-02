namespace ApiPDV.Repositories
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        Task CommitAsync();
    }
}
