using LoRaWAN.Business.Abstract;
using LoRaWAN.Entity.DTOs.WebUI.User;
using LoRaWAN.ResponseStates.Models;

namespace LoRaWAN.Business.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        public LoginService(IUserService userService)
        {
            _userService = userService;
        }
        #region Common

        #endregion


        #region Web

        #region ManagementUI

        #endregion


        #region WebUI
        
        public ResponseState<UserDto> UserLogin(LoginDto loginDto)
        {
            var response = new ResponseState<UserDto>();
            var user = _userService.Detail(loginDto);
            response.Content = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
            };
            return response;
        }
        
        #endregion

        #endregion


        #region ApiMobile

        #endregion
    }
}