using System;
using LoRaWAN.Business.Abstract;
using LoRaWAN.Data.Dals.Abstract;
using LoRaWAN.Entity.Concrete;
using LoRaWAN.Entity.DTOs.WebUI.User;
using LoRaWAN.ResponseStates.Enums;
using LoRaWAN.ResponseStates.Exceptions;
using LoRaWAN.ResponseStates.Models;
using LoRaWAN.Utilities.Security;

namespace LoRaWAN.Business.Concrete
{
    public class UserService : IUserService
    {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Common
        
        public User Detail(LoginDto loginDto)
        {
            var user = _userRepository.Find(x => x.Email == loginDto.Email);

            if (user == null)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.WrongUser };
            }
            else if (Crypto.Decrypt(user.Password) != loginDto.Password)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.WrongUser };
            }
            else if (user.IsDelete)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.DeletedUser };
            }
            else if (!user.IsActive)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.InActiveUser };
            }
            else
            {
                return user;
                //Log kayıtların geleceği yer
            }
        }

        #endregion


        #region Web

        #region ManagementUI

        #endregion


        #region WebUI
        public ResponseState Create(RegisterDto registerDto)
        {
            //throw new StateException { StateCode = StateCode.UserFound }; 
            if(registerDto.Password != registerDto.ConfirmPassword)
            {
                throw new StateException { StateCode = StateCode.UnexpectedError }; //TODO
                //throw olursa create direk cikar
            }

            if(_userRepository.Any(x => x.Email == registerDto.Email))
            {
                throw new StateException { StateCode = StateCode.UserFoundSame }; //TODO
            }

            User user = new User()
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Password = registerDto.Password,

                Phone = "324",
                RefreshToken = "23",
                RefreshTokenExpiry = DateTime.Now,
                IsMailConfirm = false,
                IsGSMConfirm = false,
                IsBlocked = false,
                IsActive = true,
                IsDelete = false


            };

            User createdUser = _userRepository.Add(user);

            if(createdUser == null)
            {
                throw new StateException { StateCode = StateCode.UserNotCreate };
            }

            return new ResponseState(StateCode.UserCreate);

        }
        #endregion

        #endregion


        #region ApiMobile

        #endregion
    }
}
