using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class Helpers
{
    public static T Deserialize<T>(byte[] param)
    {
        using (MemoryStream ms = new MemoryStream(param))
        {
            IFormatter br = new BinaryFormatter(); //Optimize
            return (T)br.Deserialize(ms);
        }
    }

    public static byte[] Serialize<T>(T obj)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            IFormatter br = new BinaryFormatter(); //Optimize
            br.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}