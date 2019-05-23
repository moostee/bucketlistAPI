using bucketListAPIModels;

namespace bucketListDAL
{
    public interface IUserRepository
    {
        User IsAuthenticated(LoginModel loginModel);
        int SignUpUser(User signUp);
    }
}
