﻿using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 4)
            {
                Console.WriteLine("Command not valid, Create requires a name, type of gradebook, if it's weighted (true / false).");
                return;
            }
            var name = parts[1];
            var type = parts[2];

            var IsWeighted = bool.Parse(parts[3]);

            //BaseGradeBook gradeBook = new BaseGradeBook(name, IsWeighted);
            //Console.WriteLine("Created gradebook {0}.", name);
            //GradeBookUserInterface.CommandLoop(gradeBook);

            BaseGradeBook gradeBook;

            if (type == "standard")
                gradeBook = new StandardGradeBook(name, IsWeighted);

            else if (type == "ranked")
                gradeBook = new RankedGradeBook(name, IsWeighted);
            else
            {
                Console.WriteLine("{type} is not a supported type of gradebook, please try again.");
                return;
            }

            Console.WriteLine("Created gradebook {0} of {1} type and {2} weight.", name, type, IsWeighted);


     
    }

        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("\tCreate 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
            Console.WriteLine("\tAddGrade 'Name' 'Grade' - Adds a grade to the gradebook specified by 'Name', with the value 'Grade'.");
            Console.WriteLine("\tGetStatistics 'Name' - Calculates and shows the statistics for the gradebook specified by 'Name'.");
            Console.WriteLine("\tShowGrades 'Name' - Shows all the grades for the gradebook specified by 'Name'.");
            Console.WriteLine("\tQuit - Exits the program.");
        }
    }
}
