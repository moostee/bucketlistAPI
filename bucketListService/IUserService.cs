using bucketListAPIModels;

namespace bucketListService
{
    public interface IUserService
    {
        Response AuthenticateUser(LoginModel loginModel);
        Response SignUpUser(User signup);
    }
}
