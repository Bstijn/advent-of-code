// See https://aka.ms/new-console-template for more information
using day_two;

Console.WriteLine("Hello, World!");
Class1 class1 = new Class1(); 
foreach(var item in class1.Journey())
{
    Console.WriteLine(item.Key +":" +item.Value);
}