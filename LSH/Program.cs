namespace LSH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> documentDirectories = new List<string>()
            {
                "data\\business",
                "data\\entertainment",
                "data\\food",
                "data\\graphics",
                "data\\hello_world",
                "data\\historical",
                "data\\medical",
                "data\\poems",
                "data\\politics",
                "data\\space",
                "data\\sport",
                "data\\technologie"
            };

            Dictionary<string, string> documents = new Dictionary<string, string>();

            foreach (string dir in documentDirectories)
            {
                string[] fileEntries = Directory.GetFiles(dir);
                foreach (string fileName in fileEntries)
                {
                    documents.Add(fileName, IO.ReadFile(fileName));
                }
                Console.WriteLine($"Loaded files in directory '{dir}'");
            }

            // SimHash
            //Dictionary<string, uint> documentSimHashes = new Dictionary<string, uint>();
            //Console.WriteLine("SimHashing documents...");
            //foreach (KeyValuePair<string, string> doc in documents)
            //{
            //    documentSimHashes.Add(doc.Key, SimHash.Hash(doc.Value));
            //}

            //Console.WriteLine("Comparing documents' simhashes...");
            //List<KeyValuePair<string, uint>> docSimHashList = documentSimHashes.ToList();
            //for (int i = 0; i < docSimHashList.Count(); i++)
            //{
            //    for (int j = i + 1; j < docSimHashList.Count(); j++)
            //    {
            //        KeyValuePair<string, uint> doc1 = docSimHashList[i];
            //        KeyValuePair<string, uint> doc2 = docSimHashList[j];

            //        double similarity = SimHash.ComputeSimilarity(doc1.Value, doc2.Value);
            //        if (similarity == 0)
            //        {
            //            Console.WriteLine($"'{doc1.Key}' and '{doc2.Key}': {similarity}");
            //        }
            //    }
            //}

            // MinHash
            Dictionary<string, List<uint>> documentMinHashes = new Dictionary<string, List<uint>>();
            Console.WriteLine("MinHashing documents...");
            foreach (KeyValuePair<string, string> doc in documents)
            {
                documentMinHashes.Add(doc.Key, MinHash.Hash(doc.Value));
            }

            Console.WriteLine("Comparing documents' minhashes...");
            List<KeyValuePair<string, List<uint>>> docMinHashList = documentMinHashes.ToList();
            for (int i = 0; i < docMinHashList.Count(); i++)
            {
                for (int j = i + 1; j < docMinHashList.Count(); j++)
                {
                    KeyValuePair<string, List<uint>> doc1 = docMinHashList[i];
                    KeyValuePair<string, List<uint>> doc2 = docMinHashList[j];

                    double similarity = MinHash.ComputeSimilarity(doc1.Value, doc2.Value);
                    if (similarity > 0.5)
                    {
                        Console.WriteLine($"'{doc1.Key}' and '{doc2.Key}': {similarity}");
                    }
                }
            }

            //Console.WriteLine("SimHash Similarity:");
            //Console.WriteLine($"Hello World 1 and Hello World 2: {SimHash.ComputeSimilarity(hello_world, hello_world2)}");
            //Console.WriteLine($"Hello World 1 and Hello World 3: {SimHash.ComputeSimilarity(hello_world, hello_world3)}");
            //Console.WriteLine($"Hello World 2 and Hello World 3: {SimHash.ComputeSimilarity(hello_world2, hello_world3)}");
            //Console.WriteLine($"Poem 1 and Poem 2: {SimHash.ComputeSimilarity(poem, poem2)}");
            //Console.WriteLine($"Poem 1 and Poem 3: {SimHash.ComputeSimilarity(poem, poem3)}");
            //Console.WriteLine($"Poem 1 and Poem 4: {SimHash.ComputeSimilarity(poem, poem4)}");
            //Console.WriteLine($"Poem 2 and Poem 3: {SimHash.ComputeSimilarity(poem2, poem3)}");
            //Console.WriteLine($"Poem 2 and Poem 4: {SimHash.ComputeSimilarity(poem2, poem4)}");
            //Console.WriteLine($"Poem 3 and Poem 4: {SimHash.ComputeSimilarity(poem3, poem4)}");

            //Console.WriteLine("\nMinHash Similarity:");
            //Console.WriteLine($"Hello World 1 and Hello World 2: {MinHash.ComputeSimilarity(hello_world, hello_world2)}");
            //Console.WriteLine($"Hello World 1 and Hello World 3: {MinHash.ComputeSimilarity(hello_world, hello_world3)}");
            //Console.WriteLine($"Hello World 2 and Hello World 3: {MinHash.ComputeSimilarity(hello_world2, hello_world3)}");
            //Console.WriteLine($"Poem 1 and Poem 2: {MinHash.ComputeSimilarity(poem, poem2)}");
            //Console.WriteLine($"Poem 1 and Poem 3: {MinHash.ComputeSimilarity(poem, poem3)}");
            //Console.WriteLine($"Poem 1 and Poem 4: {MinHash.ComputeSimilarity(poem, poem4)}");
            //Console.WriteLine($"Poem 2 and Poem 3: {MinHash.ComputeSimilarity(poem2, poem3)}");
            //Console.WriteLine($"Poem 2 and Poem 4: {MinHash.ComputeSimilarity(poem2, poem4)}");
            //Console.WriteLine($"Poem 3 and Poem 4: {MinHash.ComputeSimilarity(poem3, poem4)}");
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
