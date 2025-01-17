﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace RMaD.Classes
{
    public static class PasswordEncryption
    {        
        private static string GetRandomSalt()
          {
             return BCrypt.Net.BCrypt.GenerateSalt(12);
          }

        public static string HashPassword(string password)
         {
             return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
         }

        public static bool ValidatePassword(string password, string correctHash)
         {
             return BCrypt.Net.BCrypt.Verify(password, correctHash);
         }
        
    }
}
