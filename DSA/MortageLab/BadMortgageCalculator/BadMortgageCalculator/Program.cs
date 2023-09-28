using Spectre.Console;
using BadMortgageCalculator;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace MyApp {
    public static class Program {

        static List<Mortgage> allMortgages = new List<Mortgage>();

        public static void Main(string[] args) {

            // ========== SETUP ==========

            // emoji time enabler
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // dictionary of all menu options and their delegates when chosen
            Dictionary<string, Delegate> allOptionsToFunctions = new() {
                { "Show All Mortgages", ShowAllMortgages },
                { "Create a Mortgage", CreateAMortgage },
                { "Load Mortgages From File", LoadMortgagesFromFile },
                { "Exit", ExitTasks }
            };

            // setup and styling for the main menu prompt
            var mainMenuSelectionPrompt = new SelectionPrompt<string>()
                .Title("[fuchsia]Mortgage Calculator :derelict_house::house:[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                .AddChoices(allOptionsToFunctions.Keys);
            
            // initial user selection
            var userSelection = String.Empty;

            // ========== MAIN LOOP ==========

            while (true) {

                // get user input
                userSelection = AnsiConsole.Prompt(mainMenuSelectionPrompt);

                // run selected delegate if in dictionary, else throw exception
                if (allOptionsToFunctions.ContainsKey(userSelection)) {
                    allOptionsToFunctions[userSelection].DynamicInvoke();
                } else { AnsiConsole.WriteException(new Exception("whups sometin went wiwwy wong:persevering_face:")); }

                // finished program, because Exit was chosen cleanup was already done
                if (userSelection.ToLower() == "exit") { break; }

            }

        }

        public static void ShowAllMortgages() {

            while (true) { 

                var mortgageSelectionPrompt = new SelectionPrompt<string>()
                    .Title("[fuchsia]All Mortgages[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(allMortgages.Count > 0 ? allMortgages.Select(x => x.Address).Concat(new[] { "Back" }) : new[] { "Back" });

                var userSelection = AnsiConsole.Prompt(mortgageSelectionPrompt);

                if (userSelection.ToLower() == "back") { break; }

                DisplayAMortgage(allMortgages.Where(x => x.Address == userSelection).Single());

            }

            AnsiConsole.Console.Clear();

        }

        public static void DisplayAMortgage(Mortgage mortgage) {
            AnsiConsole.Console.Clear();
            var panel = new Panel($"Principal: ${mortgage.Principal}\nOrigin Date: {mortgage.OriginDate}\nInterest Rate: %{mortgage.InterestRate}");
            panel.Header = new PanelHeader(mortgage.Address);
            panel.Border = BoxBorder.Heavy;
            AnsiConsole.Write(panel);
        }

        public static void CreateAMortgage() {

            allMortgages.Add(new Mortgage("123 Spooner", DateTime.Now, new List<Payment>(), Terms.ThirtyYear, 10000, 6.5));
            allMortgages.Add(new Mortgage("654 West Ave", DateTime.Now, new List<Payment>(), Terms.FifteenYear, 12345, 7.5));
            allMortgages.Add(new Mortgage("925 Martin Luther", DateTime.Now, new List<Payment>(), Terms.TenYear, 54321, 5.3));

        }

        public static void LoadMortgagesFromFile() {
            using (StreamReader reader = new StreamReader("Mortgages.txt")) {
                var json = reader.ReadLine();
                if (json != null) { allMortgages = JsonConvert.DeserializeObject<List<Mortgage>>(json); }
            }
        }

        public static void SaveMorgages() {
            using (StreamWriter writer = new StreamWriter("Mortgages.txt")) {
                    writer.WriteLine(JsonConvert.SerializeObject(allMortgages));
            }
        }

        public static void ExitTasks() {

            AnsiConsole.Console.Clear();

            // save current open mortgages
            SaveMorgages();

            AnsiConsole.Markup("See you later alligator :crocodile:");

        }
    }
}



/// prompt user with startup menu of
/// - show all mortagages
///      - select a mortage
///          maybe this displays more info???
///          - delete
/// - load mortages from file
/// - create a mortgage
/// - delete a mortgage
/// - exit

