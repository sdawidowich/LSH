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

                return md5.ComputeHash(inputBytes);
            }
        }

        public static byte[] murmur3(string input, int seed)
        {
            // Use input string to calculate MD5 hash
            using (Murmur3 murmur3 = Murmur3.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

                int numBytes = ((seed) / 8) + 1;
                if (numBytes > inputBytes.Length)
                {
                    byte[] newBytes = new byte[numBytes];
                    inputBytes.CopyTo(newBytes, 0);
                    inputBytes = newBytes;
                }

                int byteIndex = seed / 8;
                int bitIndex = seed % 8;

                inputBytes[byteIndex] ^= (byte)Math.Pow(2, bitIndex);

                return murmur3.ComputeHash(inputBytes);
            }
        }
    }
}
