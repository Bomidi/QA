using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiApp.Models;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;

namespace WebApiApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Employee
        public IQueryable<ImpactTempTable> GetImpactTempTables()
        {
            return db.ImpactTempTables;
        }

        // GET: api/Employee/5
        [HttpGet]
        [ResponseType(typeof(ImpactTempTable))]
        public IHttpActionResult GetImpactTempTable(int id)
        {
            ImpactTempTable impactTempTable = db.ImpactTempTables.Find(id);
            if (impactTempTable == null)
            {
                return NotFound();
            }

            return Ok(impactTempTable);
        }

        // PUT: api/Employee/5
        [HttpPut]
       [ResponseType(typeof(void))]
        public IHttpActionResult PutImpactTempTable(int id, ImpactTempTable impactTempTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != impactTempTable.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(impactTempTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpactTempTableExists(id))
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

        // POST: api/Employee
        [HttpPost]
        [ResponseType(typeof(ImpactTempTable))]
        public IHttpActionResult PostImpactTempTable(ImpactTempTable impactTempTable)
        {

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImpactTempTables.Add(impactTempTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = impactTempTable.EmployeeID }, impactTempTable);
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        [ResponseType(typeof(ImpactTempTable))]
        public IHttpActionResult DeleteImpactTempTable(int id)
        {
            ImpactTempTable impactTempTable = db.ImpactTempTables.Find(id);
            if (impactTempTable == null)
            {
                return NotFound();
            }

            db.ImpactTempTables.Remove(impactTempTable);
            db.SaveChanges();

            return Ok(impactTempTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImpactTempTableExists(int id)
        {
            return db.ImpactTempTables.Count(e => e.EmployeeID == id) > 0;
        }
    }
}