using BusinessLayer.Interface;
using CommonLayer.Collab;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{

    public class CollabBL : ICollabBL
    {
        ICollabRL collabratorRL;
        public CollabBL(ICollabRL collabratorRL)
        {
            this.collabratorRL = collabratorRL;
        }

        public async Task<List<Collabarator>> AddCollabrator(int Userid, int NotesId, CollabratorPostModel postModel)
        {
            try
            {
                return await collabratorRL.AddCollabrator(Userid, NotesId, postModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Collabarator>> GetAllCollabs(int Userid)
        {
            try
            {
                return await collabratorRL.GetAllCollabs(Userid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveCollab(int CollabId, int Userid)
        {
            try
            {
                await collabratorRL.RemoveCollab(CollabId, Userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
