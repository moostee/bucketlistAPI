namespace bucketListAPIModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class UserPasswordInBytes : User
    {
        public byte[] PasswordInBytes { get; set; }
    }
}
