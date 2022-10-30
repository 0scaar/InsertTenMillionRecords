// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using TemMillionsRecords.Code;

Console.WriteLine("Processing");

var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
var route = Path.Combine(root, @"File\data.txt");
//Console.WriteLine(route);


// Creating File with ten millon records 
//Util.Warmup(route);

// Creating File with ten millon records 
//Util.CreateFileWithData(10_000_000, route);

Console.WriteLine("Inserting data in SQL Server");

Stopwatch sw = new Stopwatch();

sw.Start();

//Console.WriteLine("--Efficient way--");
//EfficientCode.InsertData(route);

sw.Stop();

Console.WriteLine($"Duration: {sw.ElapsedMilliseconds / 1000.0} seconds");

sw.Restart();

Console.WriteLine("--Inefficient way--");
InefficientCode.InsertData(route);

sw.Stop();

Console.WriteLine($"Duration: {sw.ElapsedMilliseconds / 1000.0} seconds");

Console.WriteLine("The end");
