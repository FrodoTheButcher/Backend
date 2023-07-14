using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesDBService _dbService;

        public NotesController (NotesDBService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("addNote")]
        public async Task<IActionResult> AddNote([FromBody] NoteModel Note)
        {

            await _dbService.CreateAsync(Note);

            return NoContent();
        }
         [HttpPut("updateNote/{id}")]
        public async Task<IActionResult> updateNote(string id,[FromBody] NoteModel Note)
        {

            await _dbService.UpdateAsync(id,Note);

            return NoContent();
        }

        [HttpDelete("deleteNote/{id}")]
        public async Task<IActionResult> DeleteNote(string id)
        {
            await _dbService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("getNotes")]

        public async Task<List<NoteModel>> GetNotes()
        {
            return await _dbService.GetNotes();
        }
    }
}
