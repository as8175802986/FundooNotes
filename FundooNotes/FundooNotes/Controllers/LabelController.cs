using BusinessLayer.Interface;
using CommonLayer.Label;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LabelController : ControllerBase
    {
        ILabelRL labelBL;
        public LabelController(ILabelRL labelBL)
        {
            this.labelBL = labelBL;
        }

        [Authorize]
        [HttpPost("createLabel/{NotesId}")]
        public async Task<IActionResult> CreateLabel(LabelModel labelModel, int NotesId)
        {
            try
            {
                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                await labelBL.CreateLabel(labelModel, Userid, NotesId);
                return this.Ok(new { success = true, message = "Label added successfully", response = NotesId });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpPut("updateLabel/{labelId}")]

        public IActionResult UpdateNotes(int labelId, LabelModel labelModel)
        {
            try
            {
                if (labelBL.UpdateLabel(labelId, labelModel))
                {
                    return this.Ok(new { Success = true, message = "Labels updated successfully", response = labelId, labelModel });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note with given ID not found" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("deletelabel/{labelId}")]
        public IActionResult DeleteLabel(int labelId)
        {
            try
            {
                if (labelBL.DeleteLabel(labelId))
                {
                    return this.Ok(new { Success = true, message = "Labels deleted successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Labels with UserID not found" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("GetAllLabels")]
        public async Task<IActionResult> GetAllLabels()
        {
            try
            {
                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);
                var LabelList = new List<Label>();
                var NoteList = new List<Note>();
                LabelList = await labelBL.GetAllLabels(Userid);

                return this.Ok(new { Success = true, message = $"GetAll Labels of userId={Userid} ", data = LabelList });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("GetLabelsByNoteID/{NotesId}")]
        public async Task<IActionResult> GetLabelsByNoteID(int NotesId)
        {
            try
            {
                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var LabelList = new List<Label>();
                var NoteList = new List<Note>();
                LabelList = await labelBL.GetLabelsByNoteID(Userid, NotesId);

                return this.Ok(new { Success = true, message = $"GetAll Labels of NoteId={NotesId} ", data = LabelList });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}




