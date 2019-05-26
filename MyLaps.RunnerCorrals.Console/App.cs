using MyLaps.RunnerCorrals.Model;
using System;
using System.Linq;

namespace MyLaps.RunnerCorrals.ConsoleApp
{
    internal class App
    {
        private readonly IWorkflowEngine workflowEngine;
        public App(IWorkflowEngine workflowEngine)
        {
            this.workflowEngine = workflowEngine;
        }

        public void Run()
        {
            do
            {

                var corralNames = workflowEngine.Corrals.Select(x => x.Name);
                var selectedCorral = SelectCorral(corralNames);
                string selectedCriteria = null;
                if (selectedCorral != "N")
                {
                    selectedCriteria = SelectCriteria(selectedCorral);
                }

                if (selectedCorral == "N" || selectedCriteria == "N")
                {
                    workflowEngine.Distribute();

                    Console.WriteLine("Visualise Runner, Pick a Cooral: ");
                    foreach (var corral in workflowEngine.Corrals)
                    {
                        Console.WriteLine(
                            $"[{corral.Name}] Max Runners: {corral.MaxElements} Current Runner : {corral.Count}");
                    }



                }
                else
                {
                    ConfigureCorralCriteria(selectedCorral, selectedCriteria);
                }

            } while (true);
        }

        private void ConfigureCorralCriteria(string selectedCorral, string selectedCriteria)
        {
            switch (selectedCriteria)
            {
                case "1":
                    Console.WriteLine($"Age criteria for Corral {selectedCorral}.");
                    Console.WriteLine("Input minimum age: ");
                    var minAge = ReadIntegerFromConsole();
                    Console.WriteLine("Input maximum age: ");
                    var maxAge = ReadIntegerFromConsole();
                    workflowEngine.ApplyAgeCriteria(selectedCorral, minAge, maxAge);
                    break;
                case "2":
                    Console.WriteLine($"Race Time criteria for Corral {selectedCorral}.");
                    Console.WriteLine("Input minimum Time: ");
                    var minTime = ReadIntegerFromConsole();
                    Console.WriteLine("Input maximum Time: ");
                    var maxTime = ReadIntegerFromConsole();
                    workflowEngine.ApplyTimeCriteria(selectedCorral, minTime, maxTime);
                    break;
                case "3":
                    Console.WriteLine($"Gender criteria for Corral {selectedCorral}.");
                    Console.WriteLine("Input Gender [M]ale/[F]emale: ");
                    Gender gender = ReadGenderFromConsole();
                    workflowEngine.ApplyGenderCriteria(selectedCorral, gender);
                    break;
                default:
                    Console.Error.WriteLine("Invalid Criteria");
                    break;
            }
        }

        private static Gender ReadGenderFromConsole()
        {
            string genderString;
            do
            {
                genderString = Console.ReadKey().KeyChar.ToString().ToUpper();
            } while (genderString != "M" && genderString != "F");
            var gender = (Gender)Enum.Parse(typeof(Gender), genderString);
            return gender;
        }

        private static int ReadIntegerFromConsole()
        {
            int number;
            var parsedValue = false;
            do
            {
                var inputValue = Console.ReadLine();
                parsedValue = Int32.TryParse(inputValue, out number);
            } while (parsedValue);

            return number;
        }

        private static string SelectCriteria(string selectedCorral)
        {
            string selectedCriteria;
            do
            {
                Console.Clear();
                Console.WriteLine($"Criteria Selection for Corral [{selectedCorral}]");
                Console.WriteLine();

                Console.WriteLine($"Availale Criterias:");
                Console.WriteLine($"[1] Age Criteria");
                Console.WriteLine($"[2] Race Time Criteria");
                Console.WriteLine($"[3] Gender Criteria");

                Console.WriteLine("Select Criteria: ");
                selectedCriteria = Console.ReadKey().KeyChar.ToString();
            } while (!new[] { "1", "2", "3" }.Contains(selectedCriteria));

            return selectedCriteria;
        }

        private string SelectCorral(System.Collections.Generic.IEnumerable<string> corralNames)
        {
            string selectedCorral;
            do
            {
                Console.Clear();
                Console.WriteLine("Corral List");
                foreach (var corral in workflowEngine.Corrals)
                {
                    Console.WriteLine($"[{corral.Name}] Max Runners: {corral.MaxElements}");
                }

                Console.WriteLine();
                Console.Write($"Type Corral name to configure or [N] to proced : ");
                selectedCorral = Console.ReadKey().KeyChar.ToString().ToUpper();

            } while (!corralNames.Contains(selectedCorral) && selectedCorral != "N");
            return selectedCorral;
        }

        static void NewConsoleLine(int count = 1)
        {
            for (var i = 0; i < count; i++)
                System.Console.WriteLine();
        }
    }
}
