using Practice15.Models;

namespace Practice15.Interfaces
{
    public interface INoteManager
    {
        public Task<Note> AddNote(Note newNote);
        public Task<Note> DeleteNote(long noteId);
        public Task<Note> GetNoteById(long noteId);
        public Task<List<Note>> GetAllNotes();
        public Task<Note> UpdateNote(long noteId, string newNoteTest);

    }
}
