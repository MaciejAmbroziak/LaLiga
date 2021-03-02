
public class ExternalSeazon
{
    public string get { get; set; }
    public object[] parameters { get; set; }
    public object[] errors { get; set; }
    public int results { get; set; }
    public Paging paging { get; set; }
    public int[] response { get; set; }
}

public class Paging
{
    public int current { get; set; }
    public int total { get; set; }
}
