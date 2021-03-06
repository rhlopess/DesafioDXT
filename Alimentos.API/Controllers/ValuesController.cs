﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimentos.API.Models;
using Alimentos.Dominio;
using Alimentos.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IAlimentosRepositorio _alrep;
        public ValuesController(IAlimentosRepositorio alrep)
        {
            _alrep = alrep;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
               var results = _alrep.RetornaCardapio();               
               return Ok(results);
           }
           catch (System.Exception ex)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta GET não está funcionando." + ex);
           }     
        }

        [HttpGet("getIngredientes")]
        public async Task<IActionResult> GetIngredientes()
        {
           try
           {
               var results = _alrep.RetornaIngredientes();               
               return Ok(results);
           }
           catch (System.Exception ex)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta GET não está funcionando." + ex);
           }     
        }

        [HttpGet("{cardapioId}")]
        public async Task<IActionResult> Get(int cardapioId)
        {
           try
           {
               var results = _alrep.RetornaCardapioById(cardapioId);               
               return Ok(results);
           }
           catch (System.Exception ex)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta GET não está funcionando." + ex);
           }     
        }
        
        [HttpGet("{idIngrediente},{valor},{qtd},{idLanche}")]
        public async Task<IActionResult> Get(int idIngrediente, decimal valor, int qtd, int idLanche)
        {
           try
           {
               var results = _alrep.CalculaValorLanchePromocao(idIngrediente, valor, qtd, idLanche);               
               return Ok(results);
           }
           catch (System.Exception ex)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta GET não está funcionando." + ex);
           }     
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pedido pedido)
        {
           try
           {                
               return Ok();
           }
           catch (System.Exception)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta não está funcionando.");
           }     
        }
    }
}
