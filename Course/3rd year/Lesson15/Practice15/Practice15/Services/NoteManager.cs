using Microsoft.EntityFrameworkCore;
using Practice15.Data;
using Practice15.Interfaces;
using Practice15.Models;

namespace Practice15.Services
{
    public class NoteManager : INoteManager
    {
        private readonly NoteContext _notes;
        private readonly DatabaseLoggingManager _dbLogs;
        private readonly ConsoleLoggingManager _conLogs;

        public NoteManager(NoteContext notes, DatabaseLoggingManager dbLogs, ConsoleLoggingManager conLogs)
        {
            _notes = notes;
            _dbLogs = dbLogs;
            _conLogs = conLogs;
        }

        private void LoggingInfo(string info)
        {
            _conLogs.Logging(info);
            _dbLogs.Logging(info);
        }

        public async Task<Note> GetNoteById(long id)
        {
            var needNote = await _notes.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (needNote != null)
            {
                LoggingInfo($"Info message: User1 called GetNoteById with id={id}");
            }
            else
            {
                LoggingInfo($"Error message (404): User1 called GetNoteById, but Note with id={id} is not exists");

            }


            return needNote;
        }

        public async Task<Note> AddNote(Note newNote)
        {
            var addingNote = await _notes.Notes.FirstOrDefaultAsync(x => x.Id == newNote.Id);

            if (addingNote == null)
            {
                await _notes.Notes.AddAsync(newNote);
                await _notes.SaveChangesAsync();

                LoggingInfo($"Info message: User1 called AddNote with id={newNote.Id}");
            }
            else
            {
                LoggingInfo($"Error message (400): User1 called AddNote, with id={newNote.Id}, but it already exists");
            }
            return addingNote;

        }

        public async Task<Note> UpdateNote(long id, string newNoteText)
        {
            var needNote = await _notes.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (needNote != null)
            {
                needNote.Text = newNoteText;
                needNote.Date = DateTime.Now;
                await _notes.SaveChangesAsync();

                LoggingInfo($"Info message: User1 called UpdateNote with id={needNote.Id} newNoteText={newNoteText}");
            }
            else
            {
                LoggingInfo($"Error message (404): User1 called UpdateNote, but Note with id={needNote.Id} is not exists");
            }
            return needNote;

        }
 
        public async Task<Note> DeleteNote(long noteId)
        {
            var needNote = await _notes.Notes.FirstOrDefaultAsync(x => x.Id == noteId);

            if (needNote != null)
            {
                _notes.Notes.Remove(needNote);
                await _notes.SaveChangesAsync();

                LoggingInfo($"Info message: User1 called DeleteNote with id={needNote.Id}");
            }
            else
            {
                LoggingInfo($"Error message (404): User1 called DeleteNote, but Note with id={needNote.Id} is not exists");
            }
            return needNote;
        }

        public async Task<List<Note>> GetAllNotes()
        {
            LoggingInfo($"Info message: User1 called GetAllNotes");

            return await _notes.Notes.ToListAsync();
        }
    }
}
