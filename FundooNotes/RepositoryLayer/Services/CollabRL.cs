
using CommonLayer.Collab;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CollabRL : ICollabRL
    {
        FundooDbContext dbContext;

        public CollabRL(FundooDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<List<Collabarator>> AddCollabrator(int Userid, int NotesId, CollabratorPostModel postModel)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(e => e.Userid == Userid);
                var note = dbContext.notes.FirstOrDefault(u => u.NotesId == NotesId);


                Collabarator collabarator = new Collabarator();
                collabarator.Userid = Userid;
                collabarator.NotesId = NotesId;
                collabarator.CollabId = new Collabarator().CollabId;
                collabarator.CollabEmail = postModel.CollabEmail;
                collabarator.Users = user;
                collabarator.notes = note;
                dbContext.Collabarators.Add(collabarator);
                await dbContext.SaveChangesAsync();
                return await dbContext.Collabarators.Where(u => u.Userid == Userid)
                    .Include(u => u.Users)
                    .Include(u => u.notes)
                     .ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Collabarator>> GetAllCollabs(int Userid)
        {
            try
            {
 
                return await dbContext.Collabarators.Where(u => u.Userid == Userid )
                    .Include(u => u.notes)
                    .Include(u => u.Users)

                    .ToListAsync();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveCollab(int CollabId, int Userid)
        {
            try
            {
                Collabarator collabarator = await dbContext.Collabarators.Where(u => u.CollabId == CollabId).FirstOrDefaultAsync();
                if (collabarator != null)
                {
                    // Collabarator collabarator = new Collabarator();
                    this.dbContext.Collabarators.Remove(collabarator);
                    await this.dbContext.SaveChangesAsync();
                    // await dbContext.collabarators.ToListAsync();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}