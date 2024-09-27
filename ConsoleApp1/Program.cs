using Spectre.Console;
public static class Program
{
    public static void Main(string[] args)
    {
        List<string> ukoly = new List<string>();
        List<string> predmety = new List<string>();
        List<string> datumyOdevzdani = new List<string>();

        AnsiConsole.Write(
            new FigletText("Správce úkolů")
                .Centered()
                .Color(Color.BlueViolet)
            );
        Console.ReadKey();
        while (true)
        {
            Console.Clear();
            var vyber = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoices(new[] {
                    "Pridat", "Smazat", "Zobrazit", "Zavrit",
                }));

            switch (vyber)
            {
                case "Pridat":
                    var ukol = AnsiConsole.Prompt(
                            new TextPrompt<string>("[bold yellow]Název úkolu: [/]")
                        );
                    var predmet = AnsiConsole.Prompt(
                            new TextPrompt<string>("[bold yellow]Předmět: [/]")
                        );
                    var datumOdevzdani = AnsiConsole.Prompt(
                            new TextPrompt<string>("[bold yellow]Datum odevzdání: [/]")
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

                case "Zobrazit":
                    var table = new Table();
                    table.Border = TableBorder.Minimal;
                    table.BorderColor(Color.DarkSlateGray3);
                    table.Width = 80;
                    table.Centered();
                    table.AddColumn("[yellow bold]Úkol[/]");
                    table.AddColumn("[bold yellow]Předmět[/]");
                    table.AddColumn("[bold yellow]Datum odevzdání[/]");
                    for (int x=0; x<ukoly.Count; x++)
                    {
                        table.AddRow(ukoly[x], predmety[x], datumyOdevzdani[x]);
                    }
                    AnsiConsole.Render(table);
                    Console.ReadKey();
                    break;


                case "Zavrit":
                    return;
            }
        }
    }
}