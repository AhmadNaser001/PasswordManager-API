using Microsoft.EntityFrameworkCore;
using PasswordManager_API.Context;
using PasswordManager_API.DTOs.Authantication;
using PasswordManager_API.Entities;
using PasswordManager_API.Interfaces;

namespace PasswordManager_API.Services
{
    public class AuthanticationAppSevice : IUserAuthanticationInterface
    {
        private readonly PasswordManagerDbContext _context;
        public AuthanticationAppSevice(PasswordManagerDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            var user = await _context.Users.Where(u => u.Email == input.Email && u.OTPCode == input.OTP &&
             u.IsLoggedIn == false && u.OTPExpiry > DateTime.Now).SingleOrDefaultAsync();

            if(user == null)
            {
                return false;
            }
            if(input.Password != input.ConfirmPassword)
            {
                return false;
            }
            user.Password = input.ConfirmPassword;
            user.OTPCode = null;
            user.OTPExpiry = null;

            _context.Update(user);
            await  _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SendOTP(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email && u.IsLoggedIn == false).SingleOrDefaultAsync();

            if (user == null)
            {
                return false;
            };

            Random otp = new Random();
            user.OTPCode = otp.Next(11111, 99999).ToString();
            user.OTPExpiry = DateTime.Now.AddMinutes(3);

            //Send OTP VIA Email
            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<string> SignIn(SignInInputDTO input)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == input.Username && u.Password == input.Password &&
            u.IsLoggedIn == false);
            
            if (user == null)
            {
                return "User Not found.";
            }

            Random otp = new Random();
            user.OTPCode = otp.Next(11111, 99999).ToString();
            user.OTPExpiry = DateTime.Now.AddMinutes(5);
            //Send OTP VIA Email
            _context.Update(user);
            await _context.SaveChangesAsync();


            return "Check Your Email OTP Has Been Sent!";
        }

        public async Task<bool> SignOut(int useriD)
        {
            var user = await _context.Users.Where(u => u.Id ==  useriD && u.IsLoggedIn == true).SingleOrDefaultAsync();
            if (user == null)
            {
                return false;
            }

            user.LastLoginTime = DateTime.Now;
            user.IsLoggedIn = false;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string> SignUp(SignUpInputDTO input)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u =>u.Email == input.Email);

            if (existingUser != null)
            {
                return "Email is already in use.";
            }
            var user = new User
            {
                Email = input.Email,
                Password = input.Password,
                UserName = input.Username,
                CreatedBy = "System",
                Roleid = 1,
                CreationDate = DateTime.Now,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "Verifuing Your Email Using OTP";
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            var user = await _context.Users.Where(u => u.Email == input.Email && u.OTPCode == input.OTPCode
            && u.IsLoggedIn == false && u.OTPExpiry >DateTime.Now).SingleOrDefaultAsync();

            if (user == null)
            {
                return "User Not Found";
            }
            if (input.IsSignup)
            {
                user.IsVerfied = true;
                user.OTPExpiry = null;
                user.OTPCode = null;
                _context.Update(user);
                await _context.SaveChangesAsync();
                return "Your Account Is Verifyd";
            }
            else
            {
                user.LastLoginTime = DateTime.Now;
                user.IsLoggedIn = true;
                user.OTPExpiry = null;
                user.OTPCode = null;

                _context.Update(user);
                await _context.SaveChangesAsync();

                return "Token";
            }
        }
    }
}
