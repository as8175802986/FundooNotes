using CommonLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface  ILabelRL
    {
        Task CreateLabel(LabelModel labelModel, int NotesId, int Userid);
        public bool UpdateLabel(int LabelId, LabelModel labelModel);
        Task<List<LableResponse>> GetAllLabels(int Userid);
        public Task<List<Label>> GetLabelsByNoteID(int Userid, int NotesId);
        public bool DeleteLabel(int LabelId);



    }
}
