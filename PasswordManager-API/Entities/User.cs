namespace PasswordManager_API.Entities
{
    public class User : ParentEntity
    {
        public string UserName {get; set;}  //Hashed
        public string Password {get; set; } //Hashed
        public string Email {get; set; }    //Not Hashed
        public string? OTPCode {get; set;}
        public DateTime? OTPExpiry {get; set;}
        public int Roleid {get; set; }
        public bool IsVerfied {get; set; } = false;
        public bool? IsLoggedIn { get; set; }
        public DateTime? LastLoginTime { get; set; }

    }
}
