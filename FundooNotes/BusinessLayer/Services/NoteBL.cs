using BusinessLayer.Interface;
using CommonLayer.Note;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL NoteRL;
        public NoteBL(INoteRL NoteRL)
        {
            this.NoteRL = NoteRL;
        }

        public async Task CreateNotes(NotePostModel notePostModel, int Userid)
        {
            try
            {
                await NoteRL.CreateNotes(notePostModel, Userid);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DeleteNotes(int NotesId)
        {
            try
            {
                return NoteRL.DeleteNotes(NotesId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public NotePostModel UpdateNotes(NotePostModel notes, int NotesId)
        {
            try
            {
                return NoteRL.UpdateNotes(notes, NotesId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<List<Note>> GetAllNotes()
        {
            try
            {
                return await NoteRL.GetAllNotes();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task Color(int NotesId, string color)
        {
            try
            {
                await NoteRL.Color(NotesId, color);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ArchieveNote(int NotesId)
        {
            try
            {
                await NoteRL.ArchieveNote(NotesId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task PinNote(int NotesId)
        {
            try
            {
                await NoteRL.PinNote(NotesId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task TrashNote(int NotesId)
        {
            try
            {
                await NoteRL.TrashNote(NotesId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Note> GetAllNotesByNoteId(int NotesId)
        {
            try
            {
                return NoteRL.GetAllNotesByNoteId(NotesId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
