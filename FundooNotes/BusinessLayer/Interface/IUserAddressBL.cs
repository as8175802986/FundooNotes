using CommonLayer.UserAddress;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserAddressBL
    {
        Task AddUserAddress(AddressPostModel addressPostModel, int Userid);

        //Task<List<AddressModel>> GetUserAddresses(int Userid);

        //Task UpdateUserAddress(AddressModel addressModel, int Userid, int AddressId);
        public Task UpdateAddress(int Userid, AddressPostModel addressPostModel);
        Task<List<AddressModel>> GetAllAddress(int userid);

        Task DeleteAddress(int AddressId);
    }
}
