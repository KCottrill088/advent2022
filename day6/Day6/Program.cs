var dataStream = File.ReadAllLines("data/datastream.dat");

dataStream.ToList().ForEach(l => Console.WriteLine(DataStream.StartOfPacket(l)));

public static class DataStream
{
    public static int StartOfPacket(string stream)
    {
        var marker = new HashSet<char>();
        for (var i = 3; i < stream.Length; i++)
        {
            stream.Substring(i - 3, 4).ToList().ForEach(c => marker.Add(c));
            if (marker.Count == 4) return i + 1;
            marker = new HashSet<char>();
        }
        return -1;
    }
}