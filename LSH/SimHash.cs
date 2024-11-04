namespace LSH
{
    public static class SimHash
    {
        public static uint Hash(string text, int sensitivity = 32)
        {
            if (sensitivity > 32)
            {
                throw new ArgumentException("Sensitivity argument must not be greater than 32");
            }
            else if (sensitivity < 1)
            {
                throw new ArgumentException("Sensitivity argument must not be less than 1");
            }

            List<string> tokens = GetTokens(text);
            List<uint> tokenHashes = GetTokenHashes(tokens);
            Dictionary<string, int> tokenScores = GetTokenScores(tokens);

            uint hash = 0;

            for (int i = 0; i < sensitivity; i++)
            {
                hash = (hash << 1);

                int sum = 0;
                for (int j = 0; j < tokenHashes.Count; j++)
                {
                    uint bit = GetBit(tokenHashes[j], i);
                    int sign = bit == 1 ? 1 : -1;

                    sum += sign * tokenScores[tokens[j]];
                }

                if (sum >= 0)
                {
                    hash++;
                }
            }

            return hash;
        }

        public static List<string> GetTokens(string text)
        {
            return text.Split(" ").ToList();
        }

        public static List<uint> GetTokenHashes(List<string> tokens) 
        {
            List<uint> tokenHashes = new List<uint>();
            foreach (string token in tokens)
            {
                tokenHashes.Add(BytesToInt(LSH.Hash.md5(token)));
            }

            return tokenHashes;
        }

        public static int GetBit(int val, int index)
        {
            return (val >> index) % 2;
        }

        public static uint GetBit(uint val, int index)
        {
            return (val >> index) % 2;
        }

        public static Dictionary<string, int> GetTokenScores(List<string> tokens)
        {
            Dictionary<string, int> tokenScores = new Dictionary<string, int>();
            foreach (string token in tokens)
            {
                tokenScores.TryGetValue(token, out int score);
                tokenScores[token] = score + 1;
            }

            return tokenScores;
        }

        public static uint BytesToInt(byte[] bytes)
        {
            // If the system architecture is little-endian (that is, little end first),
            // reverse the byte array.
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static uint HammingDistance(uint hash1, uint hash2)
        {
            uint xor = hash1 ^ hash2;

            uint setBits = 0;
            while (xor > 0)
            {
                setBits += xor % 2;
                xor = xor >> 1;
            }

            return setBits;
        }
    }
}
