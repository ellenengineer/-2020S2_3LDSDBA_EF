using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF.Aplicacao;
using EF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF.Controllers
{
    [Route("fapen/produto1")]
    [ApiController]
    public class Produto1Controller : ControllerBase
    {
       private INFONEWContext _contexto;

        public Produto1Controller(INFONEWContext contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<ProdutoController>
        [HttpGet]
        public List<Produto> Get()
        {
            ProdutoAplicacao app = new ProdutoAplicacao(_contexto);
            List<Produto> lstPRodutos = app.GetAllProducts();
            return lstPRodutos;
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{CodProduto}")]
        public Produto Get(int CodProduto)
        {
            ProdutoAplicacao app = new ProdutoAplicacao(_contexto);

            return app.GetProdByID(CodProduto);

        }

        // POST api/<ProdutoController>
        [HttpPost]
        public void Post([FromBody] Produto prd)
        {
    
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Produto prd)
        {
            ProdutoAplicacao app = new ProdutoAplicacao(_contexto);

            if (prd.CodProd < 1)
            {
                app.InserirPRoduto(prd);
            }
            else
            {
                app.UpdateProduct(prd);
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{CodProduto}")]
        public void Delete(int CodProduto)
        {
            ProdutoAplicacao app = new ProdutoAplicacao(_contexto);
            app.DeleteProductByCod(CodProduto);
        }
    }
}
