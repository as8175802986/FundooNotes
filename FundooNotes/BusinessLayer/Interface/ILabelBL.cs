using BusinessLayer.Services;
using CommonLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {

        public Task CreateLabel(LabelModel labelModel, int Userid, int NotesId);
        public bool UpdateLabel(int LabelId, LabelModel labelModel);
        public Task<List<Label>> GetLabelsByNoteID(int Userid, int NotesId);
        public Task<List<LableResponse>> GetAllLabels(int Userid);
        public bool DeleteLabel(int LabelId);


    }
}
