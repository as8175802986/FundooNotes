using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using CommonLayer.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooDbContext dbContext;
       
        public NoteRL(FundooDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task CreateNotes(NotePostModel notePostModel, int Userid)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(x => x.Userid == Userid);

                Note note = new Note();
                note.NotesId = new Note().NotesId;
                note.Userid = Userid;
                note.Title = notePostModel.Title;
                note.Description = notePostModel.Description;
                note.color = notePostModel.color;
                note.IsArchive = false;
                note.IsTrash = false;
                note.IsPin = false;
                note.IsReminder = false;
                note.ModifiedDate = DateTime.Now;
                note.CreatedDate = DateTime.Now;
                dbContext.notes.Add(note);
                await dbContext.SaveChangesAsync();


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
                var UpdateNote = this.dbContext.notes.Where(Y => Y.NotesId == NotesId).FirstOrDefault();
                if (UpdateNote != null)
                {
                    UpdateNote.Title = notes.Title;
                    UpdateNote.Description = notes.Description;
                    UpdateNote.ModifiedDate = DateTime.Now;
                }
                var result = this.dbContext.SaveChanges();
                if (result > 0)
                {
                    return notes;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotes(int NotesId)
        {
            try
            {
                var ValidNote = this.dbContext.notes.Where(Y => Y.NotesId == NotesId).FirstOrDefault();
                this.dbContext.notes.Remove(ValidNote);
                int result = this.dbContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Note>> GetAllNotes()
        {
            return await dbContext.notes.ToListAsync();
        }

        public async Task ArchieveNote(int NotesId)
        {
            try
            {
                var note = dbContext.notes.FirstOrDefault(u => u.NotesId == NotesId);
                note.IsArchive = true;
                await dbContext.SaveChangesAsync();

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
                var note = dbContext.notes.FirstOrDefault(u => u.NotesId == NotesId);
                note.color = color;
                 await dbContext.SaveChangesAsync();
                 await dbContext.notes.ToListAsync();
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
                var note = dbContext.notes.FirstOrDefault(x => x.NotesId == NotesId);
                if (note != null)
                {
                    note.IsPin = true;

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task TrashNote(int NotesId)
        {
            try
            {
                Note note = dbContext.notes.FirstOrDefault(e => e.NotesId == NotesId);
                if (note != null)
                {
                    note.IsTrash = true;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Note> GetAllNotesByNoteId(int NotesId)
        {
            return dbContext.notes.Where(Y => Y.NotesId == NotesId).ToList();
        }



    }
   
}
