using BusinessLayer.Interface;
using CommonLayer.Note;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services;
using RepositoryLayer.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("Note")]

    public class NoteController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        FundooDbContext fundooDBContext;
        INoteBL NoteBL;
        public NoteController(INoteBL NoteBL, FundooDbContext fundooDb, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.NoteBL = NoteBL;
            this.fundooDBContext = fundooDb;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        [Authorize]
        [HttpPost("addnotes")]
        public async Task<ActionResult> CreateNotes(NotePostModel notePostModel)
        {
            try
            {
                //var Userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                //int userid = Int32.Parse(Userid.Value);
                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                await this.NoteBL.CreateNotes(notePostModel, Userid);

                return this.Ok(new { success = true, message = $"Note Created Sucessfully" });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("updatenotes/{NotesId}")]
        public IActionResult UpdateNotes(NotePostModel notes, int NotesId)
        {
            try
            {
                var result = NoteBL.UpdateNotes(notes, NotesId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Updating a note Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to Update a note" });
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpDelete("deletenotes/{NotesId}")]
        public IActionResult DeleteNotes(int NotesId)
        {
            try
            {
                if (NoteBL.DeleteNotes(NotesId))
                {
                    return this.Ok(new { Success = true, message = "Note Deleted  Sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to delete the note" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("getAllNoteusingRedis")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var cacheKey = "NoteList";
                string serializedNoteList;
                var noteList = new List<Note>();
                var redisnoteList = await distributedCache.GetAsync(cacheKey);
                if (redisnoteList != null)
                {
                    serializedNoteList = Encoding.UTF8.GetString(redisnoteList);
                    noteList = JsonConvert.DeserializeObject<List<Note>>(serializedNoteList);
                }
                else
                {
                    noteList = await NoteBL.GetAllNotes();
                    serializedNoteList = JsonConvert.SerializeObject(noteList);
                    redisnoteList = Encoding.UTF8.GetBytes(serializedNoteList);
                }
                return this.Ok(noteList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut("changeColor/{NotesId}/{color}")]
        public IActionResult Color(int NotesId, string color)
        {
            try
            {
                var result = NoteBL.Color(NotesId, color);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Color changed successfully", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User access denied" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("pinnotes/{NotesId}")]
        public async Task<IActionResult> PinNotes(int NotesId)
        {
            try
            {
                var result = NoteBL.PinNote(NotesId);
                await NoteBL.PinNote(NotesId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Pin changed successfully", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User access denied" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("archiveNote/{NotesId}")]
        public async Task<IActionResult> ArchieveNotes(int NotesId)
        {
            try
            {
                var result = NoteBL.ArchieveNote(NotesId);
                await NoteBL.ArchieveNote(NotesId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Archieve changed successfully", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User access denied" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("trash/{NotesId}")]
        public async Task<IActionResult> TrashNotes(int NotesId)
        {
            try
            {
                var result = NoteBL.TrashNote(NotesId);
                await NoteBL.TrashNote(NotesId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Trash changed successfully", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User access denied" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("getbynoteId/{NotesId}")]
        public IEnumerable<Note> GetAllNotesByUserId(int NotesId)
        {
            //int NoteId = (User.Claims.FirstOrDefault(x => x.Type == "NoteId").Value);
            try
            {
                return NoteBL.GetAllNotesByNoteId(NotesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}




