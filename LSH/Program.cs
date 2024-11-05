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
            string poem3 = IO.ReadFile("poem3.txt");
            string poem4 = IO.ReadFile("poem4.txt");

            Console.WriteLine("SimHash Similarity:");
            Console.WriteLine($"Hello World 1 and Hello World 2: {SimHash.ComputeSimilarity(hello_world, hello_world2)}");
            Console.WriteLine($"Hello World 1 and Hello World 3: {SimHash.ComputeSimilarity(hello_world, hello_world3)}");
            Console.WriteLine($"Hello World 2 and Hello World 3: {SimHash.ComputeSimilarity(hello_world2, hello_world3)}");
            Console.WriteLine($"Poem 1 and Poem 2: {SimHash.ComputeSimilarity(poem, poem2)}");
            Console.WriteLine($"Poem 1 and Poem 3: {SimHash.ComputeSimilarity(poem, poem3)}");
            Console.WriteLine($"Poem 1 and Poem 4: {SimHash.ComputeSimilarity(poem, poem4)}");
            Console.WriteLine($"Poem 2 and Poem 3: {SimHash.ComputeSimilarity(poem2, poem3)}");
            Console.WriteLine($"Poem 2 and Poem 4: {SimHash.ComputeSimilarity(poem2, poem4)}");
            Console.WriteLine($"Poem 3 and Poem 4: {SimHash.ComputeSimilarity(poem3, poem4)}");

            Console.WriteLine("\nMinHash Similarity:");
            Console.WriteLine($"Hello World 1 and Hello World 2: {MinHash.ComputeSimilarity(hello_world, hello_world2)}");
            Console.WriteLine($"Hello World 1 and Hello World 3: {MinHash.ComputeSimilarity(hello_world, hello_world3)}");
            Console.WriteLine($"Hello World 2 and Hello World 3: {MinHash.ComputeSimilarity(hello_world2, hello_world3)}");
            Console.WriteLine($"Poem 1 and Poem 2: {MinHash.ComputeSimilarity(poem, poem2)}");
            Console.WriteLine($"Poem 1 and Poem 3: {MinHash.ComputeSimilarity(poem, poem3)}");
            Console.WriteLine($"Poem 1 and Poem 4: {MinHash.ComputeSimilarity(poem, poem4)}");
            Console.WriteLine($"Poem 2 and Poem 3: {MinHash.ComputeSimilarity(poem2, poem3)}");
            Console.WriteLine($"Poem 2 and Poem 4: {MinHash.ComputeSimilarity(poem2, poem4)}");
            Console.WriteLine($"Poem 3 and Poem 4: {MinHash.ComputeSimilarity(poem3, poem4)}");
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
