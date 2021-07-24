using HelloWorld.Fundamentals;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace HelloWorld
{

    public partial class Program
    {

        private static void MaxOfTwo()
        {

            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();



            int firstResult = helper.PromptForValue("Please enter a number");

            int secondResult = helper.PromptForValue("Please enter a second number");

            Console.WriteLine("Maximum of the two numbers {0} and {1} is {2}",
                firstResult,
                secondResult,
                Math.Max(firstResult, secondResult));

            Console.ReadLine();
        }

        private static void TestValidity()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();

            int result = helper.PromptForValue("Please enter a number between 1 and 10");

            Console.WriteLine(Validity.IsValid(result) ? "Valid" : "Invalid");

            Console.ReadLine();

        }

        private static void ImageWidthAndHeight()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();

            int width = helper.PromptForValue("Please enter image width (whole numbers only)");

            int height = helper.PromptForValue("Please enter image height (whole numbers only)");

            Console.WriteLine("Image is in {0} orientation", Orientation.IsPortrait(height, width) ? "Portrait" : "Landscape");

            Console.ReadLine();
        }

        private static void CheckSpeed()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();

            int carSpeed = helper.PromptForValue("Please enter car speed (whole numbers only)");

            int speedLimit = helper.PromptForValue("Please enter speed limit (whole numbers only)");

            int points = Demerits.CalculateDemerits(carSpeed, speedLimit);



            switch (points)
            {
                case 0:
                    Console.WriteLine("OK");
                    break;

                case > 12:
                    Console.WriteLine("License Suspended");
                    break;

                default:
                    Console.WriteLine($"You have incurred {points} points");
                    break;
            }

            Console.ReadLine();
        }

        private static void GetRandoms()
        {

            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);


            var random = new Random();

            const int randomLength = 10;
            const string separator = @"-------------------";

            byte[] bytes = new byte[randomLength];
            random.NextBytes(bytes);


            foreach (var b in bytes)
                Console.WriteLine(b);


            Console.WriteLine(separator);

            for (var i = 0; i < randomLength; i++)
                Console.WriteLine(random.Next());


            Console.WriteLine(separator);
            /*
             * This is cool. random.Next has 
             * a couple of overloads so you can set from and to range
             * We want to generate a random string of characters.
             * We COULD go from 97 to 122 (a to z) but we can just add 
             * 'a' (97) to 0 to 25 (0-based array, 26 letters in alphabet)
             * Strings are immutable, but it's a class so you can create one with new()
             */
            var buffer = new char[randomLength];
            for (var i = 0; i < randomLength; i++)
                buffer[i] = (char)('a' + random.Next(0, 25));

            var password = new string(buffer);
            Console.WriteLine(password);

            Console.ReadLine();
        }

        private static void ShowDivisibleByThree()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            int from = 1;
            int to = 100;
            int divisor = 3;

            Console.WriteLine($"There are {0} numbers divisible by {1} between {2} and {3}",
                NumberHelper.CountDivisible(from, to, divisor),
                divisor,
                from,
                to);

            Console.ReadLine();
        }

        private static void AddNumbers()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var response = string.Empty;

            int summedNumbers = 0;

            while (!(response == "OK"))
            {
                Console.WriteLine("Enter a number (or 'OK' to sum them):");
                response = Console.ReadLine();


                if (int.TryParse(response, out int result))
                {
                    summedNumbers += result;
                }
            }
            Console.WriteLine("Sum of numbers entered = {0}", summedNumbers);
            Console.ReadLine();

        }

        private static void ShowFactorial()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();

            int target = helper.PromptForValue("Please enter a number to get the factorial (whole numbers only)");

            Console.WriteLine("Factorial of {0} is {1} ", target, NumberHelper.GetFactorial(target));

            Console.ReadLine();

        }

        private static void GuessRandomNumber()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();

            var random = new Random();
            int answer = random.Next(1, 10);
            int guess = 0;

            for (int i = 0; i <= 4; i++)
            {
                guess = helper.PromptForValue("What number am I thinking of?");

                if (guess == answer)
                {
                    Console.WriteLine("You won!");
                    break;
                }
                else
                {
                    Console.WriteLine("Nope. Guess again");
                }
            }


            Console.ReadLine();

        }

        private static void GetMaxOfNumbers()
        {
            Console.WriteLine("Enter a comma-separated list of whole numbers (no spaces)");

            string response = Console.ReadLine();

            int maxNumber = NumberHelper.GetMaxFromList(response, ',');

            Console.WriteLine("Max value of those items entered ({0}) is {1}",
                response, maxNumber);

            Console.ReadLine();
        }

        private static void ListLarks()
        {
            var numbers = new List<int>() { 1, 2, 3, 4 };

            numbers.Add(1);

            numbers.AddRange(new int[3] { 5, 6, 7 });

            var moreNumbers = new int[3] { 9, 8, 3 };
            numbers.AddRange(moreNumbers);

            Console.WriteLine("Effect of AddRange()");
            foreach (var number in numbers)
            {
                Console.Write(number);
            }
            Console.WriteLine("\n");

            numbers.Sort();
            Console.WriteLine("Effect of Sort()");
            foreach (var number in numbers)
            {
                Console.Write(number);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Effect of Remove()");

            //note: cannot modify a list within a foreach loop as the members change
            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 3)
                    numbers.Remove(numbers[i]);
            }
            foreach (var number in numbers)
            {
                Console.Write(number);
            }
            Console.WriteLine("\n");

        }

        private static void BuildFacebookList()
        {
            string response = " ";
            var names = new List<string>();

            Console.Clear();

            while (!(response == string.Empty))
            {
                Console.WriteLine("Add a(nother) name, (or just hit Enter to stop)");
                response = Console.ReadLine();
                if (response != string.Empty && !(names.Contains(response)))
                {
                    names.Add(response);
                }
            }

            switch (names.Count)
            {
                case 0:
                    Console.WriteLine("Everyone hates you: 0 likes");
                    break;

                case 1:
                    Console.WriteLine("One person ({0}) liked your post", names[0]);
                    break;

                case 2:
                    Console.WriteLine("{0} and {1} liked your post", names[0], names[1]);
                    break;

                case > 2:
                    Console.WriteLine("{0} and {1} and {2} others liked your post", names[0], names[1], names.Count - 2);
                    break;
            }
            Console.ReadLine();

        }

        private static void DisplayReversedName()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("Enter your name:");

            string name = Console.ReadLine();

            Console.WriteLine("Your name, reversed, is: {0}", StringHelper.ReverseString(name));
            Console.ReadLine();

        }

        private static void ShowReversedList()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var helper = new ConsoleHelper();
            List<int> members = new List<int>();
            int member = 0;

            for (int i = 0; i < 5; i++)
            {
                member = helper.PromptForValue(members.Count + " members so far: Please add a NEW number");

                if (!(members.Contains(member)))
                {
                    members.Add(member);
                }
                else
                {
                    Console.WriteLine("{0} already added - try again", member);
                    Console.WriteLine();
                    i--;
                }

            }
            members.Sort();

            Console.WriteLine(string.Join(",", members.ToArray()));


            Console.WriteLine();


        }

        private static void ShowUniqueEntries()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<int> members = new List<int>();
            int member = 0;
            string response = "";
            bool success;

            while (response != "Quit")
            {
                Console.WriteLine("{0} members (including dupes) so far: Please add a NEW number", members.Count);
                response = Console.ReadLine();

                success = int.TryParse(response, out member);

                //if (success && !(members.Contains(member))) //we allow duplicates in list...
                members.Add(member);
            }

            ICollection<int> uniqueMembers = new HashSet<int>(members);

            //Console.WriteLine(string.Join(",", members.ToArray()));
            Console.WriteLine(string.Join(",", uniqueMembers)); //...but not in output

            Console.WriteLine();
        }

        private static void DisplayBottom3FromList()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            string response = "";

            while (response != "Quit" && response.Count(ch => (ch == ',')) < 5)
            {
                Console.WriteLine("Please supply a comma-separated list of 5 or more numbers");
                response = Console.ReadLine();
            }

            var members = response.Split(',');

            Array.Sort(members);
            for (int i = 0; i < 3; i++)
                Console.WriteLine(members[i]);

            Console.WriteLine();
        }

        private static void ShowConsecutive()
        {
            ConsoleHelper.ClearAndAnnounce(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("Enter numbers separated by dashes");
            var entries = Console.ReadLine();
            Console.WriteLine($"Is '{entries}' a list of consecutive integers: {StringHelper.IsConsecutive(entries, '-')}");
            Console.ReadLine();
        }

        private static void ShowIfDuplicates()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("Enter numbers separated by dashes");
            string entries = Console.ReadLine();

            if (String.IsNullOrEmpty(entries))
                return;

            if (StringHelper.CheckForDuplicates(entries, '-'))
                Console.WriteLine("Duplicate entries detected");
            else
                Console.WriteLine("No duplicates detected");

            Console.ReadLine();
        }

        private static void ShowTimeValidity()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("Enter a valid time in'HH:mm' format:");
            var entry = Console.ReadLine();

            string result = DateTimeHelper.IsValidTime(entry) ? "OK" : "Invalid Time";

            Console.WriteLine("{0}", result);
            Console.ReadLine();
        }

        private static void ShowInTitleCase()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("Enter a few words separated by space, to be 'Title Cased':");
            var entry = Console.ReadLine();

            Console.WriteLine(StringHelper.ToTitleCase(entry).Replace(" ", ""));
            Console.ReadLine();
        }

        private static void ShowCountofVowels()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("Enter a word: I'll count the voewls:");
            var entry = Console.ReadLine();

            Console.WriteLine("Your word '{0}' has {1} vowels", entry, StringHelper.CountVowels(entry));
            Console.ReadLine();

        }

        private static void DisplayWordCountAndlongestWord()
        {

            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                var path = @"C:\temp\MyOldFile.txt";
                //var newPath = @"C:\temp\MyNewFile.txt";


                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("hello world");
                    sw.WriteLine("what a wonderful world this would be");
                    sw.WriteLine("Now, I don't claim to be an 'A' student, but I'm trying to be");
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string text = sr.ReadToEnd();
                    Console.WriteLine("Wordcount: {0}, Longest word = '{1}'",
                        StringHelper.CountWords(text),
                        StringHelper.GetLongestWord(text));
                }

                //to check if can open exclusively:
                // File.Open("test.txt", FileMode.Open, FileAccess.Read, FileShare.None);

                //if (! File.Exists(path))
                //{
                //    if (File.Exists(newPath))
                //        File.Delete(newPath);

                //    File.Copy(path, newPath, true);
                //    Console.WriteLine("file copied successfully");
                //    Console.ReadLine();
                //}
                //else
                //{
                //    throw new FileNotFoundException("File not found");
                //}

            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Access denied: {0}", e.Message);
            }
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Unable to copy file: {0}", e.Message);
            //}
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error encountered: {0}", e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void ShowPersonAge()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            var Person = new Person(new DateTime(1982, 2, 2));
            Console.WriteLine("Person age: {0}", Person.Age);
            Console.ReadLine();
        }

        private static void ShowIndexerUse()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);
            var cookie = new HttpCookie();

            cookie["name"] = "Bruce";

            Console.WriteLine(cookie["name"]);

            Console.ReadLine();
        }

        private static void ShowStopwatch()
        {

            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            var stopWatch = new Stopwatch();

            stopWatch.Start();
            System.Threading.Thread.Sleep(1000);
            stopWatch.Stop();

            stopWatch.Start();
            System.Threading.Thread.Sleep(1000);
            stopWatch.Stop();


            Dictionary<int, Stopwatch.timing> timings = stopWatch.GetTimings();

            for (int i = 0; i < timings.Count; i++)
            {
                Console.WriteLine($"Started: {timings[i].started}, Stopped: {timings[i].stopped}. Duration: {timings[i].duration}");
            }

            Console.ReadLine();

        }

        private static void ShowPostCount()
        {
            ConsoleHelper.ClearAndAnnounce(
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            var post = new Post("My Post Name", "My Post Description");

            post.AddVote(Post.VoteDirection.Up, DateTime.Now);
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(10));
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(20));
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(30));
            post.AddVote(Post.VoteDirection.Down, DateTime.Now.AddSeconds(40));

            Console.WriteLine($"Post '{post.Title}' has {post.GetVotes().Count} votes, totalling {post.GetVoteTally()}.");

            Console.ReadLine();
        }

        private static void ShowInheritance()
        {

            //Is A... relationship
            //(white triangle on right side (base class)in UML)

            var text = new Text();

            //text has it's own + inerited stuff from PresentationObject base class
            text.Width = 100;
            text.Copy();
            text.Duplicate();

        }

        private static void ShowComposition()
        {
            //Has A... relationship
            //(black diamon on left side of relationship in UML)

            var dbMigrator = new DBMigrator(new Logger());

            //or:
            var Logger = new Logger();
            var installer = new Installer(Logger);

            dbMigrator.Migrate();
            installer.Install();

        }

        private static void ShowShape()
        {
            //            NewText text = new NewText();
            //            Shape shape = text; //upcasting to base class

            //            text.Width = 200;
            //            shape.Width = 100;

            //            Console.WriteLine($"Width :{text.Width}");



            //            Shape shape2 = new NewText(); //downcasting base to derived class

            //            //NB to check convertible first:
            //            if (shape2 is NewText)
            //            {
            //                shape2 = (NewText)shape2;
            //            }

            //            //or:

            //            Object obj = null;
            //;
            //            var shape3 = obj as Shape;
            //            if (shape3 != null)
            //            {
            //                //yay - downcasts OK)
            //            }

            var shapes = new List<Shape> { new Circle(), new Rectangle() };
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }

        private static void ShowStack()
        {
            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }

        private static void ShowDbConnection()
        {
            string connect
                = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

            const string instruction = @"SELECT * FROM [dbo].[tblRaw_BDS_Stage]";

            DbCommand cmd = new DbCommand(new SqlDbConnection(connect), instruction);

            cmd.Execute();
        }

        private static void ShowWorkflow()
        {
            var workflow = new Workflow();

            workflow.RegisterActivity(new ActivityUploadToCloud());
            workflow.RegisterActivity(new ActivityEncoding());
            workflow.RegisterActivity(new ActivityEmailnotification());
            workflow.RegisterActivity(new ActivityUpdateStatus());

            workflow.Execute();
        }

        static void Main(string[] args)
        {
            //MaxOfTwo();

            //ImageWidthAndHeight();

            //TestValidity();

            //CheckSpeed();

            //GetRandoms();

            //ShowDivisibleByThree();

            //AddNumbers();

            //ShowFactorial();

            //GetMaxOfNumbers();

            //ListLarks();

            //BuildFacebookList();

            //DisplayReversedName();

            //ShowReversedList();

            //ShowUniqueEntries();

            //DisplayBottom3FromList();

            //ShowConsecutive();

            //ShowIfDuplicates();

            //ShowTimeValidity();

            //ShowInTitleCase();

            //ShowCountofVowels();

            //DisplayWordCountAndlongestWord();

            //ShowStopwatch();

            //ShowPostCount();

            //ShowInheritance();

            //ShowComposition();

            //ShowShape();

            //ShowStack();

            //ShowDbConnection();

            ShowWorkflow();
        }

    }
}
