using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cripto.Models;

namespace CriptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly CryptoContext1 db;

        public QueryController(CryptoContext1 context)
        {
            db = context;
        }

        [HttpGet("0")]
        public ActionResult Query0(int ValorActual = 50)
        {
            // LA QUERY
            var list = db.Moneda.ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("1")]
        public async Task<ActionResult> Query1()
        {
            // LA QUERY
            var list = await db.Moneda.Where(a => a.Actual > 50).OrderBy(a => a.MonedaId).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 1,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("2")]
        public async Task<ActionResult> Query2()
        {
            // LA QUERY
            var list = await db.Contrato.GroupBy(a => a.CarteraId).Select(a => new
                {
                    carteraId = a.Key,
                    TotalMonedas = a.Count()
                }).Where(c => c.TotalMonedas > 2).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 2,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("3")]
        public async Task<ActionResult> Query3()
        {
            // LA QUERY
            var list = await db.Cartera.GroupBy(a => a.Exchange).Select(s => new
                {
                    Exchange = s.Key,
                    TotalCarteras = s.Select(a => a.CarteraId).Count()
                }).OrderByDescending(o => o.TotalCarteras).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 3,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("4")]
        public async Task<ActionResult> Query4()
        {
            // LA QUERY
            var list = await db.Cartera.SelectMany(al => al.contratos, (a, m) => new
                {
                    Exchange = a.Exchange,
                    TotalMonedas = m.Cantidad
                }).GroupBy(g => g.Exchange).Select(s => new
                {
                    Exchange = s.Key,
                    TotalMonedas = s.Key.ToList().Count
                }).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 4,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("5")]
        public async Task<ActionResult> Query5()
        {
            // LA QUERY
            var list = await db.Moneda.SelectMany(sm => sm.contratos, (c, cr) => new
                {
                    Moneda = c.MonedaId,
                    Contrato = cr.ContratoId,
                    ValorActual = c.Actual
                }).Select(a => new
                {
                    Moneda = a.Moneda,
                    Contrato = a.Contrato,
                    ValorActual = a.ValorActual
                }).OrderBy(o => o.ValorActual).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 5,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("6")]
        public async Task<ActionResult> Query6()
        {
            // LA QUERY
            var list = await db.Moneda.SelectMany(sm => sm.contratos, (c, cr) => new
                {
                    Moneda = c.MonedaId,
                    Contrato = cr.ContratoId,
                    ValorActual = c.Actual
                }).Select(a => new
                {
                    Moneda = a.Moneda,
                    Contrato = a.Contrato,
                    ValorActual = a.ValorActual
                }).OrderBy(o => o.ValorActual).GroupBy(g => g.Moneda).Select(s => new
                {
                    Moneda = s.Key,
                    ValorTotal = s.Sum(ms => ms.ValorActual)
                }).OrderByDescending(o => o.ValorTotal).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 6,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("7")]
        public async Task<ActionResult> Query7()
        {
            // LA QUERY
            var list = await db.Moneda.SelectMany(sm => sm.contratos, (c, cr) => new
                {
                    Moneda = c.MonedaId,
                    Contrato = cr.ContratoId,
                    ValorActual = c.Actual,
                }).GroupBy(g => g.Moneda).Select(a => new
                {
                    Moneda = a.Key,
                    Contrato = a.Count(),
                    ValorActual = a.Select(a=>a.ValorActual).Sum(),                    
                  }).OrderBy(o => o.Contrato).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 7,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("8")]
        public async Task<ActionResult> Query8()
        {
            // LA QUERY
            var list = await db.Moneda.SelectMany(sm => sm.contratos, (c, cr) => new
                {
                    Moneda = c.MonedaId,
                    Contrato = cr.ContratoId,
                    ValorActual = c.Actual,
                }).GroupBy(g => g.Moneda).Select(a => new
                {
                    Moneda = a.Key,
                    Contrato = a.Count(),
                    ValorActual = a.Select(a=>a.ValorActual).Sum(),                    
                  }).OrderByDescending(o => o.Contrato).ToListAsync();
            ;

            return Ok(new
            {
                ValorActual = 8,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("9")]
        public async Task<ActionResult> Query9()
        {
            // LA QUERY
            var list = await db.Cartera.Where(s=>s.Exchange=="Binance")
                .SelectMany(s=>s.contratos, (ca,co)=>new{
                    Moneda= co.MonedaId,
                    Contrato=co.MonedaId + "-"+co.CarteraId,
                    Maximo=co.moneda.Maximo,
                    Actual=co.moneda.Actual,
                    porcentaje= co.moneda.Actual * 100 /co.moneda.Maximo
                }).Where(w=>w.porcentaje<90).ToListAsync();
            ;
            return Ok(new
            {
                ValorActual = 9,
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
    }
}
