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

namespace Otorino.Controllers
{
    public class ClientesController : ApiController
    {
        private otorinoContext db = new otorinoContext();

        // GET: api/Clientes
        public IQueryable<ClienteDto> GetClientes()
        {
            var clientes = from b in db.Clientes
                           select new ClienteDto()
                           {
                               Id = b.Id,
                               Nombre = b.Nombre,
                               Telefono = b.Telefono,
                               Email = b.Email,
                               Otros = b.Otros,
                               NombreServicio = b.Servicio.Nombre
                           };
            return clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(ClienteDto))]
        public async Task<IHttpActionResult> GetCliente(int id)
        {
            var cliente = await db.Clientes.Include(b => b.Servicio).Select(b => new ClienteDto()
            {
                Id = b.Id,
                Nombre = b.Nombre,
                Telefono = b.Telefono,
                Email = b.Email,
                Otros = b.Otros,
                NombreServicio = b.Servicio.Nombre
            }).SingleOrDefaultAsync(b => b.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(ClienteDto))]
        public async Task<IHttpActionResult> PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
            //new code
            db.Entry(cliente).Reference(x => x.Servicio).Load();
            var dto = new ClienteDto()
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Otros = cliente.Otros,
                NombreServicio = cliente.Servicio.Nombre
            };
            return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, dto);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> DeleteCliente(int id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}