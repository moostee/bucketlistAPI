using bucketListAPIModels;
using bucketListAPIModels.Helpers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace bucketListDAL
{
    public class UserRepository : IUserRepository
    {
        private readonly Password _password;
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration configuration, Password password)
        {
            _config = configuration;
            _password = password;
        }
        public User IsAuthenticated(LoginModel loginModel)
        {

            User user = new User();
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var pas = _password.EncryptAesManaged(loginModel.Password);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@EmailAddress", loginModel.EmailAddress);
                //parameter.Add("@Password", _password.EncryptAesManaged(loginModel.Password));

                var response = con.QueryFirstOrDefault<UserPasswordInBytes>("ValidateUser", parameter, commandType: CommandType.StoredProcedure);

                if (response != null)
                {
                    var decrpytedPassword = _password.DecryptAesManaged(response.PasswordInBytes);
                    if (decrpytedPassword == loginModel.Password)
                    {
                        user.Id = response.Id;
                        user.EmailAddress = response.EmailAddress;
                        user.FirstName = response.FirstName;
                        user.LastName = response.LastName;
                    }
                }

            }
            return user;
        }

        public int SignUpUser(User signUp)
        {
            int response = 0;
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FirstName", signUp.FirstName);
                parameter.Add("@LastName", signUp.LastName);
                parameter.Add("@EmailAddress", signUp.EmailAddress);
                parameter.Add("@Password", _password.EncryptAesManaged(signUp.Password));

                response = con.QueryFirst<int>("CreateUser", parameter, commandType: CommandType.StoredProcedure);

            }

            return response;
        }
    }
}
