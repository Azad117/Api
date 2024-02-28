
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.User;
using Product1Api.Common.Models.User;
using Product1Api.Common.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.User
{
    public class UserSer : IUserSer
    {
        private readonly IUserRep _userRep;
        public UserSer(IUserRep userRep)
        {
            _userRep = userRep;
        }
        public async Task signup([FromForm]UserDto userDto)
        {
            _userRep.SignUp(userDto);
        }
    }
}
