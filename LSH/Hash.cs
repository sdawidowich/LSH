using System.Security.Cryptography;

namespace LSH
{
    public static class Hash
    {
        public static byte[] md5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

                return md5.ComputeHash(inputBytes); ;
            }
        }
    }
}
