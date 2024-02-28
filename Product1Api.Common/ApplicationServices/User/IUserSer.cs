using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.User
{
    public interface IUserSer
    {
        Task signup([FromForm]UserDto userDto);
    }
}
