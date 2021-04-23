using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Context;
using Api1.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api1.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]

    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/listado")]

        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList(); 
        }

        [HttpGet("{id}",Name ="ObtenerAutor")]
        
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if(autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]

        public ActionResult Post([FromBody] Autor autor)
        {
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);
        }

        [HttpPut]
        public ActionResult<Autor> Put(int id, [FromBody] Autor value)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if (id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }
    }
}
