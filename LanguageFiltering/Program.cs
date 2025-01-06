namespace LanguageFiltering
{
    internal class Program
    {
        static string[] bannedWords = new string[] {"Hello", "Goodbye"};
        static void Main(string[] args)
        {
            Console.WriteLine(Filter("Hello ejie"));
        }
        static string Filter(string input)
        {
            string[] bannedWords = new string[] { "Hello", "Goodbye" };
            string filteredText = "";
           
            string[] textSplit = input.Split(' ');
            
            
            for (int i = 0; i < textSplit.Length; i++)
            {
                //Console.WriteLine(textSplit[i]+ i);
                
                for (int j = 0; j < bannedWords.Length; j++)
                {
                    //Console.WriteLine(j + " JLoop");
                    if (textSplit[i].ToUpper() == bannedWords[j].ToUpper())
                    {
                        //Console.WriteLine("ComparisonTrue");
                        textSplit[i] = "*****";
                        
                    }                         
                }
            }
            try
            {
                filteredText = filteredText.Insert(filteredText.Length - 1, ".");
            }
            catch
            {
                Console.WriteLine("No Text Inputted");
            }
            
            return filteredText;
        }
    }
}
