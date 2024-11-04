namespace LSH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hello_world = IO.ReadFile("hello_world.txt");
            string hello_world2 = IO.ReadFile("hello_world2.txt");
            string hello_world3 = IO.ReadFile("hello_world3.txt");
            string poem = IO.ReadFile("poem.txt");
            string poem2 = IO.ReadFile("poem2.txt");

            // Hello World Hashes
            uint hash1 = SimHash.Hash(hello_world, 32);
            Console.WriteLine(Convert.ToString(hash1, 2).PadLeft(32, '0'));
            uint hash2 = SimHash.Hash(hello_world2, 32);
            Console.WriteLine(Convert.ToString(hash2, 2).PadLeft(32, '0'));
            uint hash3 = SimHash.Hash(hello_world3, 32);
            Console.WriteLine(Convert.ToString(hash3, 2).PadLeft(32, '0'));

            // Poems Hashes
            uint hash4 = SimHash.Hash(poem, 32);
            Console.WriteLine(Convert.ToString(hash4, 2).PadLeft(32, '0'));
            uint hash5 = SimHash.Hash(poem2, 32);
            Console.WriteLine(Convert.ToString(hash5, 2).PadLeft(32, '0'));

            Console.WriteLine(SimHash.HammingDistance(hash1, hash2));
            Console.WriteLine(SimHash.HammingDistance(hash1, hash3));
            Console.WriteLine(SimHash.HammingDistance(hash2, hash3));

            Console.WriteLine(SimHash.HammingDistance(hash2, hash4));

            Console.WriteLine(SimHash.HammingDistance(hash4, hash5));
        }
    }

    public static class IO
    {
        public static string ReadFile(string path)
        {
            string text = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return text;
        }
    }
}
