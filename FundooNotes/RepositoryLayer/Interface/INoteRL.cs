using CommonLayer.Note;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface  INoteRL
    {

        Task CreateNotes(NotePostModel notePostModel, int Userid);
        NotePostModel UpdateNotes(NotePostModel notes, int NotesId);
        public bool DeleteNotes(int NotesId);
        Task<List<Note>> GetAllNotes();
        public Task Color(int NotesId, string color);
        public Task ArchieveNote(int NotesId);
        public Task PinNote(int NotesId);
        public Task TrashNote(int NotesId);
        public IEnumerable<Note> GetAllNotesByNoteId(int NotesId);

    }
}
