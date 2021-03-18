using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AReport.Support.Common
{
    public class Hash
    {
        public static string HashMD5(string data)
        {
            MD5 hmd5 = MD5.Create();

            byte[] bdata = Encoding.ASCII.GetBytes(data);
            byte[] hdata = hmd5.ComputeHash(bdata);
            return Convert.ToBase64String(hdata);
        }

        public static string HashSHA256(string data)
        {
            SHA256 hmd5 = SHA256.Create();

            byte[] bdata = Encoding.ASCII.GetBytes(data);
            byte[] hdata = hmd5.ComputeHash(bdata);
            return Convert.ToBase64String(hdata);
        }
    }
}
