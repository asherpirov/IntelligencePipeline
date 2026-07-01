using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline;



class Program
{
    

    public static void Main()
    {
        SoldierReport a = new SoldierReport(1, DateTime.Now, 30.5, 34.5, "Weapon","asher", "8809022","8200",4);
        Console.WriteLine(a.ToString());
        Console.WriteLine(a.GetSourceType());
        Console.WriteLine(a.CalculateReliabilityScore());
    }
}