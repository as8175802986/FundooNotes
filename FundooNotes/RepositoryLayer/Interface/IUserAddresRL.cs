using CommonLayer.UserAddress;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserAddresRL
    {
        Task AddUserAddress(AddressPostModel addressPostModel, int Userid);
        
        Task DeleteAddress(int AddressId);
        Task<List<AddressModel>> GetAllAddress(int userid);
        Task UpdateAddress(int userid, AddressPostModel addressPostModel);
    }
}
