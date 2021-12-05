// See https://aka.ms/new-console-template for more information
using _4;
var watch = System.Diagnostics.Stopwatch.StartNew();
// the code that you want to measure comes here
Console.WriteLine("Hello, World!");
Bingo bingo = new Bingo();
bingo.Play();
watch.Stop();
Console.WriteLine("Amount of ms:" + watch.ElapsedMilliseconds);
Console.ReadLine();