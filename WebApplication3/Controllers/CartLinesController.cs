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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class CartLinesController : ApiController
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: api/CartLines
        public IQueryable<CartLine> GetCartLines()
        {
            return db.CartLines;
        }

        // GET: api/CartLines/5
        [ResponseType(typeof(CartLine))]
        public async Task<IHttpActionResult> GetCartLine(int id)
        {
            CartLine cartLine = await db.CartLines.FindAsync(id);
            if (cartLine == null)
            {
                return NotFound();
            }

            return Ok(cartLine);
        }

        // PUT: api/CartLines/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCartLine(int id, CartLine cartLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartLine.id)
            {
                return BadRequest();
            }

            db.Entry(cartLine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartLineExists(id))
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

        // POST: api/CartLines
        [ResponseType(typeof(CartLine))]
        public async Task<IHttpActionResult> PostCartLine(CartLine cartLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartLines.Add(cartLine);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cartLine.id }, cartLine);
        }

        // DELETE: api/CartLines/5
        [ResponseType(typeof(CartLine))]
        public async Task<IHttpActionResult> DeleteCartLine(int id)
        {
            CartLine cartLine = await db.CartLines.FindAsync(id);
            if (cartLine == null)
            {
                return NotFound();
            }

            db.CartLines.Remove(cartLine);
            await db.SaveChangesAsync();

            return Ok(cartLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartLineExists(int id)
        {
            return db.CartLines.Count(e => e.id == id) > 0;
        }
    }
}