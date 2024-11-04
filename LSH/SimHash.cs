﻿namespace LSH
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
                    uint bit = BinaryOperations.GetBit(tokenHashes[j], i);
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

        private static List<string> GetTokens(string text)
        {
            return text.Split(" ").ToList();
        }

        private static List<uint> GetTokenHashes(List<string> tokens) 
        {
            List<uint> tokenHashes = new List<uint>();
            foreach (string token in tokens)
            {
                tokenHashes.Add(BinaryOperations.BytesToInt(LSH.Hash.md5(token)));
            }

            return tokenHashes;
        }

        private static Dictionary<string, int> GetTokenScores(List<string> tokens)
        {
            Dictionary<string, int> tokenScores = new Dictionary<string, int>();
            foreach (string token in tokens)
            {
                tokenScores.TryGetValue(token, out int score);
                tokenScores[token] = score + 1;
            }

            return tokenScores;
        }
    }
}
