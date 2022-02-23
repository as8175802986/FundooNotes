using CommonLayer.Collab;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICollabBL
    {
        Task<List<Collabarator>> AddCollabrator(int Userid, int NotesId, CollabratorPostModel postModel);
        Task<List<Collabarator>> GetAllCollabs(int Userid);
        Task RemoveCollab(int CollabId, int Userid);
    }
}
