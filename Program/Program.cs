using System.Reflection;
using ClassLib;
namespace Program;
internal static class Program
{
    [Obsolete]
    public static void Main(string[] args)
    {
        List<StringClass> StringGenericList = new List<StringClass>
        {
            new StringClass("Cat"),
            new StringClass("Bird"),
            new StringClass("Kitten"),
            new StringClass("Fish")
        };
        Console.WriteLine("List:");
        foreach (StringClass line in StringGenericList)
        {
            Console.WriteLine(line);
        }
        
        Console.WriteLine("\nBINARY Serialization:");
        Bin<StringClass> a = new Bin<StringClass>();
       a.write(StringGenericList, "fileBin");
        List<StringClass> listB = a.read("fileBin");
        Console.WriteLine("List after BINARY serialization:");
        foreach (StringClass line in listB)
        {
            if (line != null)
            {
                Console.WriteLine("Value {" + line.Value + "} length = " + line.Length);
            }
        }
        
        Console.WriteLine("\nJSON Serialization:");
        JSON<StringClass> b = new JSON<StringClass>();
        b.write(StringGenericList, "fileJSON");
        List<StringClass> listJSON = b.read("fileJSON");
        Console.WriteLine("Array after JSON serialization:");
        foreach (StringClass? line in listJSON)
        {
            if (line != null)
            {
                Console.WriteLine("Value {" + line.Value + "} length = " + line.Length);
            }
        }
        
        Console.WriteLine("\nXML Serialization:");
        XML<StringClass> c = new XML<StringClass>();
        c.write(StringGenericList, "fileXML");
        List<StringClass> listXML = c.read("fileXML");
        Console.WriteLine("List after XML serialization:");
        foreach (StringClass line in listXML)
        {
            if (line != null)
            {
                Console.WriteLine("Value {" + line.Value + "} length = " + line.Length);
            }
        }
    }
}