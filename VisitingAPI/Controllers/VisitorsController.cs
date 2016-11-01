using System.Linq;
using System.Web.Http;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using VisitingAPI.Models;
using VisitingAPI.Mongo;
using System;
using System.Net;

namespace VisitingAPI.Controllers
{
    public class VisitorsController : ApiController
    {
        private readonly VisitingContext _ctx = new VisitingContext();
        public IHttpActionResult Get()
        {
            try
            {
                var visits = _ctx.Visits.AsQueryable().ToList();

                if (visits.Any())
                {
                    return Ok(visits);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string siteUrl)
        {
            try
            {
                var visits = _ctx.Visits.AsQueryable().Where(b => b.SiteUrl == siteUrl).ToList();

                if (visits.Any())
                {
                    return Ok(visits);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string siteUrl, string state)
        {
            try
            {
                var visits = _ctx.Visits.AsQueryable().Where(b => b.SiteUrl == siteUrl && b.State == state).ToList();

                if (visits.Any())
                {
                    return Ok(visits.Distinct());
                }
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post(Visit value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }

                _ctx.Visits.InsertOne(value);
                return Created(Request.RequestUri + value.SiteUrl, value);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(string siteUrl)
        {
            try
            {
                var filter = Builders<Visit>.Filter.Eq("SiteUrl", siteUrl);

                _ctx.Visits.DeleteMany(filter);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
