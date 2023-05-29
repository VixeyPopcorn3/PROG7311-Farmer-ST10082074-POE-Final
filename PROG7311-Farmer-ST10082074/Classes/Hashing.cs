using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;

namespace PROG7311_Farmer_ST10082074.Classes
{
    public class Hashing
    {
        //these methods are used in the log in page to decript the password to check it and used in the AddFarmer page to encrypyt the password

        //Refrence for Generating a Salt
        //Author : Jamal
        //Year: 2015
        //Title: Jamal
        //Site Title: Code Review
        //Website: StackExchange, Code Review
        //URL: https://codereview.stackexchange.com/questions/93614/salt-generation-in-c
        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        //Refrence for Hashing a password with SHA256 
        //Author : Dave Hillier
        //Year: 2013
        //Title: How do I create a SHA256 hash with salt?
        //Site Title: Stack Overflow
        //Website: Stack Overflow
        //URL: https://stackoverflow.com/questions/14112440/how-do-i-create-a-sha256-hash-with-salt
        public string HashPasswordSHA256(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] combinedBytes = passwordBytes.Concat(saltBytes).ToArray();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(combinedBytes);
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword;
            }
        }
        public string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] combinedBytes = saltBytes.Concat(passwordBytes).ToArray();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}