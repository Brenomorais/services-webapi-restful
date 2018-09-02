using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    /***
     * RoutePrefix: Determina a rota de acesso ao controller: Url: http://localhost:porta/api/usuario/metodo 
     * AcceptVerbs: Determina o tipo do método http que o método do Controller vai responder.
     * Route: Determina o nome para acesso ao método, o nome pode ser o nome do método ou qualquer outro nome
     * Outra opção é usar as anotações: HttpPost, HttpPut, HttpDelete e HttpGet vai funcionar da mesma forma.
     **/

    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {

        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Add(usuario);

            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Where(n => n.Codigo == usuario.Codigo)
                         .Select(s =>
                         {
                             s.Codigo = usuario.Codigo;
                             s.Login = usuario.Login;
                             s.Nome = usuario.Nome;

                             return s;

                         }).ToList();

            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {

            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .First();

            listaUsuarios.Remove(usuario);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public UsuarioModel ConsultarUsuarioPorCodigo(int codigo)
        {

            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .FirstOrDefault();

            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<UsuarioModel> ConsultarUsuarios()
        {
            return listaUsuarios;
        }

    }
}
