using System;

namespace DieRollsFrequencyTable
{
    class Program
    {
        static void Main(string[] args)
        {
                {
      // Deklarerar lokala variabler.
      int count;
      int[] frequncyTable;

      // Läser in hur många tärningskast som ska simuleras då
      // en frekvenstabell över tärningskast skapas och presenteras.
      count = ReadNumberOfRolls();
      frequncyTable = CreateDieRollsFrequencyTable(count);
      ViewFrequencyTable(frequncyTable);
    }

    /// <summary>
    /// Simulerar tärningskast, skapar och returnerar frekvenstabell över utfallet.
    /// </summary>
    /// <param name="count">Antal tärningskast att simulera.</param>
    /// <returns>Array innehållande frekvenstabell över simulerade tärningskast.</returns>
    private static int[] CreateDieRollsFrequencyTable(int count)
    {
      // Deklarerar lokala variabler.
      int[] frequncyTable = new int[6];
      Random die = new Random();

      // Slumpar tärningskast och uppdaterar frekvenstabellen som därefter returneras.
      for (int i = 0; i < count; i++)
      {
        frequncyTable[die.Next(6)]++;
      }

      return frequncyTable;
    }

    /// <summary>
    /// Efterfrågar, läser in och returnerar antalet tärningskast som ska simuleras.
    /// </summary>
    /// <returns>Antal tärningskast.</returns>
    private static int ReadNumberOfRolls()
    {
      // Deklarerar lokala variabler.
      int count;

      // Läser in och returnerar ett heltal mellan 100 och 1000.
      while (true)
      {
        try
        {
          Console.Write("Ange antal tärningskast [100-1000]: ");
          count = int.Parse(Console.ReadLine());
          if (!(count >= 100 && count <= 1000))
          {
            throw new ApplicationException();
          }

          return count;
        }
        catch (Exception)
        {
          Console.BackgroundColor = ConsoleColor.Red;
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("\nFEL! Ange ett heltal mellan 100 och 1000.\n");
          Console.ResetColor();
        }
      }
    }

    /// <summary>
    /// Presenterar en frekvenstabell över tärningskast.
    /// </summary>
    /// <param name="frequncyTable">Referens till frekvenstabell i form av en array
    /// innehållade utfallet av tärningskast.</param>
    private static void ViewFrequencyTable(int[] frequncyTable)
    {
      // Deklarerar lokal variabel.
      string[] facets = { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor" };

      // Går igenom tärningssida för tärningssida och skriver ut tärningssidans
      // namn samt antalet gånger sidan "kommit upp" vid ett tärningskast.
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("\n----------------");
      Console.WriteLine(" Frekvenstabell ");
      Console.WriteLine("----------------");
      Console.ResetColor();
      for (int i = 0; i < facets.Length; i++)
      {
        Console.WriteLine($" {facets[i],-7} | {frequncyTable[i],4}");
        Console.WriteLine("----------------");
      }
        }
    }
}