﻿using CommonLayer.UserAddress;
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
        //Task<List<AddressModel>> GetUserAddresses(int Userid);
        //Task UpdateUserAddress(AddressModel addressModel, int Userid, int AddressId);
        Task DeleteAddress(int AddressId);
        //Task UpdateUserAddress(int Userid, AddressModel addressModel);
        Task<List<AddressModel>> GetAllAddress(int userid);
        Task UpdateAddress(int userid, AddressPostModel addressPostModel);
    }
}
