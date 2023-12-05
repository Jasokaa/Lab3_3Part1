using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace ClassLib;


[Serializable]
public class StringClass: ISerializable
{
    public string Value { get; set; }
    public int Length { get; set; }
    

    public StringClass() {}
    protected StringClass(SerializationInfo info, StreamingContext context)
    {
        Value = info.GetString("Value");
        //Length = info.GetInt32("Length");
    }

// Метод для серіалізації

    public void GetObjectData(SerializationInfo info, StreamingContext context)

    {
        info.AddValue("Value", Value);
        //info.AddValue("Length", Length);
    }
    public StringClass(string value)
    {
        this.Value = value;
        Length = value.Length;
    }

    public bool Search(char input)
    {
        return Value.Contains(input);
    }
    public string ChangeOrder()
    {
        char[] charArray = Value.ToCharArray();
        int left = 0;
        int right = Value.Length - 1;

        while (left < right)
        {
            char temp = charArray[left];
            charArray[left] = charArray[right];
            charArray[right] = temp;
            left++;
            right--;
        }

        return new string(charArray);
    }
    public void AddString(string input)
    {
        Value += input;
    }

    public override string ToString()
    {
        return "String is {" + Value + "} length = " + Length;
    }
    
}