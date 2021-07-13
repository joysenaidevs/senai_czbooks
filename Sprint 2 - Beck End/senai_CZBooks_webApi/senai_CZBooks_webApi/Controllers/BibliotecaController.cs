using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
