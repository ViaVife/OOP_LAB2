using System;

Console.WriteLine("\n\n");
new Lab2_Versia1().No_Async();
Console.WriteLine("\n\n");
new Lab2_Versia2().Async().GetAwaiter().GetResult();
