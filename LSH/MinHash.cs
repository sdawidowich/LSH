namespace LSH
{
    public static class MinHash
    {
        private static Func<string, int, byte[]> _hashFunc = LSH.Hash.murmur3;
        private static int _l = 100;

        public static List<uint> Hash(string text)
        {
            List<string> tokens = GetTokens(text);

            List<uint> hash = new List<uint>(_l);
            for (int i = 0; i < _l; i++)
            {
                hash.Add(int.MaxValue);
            }

            foreach (string token in tokens)
            {
                for (int i = 0; i < _l; i++)
                {
                    byte[] hashBytes = _hashFunc(token, i);
                    uint hashVal = BinaryOperations.BytesToInt(hashBytes);

                    if (hashVal < hash[i])
                    {
                        hash[i] = hashVal;
                    }
                }
            }

            return hash;
        }

        public static double ComputeSimilarity(string text1, string text2)
        {
            List<uint> text1Hashes = Hash(text1);
            List<uint> text2Hashes = Hash(text2);

            double similarity = 0;
            for (int i = 0; i < _l; i++)
            {
                similarity +=  (text1Hashes[i] == text2Hashes[i]) ? 1 : 0;
            }
            similarity /= _l;

            return similarity;
        }

        private static List<string> GetTokens(string text)
        {
            return text.Split(" ").ToList();
        }
    }
}
