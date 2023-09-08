namespace Training
{
    public static class FileInput
    {
        public static string GetFilePath()
        {
            while (true)
            {
                Console.WriteLine("Enter file path : ");
                string input = Console.ReadLine()!;

                if (input == null)
                {
                    continue;
                }

                if (File.Exists(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid file path, please try enter correct file path! ");
                }
            }
        }

    }
}
