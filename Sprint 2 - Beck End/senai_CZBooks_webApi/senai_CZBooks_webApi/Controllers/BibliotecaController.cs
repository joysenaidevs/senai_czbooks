using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using senai_CZBooks_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Controllers
{
    /// <summary>
    /// Controlador responsavel pelas bibliotecas
    /// </summary>

    // define que a aplicacao será no formato json
    [Produces("application/json")]

    // define a rota da api
    [Route("api/[controller]")]

    //define que é um controlador API
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        /// <summary>
        /// Objeto _bibliotecaRepository que irá receber todos os métodos definidos na interface IBibliotecaRepository
        /// </summary>
        private IBibliotecaRepository _bibliotecaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _bibliotecaRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public BibliotecaController()
        {
            _bibliotecaRepository = new BibliotecaRepository();
        }

        /// <summary>
        /// Lista de todas as bibliotecas
        /// </summary>
        /// <returns>retorna uma lista de bibliotecas com status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna uma lista com status code 200
                return Ok(_bibliotecaRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma biblioteca através do seu ID
        /// </summary>
        /// <param name="id">id da biblioteca buscada</param>
        /// <returns>stauts code 200</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //tratamento de excessao
            try
            {
                // retorna uma biblioteca através do seu id e um status code 200
                return Ok(_bibliotecaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca">objeto que seraá cadastrado</param>
        /// <returns>stauts code 200</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Biblioteca  novaBiblioteca)
        {
            try
            {
            // faz a chamada para o método
            _bibliotecaRepository.Cadastrar(novaBiblioteca);

            //retorna um status code 201
            return StatusCode(201);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza uma biblioteca existente
        /// </summary>
        /// <param name="id">id da biblioteca atualizada</param>
        /// <param name="bibliotecaUpdate">objeto que será atualizado</param>
        /// <returns>retorna um status code 204</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Biblioteca bibliotecaUpdate )
        {
            //tratamento de excessao
            try
            {
                // faz a chamada para o método
                _bibliotecaRepository.Atualizar(id, bibliotecaUpdate);

                //retorna um stauts code 204
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }




        /// <summary>
        /// deleta uma biblioteca existente
        /// </summary>
        /// <param name="id">id da biblioteca deletada</param>
        /// <returns>retorna um status code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //tratamento de excessao
            try
            {
            // faz a chamada para o método
            _bibliotecaRepository.Deletar(id);

            //retorna um status code 204
            return StatusCode(204);

            }
            catch (Exception ex)
            {
                //retorna um badrequest 400 erro
                return BadRequest(ex);
            }
        }
    }
}
