using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common;
using Product1Api.Common.Models.Brands;
using Product1Api.Common.Models.User;
using Product1Api.Common.Repository.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.User
{
    public class UserRep : IUserRep
    {
        private readonly IDb _db;
        public UserRep(IDb db)
        {
            _db = db;
        }
        public async Task SignUp([FromForm]UserDto userDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertUser", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", userDto.UserName);
                    command.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(userDto.Password));
                   
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
