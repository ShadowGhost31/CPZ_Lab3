using System;
using System.IO;
using System.Text.RegularExpressions;


public interface ITextReader
{
    string[][] ReadText(string filePath);
}


public class SmartTextReader : ITextReader
{
    public string[][] ReadText(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        string[][] result = new string[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].ToCharArray().Select(c => c.ToString()).ToArray();
        }
        return result;
    }
}


public class SmartTextChecker : ITextReader
{
    private readonly ITextReader textReader;

    public SmartTextChecker(ITextReader textReader)
    {
        this.textReader = textReader;
    }

    public string[][] ReadText(string filePath)
    {
        Console.WriteLine("Opening file: " + filePath);
        string[][] result = textReader.ReadText(filePath);
        Console.WriteLine("File read successfully!");
        Console.WriteLine($"Total lines: {result.Length}");
        int totalCharacters = 0;
        foreach (var line in result)
        {
            totalCharacters += line.Length;
        }
        Console.WriteLine($"Total characters: {totalCharacters}");
        Console.WriteLine("Closing file...");
        return result;
    }
}


public class SmartTextReaderLocker : ITextReader
{
    private readonly ITextReader textReader;
    private readonly Regex filePattern;

    public SmartTextReaderLocker(ITextReader textReader, string filePattern)
    {
        this.textReader = textReader;
        this.filePattern = new Regex(filePattern);
    }

    public string[][] ReadText(string filePath)
    {
        if (filePattern.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return new string[0][]; 
        }
        else
        {
            return textReader.ReadText(filePath);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        ITextReader smartTextChecker = new SmartTextChecker(new SmartTextReader());

        
        ITextReader smartTextLocker = new SmartTextReaderLocker(new SmartTextReader(), @"lockedfile\d+\.txt");

        
        Console.WriteLine("Using SmartTextChecker:");
        smartTextChecker.ReadText("textfile.txt");

        
        Console.WriteLine("\nUsing SmartTextReaderLocker:");
        smartTextLocker.ReadText("textfile.txt");
        smartTextLocker.ReadText("lockedfile1.txt");
        smartTextLocker.ReadText("lockedfile2.txt");
        smartTextLocker.ReadText("textfile.txt");
        smartTextChecker.ReadText("textfile.txt");
    }
}
