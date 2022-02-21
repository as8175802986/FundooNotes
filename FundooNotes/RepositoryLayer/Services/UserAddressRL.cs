using CommonLayer.UserAddress;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    
        public class UserAddressRL : IUserAddresRL
        {
            FundooDbContext dbContext;


            public UserAddressRL(FundooDbContext dbContext)
            {
                this.dbContext = dbContext;

            }
            public async Task AddUserAddress(AddressPostModel addressPostModel, int Userid)
            {
                try
                {
                    var User = dbContext.Users.FirstOrDefault(e => e.Userid == Userid);
                    AddressModel address = new AddressModel();
                    address.AddressId = new AddressModel().AddressId;
                    address.Userid = Userid;
                    address.Type = addressPostModel.Type;
                    address.Address = addressPostModel.Address;
                    address.City = addressPostModel.City;
                    address.State = addressPostModel.State;
                    dbContext.AddressModels.Add(address);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public async Task<List<AddressModel>> GetAllAddress(int Userid)
            {
                return await dbContext.AddressModels.Where(u => u.Userid == Userid)
                    .Include(u => u.User)
                    .ToListAsync();
            }

            
            public async Task DeleteAddress(int AddressId)
            {
                try
                {
                    AddressModel address = dbContext.AddressModels.Where(e => e.AddressId == AddressId).FirstOrDefault();


                    dbContext.AddressModels.Remove(address);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        public async Task UpdateAddress(int Userid, AddressPostModel addressPostModel)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(x => x.Userid == Userid);
                AddressModel address = new AddressModel();
                address.Userid = Userid;
                address.AddressId = new AddressModel().AddressId;
                address.Address = address.Address;
                address.State = address.State;
                address.City = address.City;
                dbContext.AddressModels.Add(address);
                await dbContext.SaveChangesAsync();
            }


            catch (Exception e)
            {
                throw e;
            }
        }


    }
    
}

