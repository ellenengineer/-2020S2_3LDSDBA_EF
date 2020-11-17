using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Models;

namespace EF.Aplicacao
{
    public class ProdutoAplicacao
    {
        private INFONEWContext _contexto;

        public ProdutoAplicacao(INFONEWContext contexto)
        {
            _contexto = contexto;
        }

        public string InserirPRoduto(Produto prod)
        {
            try
            {
                if (prod != null)
                {
                    var produtoExiste = GetProdByID(prod.CodProd);

                    if (produtoExiste == null)
                    {
                        _contexto.Add(prod);
                        _contexto.SaveChanges();

                        return "Produto cadastrado com sucesso!";
                    }
                    else
                    {
                        return "produto já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string UpdateProduct(Produto prod)
        {
            try
            {
                if (prod != null)
                {
                    _contexto.Update(prod);
                    _contexto.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Produto GetProdByID(int codProd)
        {
            Produto primeiroProduto = new Produto();

            try
            {
                if (codProd == 0)
                {
                    return null;
                }

                var prd = _contexto.Produtos.Where(x => x.CodProd == codProd).ToList();
                primeiroProduto = prd.FirstOrDefault();

                if (primeiroProduto != null)
                {
                    return primeiroProduto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Produto> GetAllProducts()
        {
            List<Produto> listaDProdutos = new List<Produto>();
            try
            {

                listaDProdutos = _contexto.Produtos.Select(x => x).ToList();

                if (listaDProdutos != null)
                {
                    return listaDProdutos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeleteProductByCod(int codProd)
        {
            try
            {
                if (codProd == 0)
                {
                    return "Produto inválido! Por favor tente novamente.";
                }
                else
                {
                    var prd = GetProdByID(codProd);

                    if (prd != null)
                    {
                        _contexto.Produtos.Remove(prd);
                        _contexto.SaveChanges();

                        return "Produto " + prd.NomeProd + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Produto não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

    }
}

