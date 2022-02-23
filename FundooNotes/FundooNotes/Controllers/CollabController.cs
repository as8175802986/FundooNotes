using BusinessLayer.Interface;
using CommonLayer.Collab;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CollabController : Controller
    {
        ICollabBL CollabBL;
        FundooDbContext DbContext;
        public CollabController(ICollabBL collabaratorBL, FundooDbContext DbContext)
        {
            this.CollabBL = collabaratorBL;
            this.DbContext = DbContext;
        }
        [Authorize]
        [HttpPost("addCollabartor")]
        public async Task<IActionResult> AddCollabrator(int NotesId, CollabratorPostModel postModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int Userid = Int32.Parse(userid.Value);


                await CollabBL.AddCollabrator(Userid, NotesId, postModel);

                return this.Ok(new { success = true, message = "Collabartion added successfully", response = NotesId, postModel });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet("getAllCollabs")]
        public async Task<IActionResult> GetAllCollabs()
        {

            try
            {
                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);

                List<Collabarator> CollabrationList = new List<Collabarator>();
                CollabrationList = await CollabBL.GetAllCollabs(Userid);
                if (CollabrationList != null)
                {
                    return this.Ok(new { Success = true, message = $"GetAll Collab of userId={Userid} ", data = CollabrationList });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = $"GetAll Collab unsuccessful ",  });
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("deleteCollabs/{CollabId}")]
        public async Task<IActionResult> RemoveCollabs(int CollabId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                
                int Userid = Int32.Parse(userid.Value);

                await CollabBL.RemoveCollab(CollabId, Userid);

                return this.Ok(new { success = true, message = "Collabartion deleted successfully", response = CollabId });

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
