using bucketListAPIModels;
using bucketListDAL;
using System;

namespace bucketListService
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly JWT _jwt;
        public UserService(IUserRepository userRepository, JWT jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }
        public Response AuthenticateUser(LoginModel loginModel)
        {
            Response response = new Response();
            response.ResponseCode = "02";
            response.ResponseMessage = "Invalid Username or Password";
            User user = new User();
            try
            {
                var result = _userRepository.IsAuthenticated(loginModel);

                if (result != null)
                {
                    if (result.Id > 0)
                    {
                        response.ResponseCode = "00";
                        response.ResponseMessage = "Successful";
                        user = _jwt.GenerateJwtToken(result);
                        response.Data = user;
                    }
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = "99";
                response.ResponseMessage = "An error occured while processing your request";
            }

            return response;
        }

        public Response SignUpUser(User signup)
        {
            Response response = new Response();
            response.ResponseCode = "02";
            response.ResponseMessage = "Failed";
            try
            {
                var result = _userRepository.SignUpUser(signup);
                if (result > 0)
                {
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Successful";
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = "99";
                response.ResponseMessage = "An error occured while proceesing your request";
            }

            return response;
        }
    }
}
