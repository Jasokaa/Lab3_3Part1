
using System.Xml.Serialization;

namespace ClassLib;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.Json;

public interface IDatabaseMethods<T>
{
    void write(List<T> list, string file);
    List<T> read(string file);
}

public class Bin<T> : IDatabaseMethods<T>
{
    public Bin() {}
    [Obsolete]
    public void write(List<T> list, string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(file + ".bin", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fileStream, list);
        }
    }
    [Obsolete]
    public List<T> read(string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(file + ".bin", FileMode.Open))
        {
            return (List<T>)formatter.Deserialize(fileStream);
        }
    }
}
public class JSON<T> : IDatabaseMethods<T>
{
    public JSON() {}
    public void write(List<T> list, string file)
    {
        using (FileStream fileStream = new FileStream(file + ".json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fileStream, list);
        }
    }
    public List<T> read(string file)
    {
        using (FileStream fileStream = new FileStream(file + ".json", FileMode.Open))
        {
            return (List<T>)JsonSerializer.Deserialize(fileStream, typeof(List<T>));
        }
    }
}
public class XML<T> : IDatabaseMethods<T>
{
    public XML() {}
    public void write(List<T> list, string file)
    {
        using (FileStream fileStream = new FileStream(file + ".xml", FileMode.OpenOrCreate))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            formatter.Serialize(fileStream, list);
        }
    }
    public List<T> read(string file)
    {
        List<T> deserializedObjects;
        using (FileStream fileStream = new FileStream(file + ".xml", FileMode.Open))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            deserializedObjects = (List<T>)formatter.Deserialize(fileStream);
        }
        return deserializedObjects;
    }
}

/*public class Custom<T> : IDatabaseMethods<T>
{
    public Custom() {}
    [Obsolete]
    public void write(List<T> list, string file)
    {
        IFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(file+".dat", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fileStream, list);
        }
    }
    [Obsolete]
    public List<T> read(string file)
    {
        IFormatter formatter = new BinaryFormatter();
        List<T> deserializedObjects;
        using (Stream fileStream = new FileStream(file + ".dat", FileMode.Open))
        {
            deserializedObjects = (List<T>)formatter.Deserialize(fileStream);
        }
        return deserializedObjects;
    }
}*/