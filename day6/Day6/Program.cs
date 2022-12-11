var dataStream = File.ReadAllLines("data/datastream.dat");

var packetSize = 4;
Console.WriteLine($"Start of Packet: {DataStream.StartOfWindow(dataStream.First(), packetSize)}");
var messageSize = 14;
Console.WriteLine($"Start of Message: {DataStream.StartOfWindow(dataStream.First(), messageSize)}");

public static class DataStream
{
    public static int StartOfWindow(string dataStream, int size)
    {
        var marker = new HashSet<char>();
        for (var i = size - 1; i < dataStream.Length; i++)
        {
            dataStream.Substring(i - size + 1, size).ToList().ForEach(c => marker.Add(c));
            if (marker.Count == size) return i + 1;
            marker = new HashSet<char>();
        }
        return -1;
    }
}