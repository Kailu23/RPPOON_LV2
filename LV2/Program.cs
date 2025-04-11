using System;
using System.Collections.Generic;
using LV2;

class Program
{
    static void Main(string[] args)
    {
        TestDiceRollerWithSharedRandom();
    }

    //Zad 1. i 2.
    static void TestDiceRollerWithSharedRandom()
    {
        Random sharedRandom = new Random();

        DiceRoller roller = new DiceRoller();

        for (int i = 0; i < 20; i++)
        {
            roller.InsertDie(new Die(6, sharedRandom));
        }

        roller.RollAllDice();

        IList<int> results = roller.GetRollingResults();

        Console.WriteLine("Bacanje 20 kockica sa zajedničkim Random objektom");
        if (results.Count != 20)
        {
            Console.WriteLine($"Test neuspješan: Očekivano 20 rezultata, dobijeno {results.Count}");
        }
        else
        {
            Console.WriteLine("Test uspješan: 20 kockica je bačeno.");
            for (int i = 0; i < results.Count; i++)
            {
                int result = results[i];
                Console.WriteLine($"Kockica {i + 1}: {result}");

                if (result < 1 || result > 6)
                {
                    Console.WriteLine($"Rezultat: {result} (van opsega 1-6)");
                }
            }
        }
    }

    static void TestFileAndConsoleLogger()
    {
        // Prvi DiceRoller s ConsoleLoggerom
        DiceRoller consoleLogger = new DiceRoller();
        consoleLogger.InjectLogger(new ConsoleLogger());

        for (int i = 0; i < 5; i++)
            consoleLogger.InsertDie(new Die(6));

        consoleLogger.RollAllDice();
        consoleLogger.LogRollingResults();

        // Drugi DiceRoller s FileLoggerom
        DiceRoller fileLogger = new DiceRoller();
        fileLogger.InjectLogger(new FileLogger("log_zadatak4.txt"));

        for (int i = 0; i < 5; i++)
            fileLogger.InsertDie(new Die(6));

        fileLogger.RollAllDice();
        fileLogger.LogRollingResults();

        Console.WriteLine("✅ Zadatak 4: Logiranje završeno (console i datoteka).");
    }

    static void TestILogable()
    {
        DiceRoller roller = new DiceRoller();

        for (int i = 0; i < 5; i++)
            roller.InsertDie(new Die(6));

        roller.RollAllDice();

        ILogger consoleLogger = new ConsoleLogger();
        consoleLogger.Log(roller);

        ILogger fileLogger = new FileLogger("log_primjer5.txt");
        fileLogger.Log(roller);

        Console.WriteLine("✅ Primjer 5: Rezultati su logirani (console i datoteka).");
    }
}
