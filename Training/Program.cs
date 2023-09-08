using Training;

static class Program
{
    private static async Task Main(string[] args)
    {
        byte modes = 0;
        Console.WriteLine("Chouse calculator modes(Enter a number 1/2) [1 - work with console],[2 - work with files]");
        try
        {
            modes = byte.Parse(Console.ReadLine()!);
        }
        catch
        {
            modes = 0;
        }

        bool restart = true;
        Console.WriteLine();
        while (restart)
        {
            if (modes == 2)
            {
                restart = false;
                string filePath;
                if (args.Length > 0)
                {
                    filePath = args[0];
                }
                else
                {
                    Console.WriteLine("Specify file path as command line argument or enter path in console");
                    filePath = FileInput.GetFilePath();
                }

                FileCalculator fCal = new FileCalculator();
                List<string> lines = fCal.Parse(filePath);

                Console.WriteLine("output");
                List<string> lin = new List<string>();

                for (int i = 0; i < lines.Count; i++)
                {
                    string postfix = InfToPost.infixToPostfix(lines[i]);
                    List<string> result = PostfixCalculator.EvaluatePostfixExpression(postfix);
                    foreach (var token in result)
                    {
                        lin.Add(token);
                    }
                }

                string emptyFilePath = Path.GetFullPath("EmptyFile.txt");

                using (StreamWriter writer = new StreamWriter(emptyFilePath))
                {
                    foreach (var token in lin)
                    {
                        writer.WriteLine(token);
                    }
                }

                using (StreamReader reader = new StreamReader(emptyFilePath))
                {
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine(text);
                }
            }
            else if (modes == 1)
            {
                restart = false;
                Console.WriteLine("Calculator features: Can make a simple math operation like: +, -, /, *. Notice : you can use integer and decimal(But separator is point) You can input expresion in format like a+b-c/d*f  ");
                Console.Write("Enter an arithmetic expression: ");
                Console.WriteLine();
                string input = Console.ReadLine()!;

                try
                {
                    string emptyPath = "C:/Users/dmitr/source/repos/Training/Training/EmptyFile.txt";
                    string postfix = InfToPost.infixToPostfix(input);

                    List<string> result = PostfixCalculator.EvaluatePostfixExpression(postfix);

                    for(int i = 0; i < result.Count; i++)
                    {
                        Console.Write(result[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid numbers, please enter correct number! [1 or 2]");
                try
                {
                    modes = byte.Parse(Console.ReadLine()!);
                    restart = true;
                }
                catch
                {
                    modes = 0;
                }
            }
        }
    }
}
