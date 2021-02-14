
public class ExternalMatch
{
    public string get { get; set; }
    public ParametersH2H parameters { get; set; }
    public object[] errors { get; set; }
    public int results { get; set; }
    public PagingH2H paging { get; set; }
    public ResponseH2H[] response { get; set; }
}

public class ParametersH2H
{
    public string fixture { get; set; }
}

public class PagingH2H
{
    public int current { get; set; }
    public int total { get; set; }
}

public class ResponseH2H
{
    public TeamH2H team { get; set; }
    public StatisticH2H[] statistics { get; set; }
}

public class TeamH2H
{
    public int id { get; set; }
    public string name { get; set; }
    public string logo { get; set; }
}

public class StatisticH2H
{
    public string type { get; set; }
    public object value { get; set; }
}
