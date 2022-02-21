using CommonLayer.Label;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryLayer.Entities;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        FundooDbContext dbContext;
        
        public LabelRL(FundooDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateLabel(LabelModel labelModel, int NotesId, int Userid)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(e => e.Userid == Userid);
                var note = dbContext.notes.FirstOrDefault(u => u.NotesId == NotesId);

                Label labels = new Label();
                labels.Userid = Userid;
                labels.NotesId = NotesId;
                labels.LabelId = new Label().LabelId;
                labels.LabelName = labelModel.LabelName;
                dbContext.Label.Add(labels);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateLabel(int LabelId, LabelModel labelModel)
        {
            try
            {
                Label label = dbContext.Label.Where(e => e.LabelId == LabelId).FirstOrDefault();
                label.LabelName = labelModel.LabelName;
                dbContext.Label.Update(label);
                var result = dbContext.SaveChangesAsync();
                if (result != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DeleteLabel(int LabelId)
        {
            try
            {
                Label label = dbContext.Label.Where(e => e.LabelId == LabelId).FirstOrDefault();
                if (label != null)
                {
                    dbContext.Label.Remove(label);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Label>> GetAllLabels(int Userid)
        {
            Label label = new Label();
            try
            {
                return await dbContext.Label.Where(u => u.Userid == Userid)
                    .Include(u => u.Notes)
                    .Include(u => u.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        async Task<List<Label>> ILabelRL.GetLabelsByNoteID(int Userid, int NotesId)
        {
            try
            {
                return await dbContext.Label.Where(e => e.NotesId == NotesId && e.Userid == Userid)
                    .Include(u => u.Notes)
                    .Include(u => u.User)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }

}

    


