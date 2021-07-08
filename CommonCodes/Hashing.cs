using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCodes
{
    public static class Hashing
    {
        public static string Hash(string inputString)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
