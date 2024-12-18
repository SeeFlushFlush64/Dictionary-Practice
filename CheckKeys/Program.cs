using System;
namespace CheckKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string myName = "[]()}{";
            System.Console.WriteLine(IsValid(myName));
        }
        static bool IsValid(string s)
        {
            Dictionary<char, char> myDictionary = new Dictionary<char, char>
            {
                {'{', '}'},
                {'(', ')'},
                {'[', ']'} 
            };
            ICollection<char> myOpenings = myDictionary.Keys;
            ICollection<char> myClosings = myDictionary.Values;
            Stack<char> openings = new Stack<char>();
            
            int currentIndex = 0;
            foreach (char c in s)
            {
                if (currentIndex.Equals(0) && !myClosings.Contains(c))
                {
                    openings.Push(c);
                }
                else if (myOpenings.Contains(c))
                {
                    openings.Push(c);
                }
                else if (!openings.Count.Equals(0) && c.Equals(myDictionary[openings.Peek()]))
                {
                    openings.Pop();
                }
                else if (openings.Count.Equals(0) && myClosings.Contains(c))
                {
                    return false;
                }
                currentIndex++;
            }
            if (!openings.Count.Equals(0))
            {
                System.Console.Write("No matching brackets: ");
                foreach (char o in openings)
                {
                    System.Console.Write($"{o}" );
                } 
            }
            System.Console.WriteLine();
            
            return openings.Count.Equals(0) ? true : false;
        }
    }
}