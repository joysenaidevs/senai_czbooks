using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using senai_CZBooks_webApi.LoginViewModels;
using senai_CZBooks_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos Logins
    /// </summary>
    

    //define que a API sera no formato JSON
    [Produces("application/json")]

    // DEFINE A ROTA DA API
    [Route("api/[controller]")]

    // DEFINE QUE E UM CONTROLADOR API
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IuUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// dominio/api/Login

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {

                // informações do usuario
                //Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // caso nao encontre um usuario ou email e a senha
                //if (usuarioBuscado == null)
                //{
                //    // retorna um notFound com mensagem personalizada
                //    return NotFound("Email ou senha inválidos!");
                //}

                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                Autor autorLogin = new Autor();

                Usuario clienteLogin = new Usuario();


                if (usuarioBuscado.IdTipoUsuario == 2)
                {
                    autorLogin = _usuarioRepository.BuscarAutorId(usuarioBuscado.IdUsuario);
                }

                if (usuarioBuscado.IdTipoUsuario == 3)
                {
                   clienteLogin = _usuarioRepository.BuscarClienteId(usuarioBuscado.IdUsuario);
                }

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }


                //caso seja encontrado, cria o token

                /*
                    Dependencias:
                    Criar e validar o Token:    System.IdentityModel.Tokens.Jwt
                    Integrar a autentiação :    Microsoft.AspNetCore.Authentication.JwtBearer
                   
                 */

                // criando uma variavel chamada claims do tipo arrays
                // define os dados que serao fornecidos no Token - Payload
                var claim = new[]
                {
                     // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum) de forma personalizada
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)



                    //     criando uma nova claim para armazenar o email do usuario
                    //     PEGANDO O Email do usuario buscado do banco de dados atraves do email e da senha
                   // e esta sendo armazenado na primeira claim
                    //new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    //// armazena na claim o id do usuario autenticado
                    //new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    //// armazenando o idTipoUsuario ex: 1
                    //new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    //  // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum) de forma personalizada
                    //new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                   // new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario),

                   //new Claim("NomeAutor", usuarioBuscado.IdTipoUsuario == 2 ? $"{autorLogin.IdUsuario}" : "" ),

                   //new Claim("NomeCliente", usuarioBuscado.IdTipoUsuario == 3 ? $"{usuarioBuscado.IdTipoUsuario}" : "" )
                };

                // define o acesso ao token     gerando a chave
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("czbook-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var gerarToken = new JwtSecurityToken(

                    issuer: "CZBook.webApi",                     // emissor do token
                    audience: "czbook.webApi",                // destinátario do token
                    claims: claim,                                  // dados da claim (email, idUsuario e idTipoUsuario)
                    expires: DateTime.Now.AddMinutes(50),           // tempo de expiração
                    signingCredentials: creds                       // credenciais         
                );

                //  retorna Ok com o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(gerarToken)
                });
            }
            catch (Exception ex)
            {
                // caso  seja encontrado ou ocorra algum erro , retorna a exception
                return BadRequest(ex);
            }
        }
    }
}
