using ApiPDV.Models;
using ApiPDV.Pagination;
using ApiPDV.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPDV.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {

        private readonly IUnitOfWork _uof;

        public ProdutoController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync()
        {
            var produtos = await _uof.ProdutoRepository.GetAllAsync();  
            return Ok(produtos);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync([FromQuery] ProdutosParameters produtosParameters)
        {
            var produtos = await _uof.ProdutoRepository.GetPagedAsync(null,p => p.Nome, produtosParameters.PageNumber, produtosParameters.PageSize);

            return ObterProdutos(produtos);


        }

        [HttpGet("filter/pagination/preco")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync([FromQuery] ProdutosFiltroPreco produtosParameters)
        {
            var produtos = await _uof.ProdutoRepository.GetAllPagFiltroPrecoAsync(produtosParameters);

            return ObterProdutos(produtos);

        }

        [HttpGet("filter/pagination/nome")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync([FromQuery] ProdutosFiltroNome produtosParameters)
        {
            var produtos = await _uof.ProdutoRepository.GetPagedAsync(p => p.Nome.Contains(produtosParameters.Nome), p => p.Nome, produtosParameters.PageNumber, produtosParameters.PageSize);

            return ObterProdutos(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetByIdAsync(int id)
        {
          
            var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);
            if(produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);


        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Create(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            var novoProduto = _uof.ProdutoRepository.Create(produto);
            await _uof.CommitAsync();
            return Ok(novoProduto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Produto>> Put(Produto produto, int id)
        {
            if(produto.Id != id)
                return BadRequest();

            var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
            await _uof.CommitAsync();
            return Ok(produtoAtualizado);

        }

        [HttpDelete]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);
            if (produto is null)
                return NotFound();

            var produtoDeletado = _uof.ProdutoRepository.Delete(produto);
            await _uof.CommitAsync();
            return Ok(produtoDeletado);

        }

        private ActionResult<IEnumerable<Produto>> ObterProdutos(PagedList<Produto> produtos) {
            var metadata = new
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious,
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(produtos);

        }

    }
}
