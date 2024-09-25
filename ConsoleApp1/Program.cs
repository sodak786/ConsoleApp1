using Spectre.Console;
public static class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            var vyber = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Vítej do správce domácích úkolů[/]")
                .PageSize(10)
                .AddChoices(new[] {
                    "Pridat", "Smazat", "Zobrazit",
                }));

            List<string> ukoly = new List<string>();
            List<string> predmety = new List<string>();
            List<string> datumyOdevzdani = new List<string>();

            switch (vyber)
            {
                case "Pridat":
                    var ukol = AnsiConsole.Prompt(
                            new TextPrompt<string>("Název úkolu: ")
                        );
                    var predmet = AnsiConsole.Prompt(
                            new TextPrompt<string>("Předmět: ")
                        );
                    var datumOdevzdani = AnsiConsole.Prompt(
                            new TextPrompt<string>("Datum odevzdání: ")
                        );
                    ukoly.Add(ukol);
                    predmety.Add(predmet);
                    datumyOdevzdani.Add(datumOdevzdani);

                    break;

                case "Smazat":
                    if (ukoly.Any())
                    {
                        var ukolNaSmazani = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .PageSize(10)
                            .AddChoices(ukoly.ToArray())
                            );
                        var index = ukoly.IndexOf(ukolNaSmazani);
                        ukoly.RemoveAt(index);
                        predmety.RemoveAt(index);
                        datumyOdevzdani.RemoveAt(index);
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]Žádné úkoly k odstranění![/]");
                        Console.ReadKey();
                    }
                    break;

            }
        }
    }
}