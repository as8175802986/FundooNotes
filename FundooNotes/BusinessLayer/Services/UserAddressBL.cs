using BusinessLayer.Interface;
using CommonLayer.UserAddress;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{


    public class UserAddressBL : IUserAddressBL
    {
        IUserAddresRL userAddressRL;

        public UserAddressBL(IUserAddresRL userAddressRL)
        {
            this.userAddressRL = userAddressRL;
        }
        public async Task AddUserAddress(AddressPostModel addressPostModel, int Userid)
        {
            try
            {
                await userAddressRL.AddUserAddress(addressPostModel, Userid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //public async Task<List<AddressModel>> GetUserAddresses(int Userid)
        //{
        //    try
        //    {
        //        return await userAddressRL.GetUserAddresses(Userid);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

        //public async Task UpdateUserAddress(AddressModel addressModel, int Userid, int AddressId)
        //{
        //    try
        //    {
        //        await userAddressRL.UpdateUserAddress(addressModel, Userid, AddressId);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        public async Task UpdateAddress(int Userid, AddressPostModel addressPostModel)
        {
            try
            {
                await userAddressRL.UpdateAddress(Userid, addressPostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<AddressModel>> GetAllAddress(int Userid)
        {
            try
            {
                return await userAddressRL.GetAllAddress(Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAddress(int AddressId)
        {
            try
            {
                await userAddressRL.DeleteAddress(AddressId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
        
    

