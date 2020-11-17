using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Models;

namespace EF.Aplicacao
{
    public class UsuarioAplicacao
    {
        private INFONEWContext _contexto;


        public UsuarioAplicacao(INFONEWContext contexto)
        {
            _contexto = contexto;
        }


        public string InserirCliente(Login login)
        {
            try
            {
                if (login != null)
                {
                    var usuarioExiste = GetUserByLogin (login.Login1,login.Senha);

                    if (usuarioExiste == null)
                    {
                        _contexto.Add(login);
                        _contexto.SaveChanges();

                        return "Cliente cadastrado com sucesso!";
                    }
                    else
                    {
                        return "cliente já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Cliente inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string AtualizarCliente(Login login)
        {
            try
            {
                if (login != null)
                {
                    _contexto.Update(login);
                    _contexto.SaveChanges();

                    return "Cliente alterado com sucesso!";
                }
                else
                {
                    return "Cliente inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Login GetUserByLogin(string login, string senha)
        {
            Login usuarioLogado = new Login();

            try
            {
                if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(senha))
                {
                    return null;
                }

                var ustLogin = _contexto.Logins.Where(x => x.Login1 == login && x.Senha == senha).ToList();
                usuarioLogado = ustLogin.FirstOrDefault();

                if (usuarioLogado != null)
                {
                    return usuarioLogado;
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
    
    }
}
