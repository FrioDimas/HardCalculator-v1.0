namespace Training
{
    public class FileCalculator
    {
        public List<string> Parse(string filePath)
        {
            int lineNumber = 1;

            var liness = new List<string>();

            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        liness.Add(line);

                        lineNumber++;
                    }
                }
                else
                {
                    Console.WriteLine("The file does not exist.");
                }
            }
            catch (IOException message)
            {
                Console.WriteLine($"Error while reading the file: {message}");
            }

            return liness;
        }
    }
}
