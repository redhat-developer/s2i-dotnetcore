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
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface INoteService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Note created</response>
        IActionResult NotesBulkPostAsync(Note[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult NotesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Note to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>
        IActionResult NotesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Note to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>
        IActionResult NotesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Note to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>
        IActionResult NotesIdPutAsync(int id, Note item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Note created</response>
        IActionResult NotesPostAsync(Note item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class NoteService : INoteService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public NoteService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">Notes created</response>

        public virtual IActionResult NotesBulkPostAsync(Note[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Note item in items)
            {
                _context.Notes.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>

        /// <response code="200">OK</response>

        public virtual IActionResult NotesGetAsync()
        {
            var result = _context.Notes.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Note to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>

        public virtual IActionResult NotesIdDeletePostAsync(int id)
        {
            var exists = _context.Notes.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Notes.First(a => a.Id == id);
                _context.Notes.Remove(item);
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

        /// <param name="id">id of Note to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>

        public virtual IActionResult NotesIdGetAsync(int id)
        {
            var exists = _context.Notes.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Notes.First(a => a.Id == id);
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

        /// <param name="id">id of Note</param>
        /// <param name="body">body of Note</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>

        public virtual IActionResult NotesIdPutAsync(int id, Note body)
        {
            var exists = _context.Notes.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Notes.Update(body);
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
        /// <response code="201">Note created</response>

        public virtual IActionResult NotesPostAsync(Note body)
        {
            _context.Notes.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
