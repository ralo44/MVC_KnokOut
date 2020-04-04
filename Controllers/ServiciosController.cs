using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using otorino.Models;

namespace Otori.Controllers
{
    public class ServiciosController : ApiController
    {
        private otorinoContext db = new otorinoContext();

        // GET: api/Servicios
        public IQueryable<ServicioDto> GetServicios()
        {
            var services = from b in db.Servicios
                           select new ServicioDto()
                           {
                               Id = b.Id,
                               Nombre = b.Nombre
                           };
            return services;
        }

        // GET: api/Servicios/5
        [ResponseType(typeof(ServicioDetailDto))]
        public async Task<IHttpActionResult> GetServicio(int id)
        {
            var service = await db.Servicios.Include(b => b.Nombre).Select(b =>
                new ServicioDetailDto()
                {
                    Id = b.Id,
                    Nombre = b.Nombre,
                    Descripcion = b.Descripcion
                    //Imagen = b.Imagen
                }).SingleOrDefaultAsync(b => b.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(service);
            }
        }

        // PUT: api/Servicios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServicio(int id, Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicio.Id)
            {
                return BadRequest();
            }

            db.Entry(servicio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Servicios
        [ResponseType(typeof(Servicio))]
        public async Task<IHttpActionResult> PostServicio(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = servicio.Id }, servicio);
        }

        // DELETE: api/Servicios/5
        [ResponseType(typeof(Servicio))]
        public async Task<IHttpActionResult> DeleteServicio(int id)
        {
            Servicio servicio = await db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            db.Servicios.Remove(servicio);
            await db.SaveChangesAsync();

            return Ok(servicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServicioExists(int id)
        {
            return db.Servicios.Count(e => e.Id == id) > 0;
        }
    }
}