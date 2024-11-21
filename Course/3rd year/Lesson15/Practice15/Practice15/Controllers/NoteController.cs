using Microsoft.AspNetCore.Mvc;
using Practice15.Interfaces;
using Practice15.Models;

namespace Practice15.Controllers
{
    [ApiController]
    [Route("note")]
    public class NoteController : ControllerBase
    {
        private readonly INoteManager _noteManager;

        public NoteController(INoteManager noteManager)
        {
            _noteManager = noteManager;
        }


        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllNotes()
        {
            return Ok(await _noteManager.GetAllNotes());
        }

        [HttpGet]
        [Route("get/{noteId}")]
        public async Task<IActionResult> GetNoteById(long noteId)
        {
            var needNote = await _noteManager.GetNoteById(noteId);
            if (needNote == null)
            {
                return NotFound("Заметка с таким id не найдена");
            }
            return Ok(needNote);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddNote([FromBody] Note newNote)
        {
            var needNote = await _noteManager.AddNote(newNote);
            if (needNote == null)
            {
                return Ok(newNote);
            }
            return BadRequest("Заметка с таким id уже существует");
        }

        [HttpPost]
        [Route("update/{noteId}")]
        public async Task<IActionResult> UpdateNote(long noteId, string newText)
        {
            var needNote = await _noteManager.UpdateNote(noteId, newText);
            if (needNote != null)
            {
                return Ok(needNote);
            }
            return NotFound("Заметки с такиим id не существует");
        }

        [HttpDelete]
        [Route("delete/{noteId}")]
        public async Task<IActionResult> DeleteNote(long noteId)
        {
            var needNote = await _noteManager.DeleteNote(noteId);
            if (needNote == null)
            {
                return NotFound("Заметка с таким id не найдена");
            }
            return Ok(needNote);
        }
    }
}
