/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHistoryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of History to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>
        IActionResult HistoriesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of History to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>
        IActionResult HistoriesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of History to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>
        IActionResult HistoriesIdPutAsync(int id, History item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        IActionResult HistoriesPostAsync(History item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class HistoryService : ServiceBase, IHistoryService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public HistoryService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of History to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>

        public virtual IActionResult HistoriesIdDeletePostAsync(int id)
        {
            var exists = _context.Historys.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Historys.First(a => a.Id == id);
                _context.Historys.Remove(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of History to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>

        public virtual IActionResult HistoriesIdGetAsync(int id)
        {
            var exists = _context.Historys.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Historys.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of History</param>
        /// <param name="body">body of History</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>

        public virtual IActionResult HistoriesIdPutAsync(int id, History body)
        {
            var exists = _context.Historys.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Historys.Update(body);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(body);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="body"></param>
        /// <response code="201">History created</response>

        public virtual IActionResult HistoriesPostAsync(History body)
        {
            _context.Historys.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
