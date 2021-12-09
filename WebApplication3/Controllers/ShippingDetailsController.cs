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
    public class ShippingDetailsController : ApiController
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: api/ShippingDetails
        public IQueryable<ShippingDetails> GetShippingDetails()
        {
            return db.ShippingDetails;
        }

        // GET: api/ShippingDetails/5
        [ResponseType(typeof(ShippingDetails))]
        public async Task<IHttpActionResult> GetShippingDetails(int id)
        {
            ShippingDetails shippingDetails = await db.ShippingDetails.FindAsync(id);
            if (shippingDetails == null)
            {
                return NotFound();
            }

            return Ok(shippingDetails);
        }

        // PUT: api/ShippingDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShippingDetails(int id, ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shippingDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(shippingDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingDetailsExists(id))
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

        // POST: api/ShippingDetails
        [ResponseType(typeof(ShippingDetails))]
        public async Task<IHttpActionResult> PostShippingDetails(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShippingDetails.Add(shippingDetails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shippingDetails.Id }, shippingDetails);
        }

        // DELETE: api/ShippingDetails/5
        [ResponseType(typeof(ShippingDetails))]
        public async Task<IHttpActionResult> DeleteShippingDetails(int id)
        {
            ShippingDetails shippingDetails = await db.ShippingDetails.FindAsync(id);
            if (shippingDetails == null)
            {
                return NotFound();
            }

            db.ShippingDetails.Remove(shippingDetails);
            await db.SaveChangesAsync();

            return Ok(shippingDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShippingDetailsExists(int id)
        {
            return db.ShippingDetails.Count(e => e.Id == id) > 0;
        }
    }
}