using CommonLayer.UserAddress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        IUserAddresRL UserAddressBL;
        public AddressController(IUserAddresRL UserAddressBL)
        {
            this.UserAddressBL = UserAddressBL;
        }
        [Authorize]
        [HttpPost("AddUserAddress")]
        public async Task<IActionResult> AddUserAddress(AddressPostModel addressPostModel)
        {
            try
            {

                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                await this.UserAddressBL.AddUserAddress(addressPostModel, Userid);

                return this.Ok(new { success = true, message = $"Address Created Sucessfully" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("UpdateAddress/{userId}")]
        public async Task<ActionResult> UpdateAddress(int Userid, AddressPostModel addressPostModel)
        {
            try
            {

                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);

                await this.UserAddressBL.UpdateAddress(Userid, addressPostModel);

                return this.Ok(new { success = true, message = $"Address updated successfully of userId={userid}", data = addressPostModel });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                int Userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);
                var addressList = new List<AddressModel>();
                addressList = await this.UserAddressBL.GetAllAddress(Userid);

                return this.Ok(new { Success = true, message = $"GetAll note successfull ", data = addressList });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("deleteAddress/{AddressId}")]
        public IActionResult DeleteUserAddress(int AddressId)
        {
            try
            {
                this.UserAddressBL.DeleteAddress(AddressId);
                return this.Ok(new { success = true, Message = $"Address is deleted successfully" });

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}


  


