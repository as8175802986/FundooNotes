using BusinessLayer.Interface;
using CommonLayer.Label;
using Microsoft.Data.SqlClient.DataClassification;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }



        public bool UpdateLabel(int LabelId, LabelModel labelModel)
        {
            try
            {
                if (labelRL.UpdateLabel(LabelId, labelModel))
                    return true;
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
                if (labelRL.DeleteLabel(LabelId))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        async Task<List<RepositoryLayer.Entities.Label>> ILabelBL.GetLabelsByNoteID(int Userid, int NotesId)
        {
            try
            {
                return await labelRL.GetLabelsByNoteID(Userid, NotesId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<List<LableResponse>> ILabelBL.GetAllLabels(int Userid)
        {
            try
            {
                return await labelRL.GetAllLabels(Userid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateLabel(LabelModel labelModel, int Userid, int NotesId)
        {
            try
            {
                await labelRL.CreateLabel(labelModel, Userid, NotesId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}


