
public class ExternalTeam
{
    public string get { get; set; }
    public TeamParameters parameters { get; set; }
    public object[] errors { get; set; }
    public int results { get; set; }
    public TeamPaging paging { get; set; }
    public TeamResponse[] response { get; set; }
}

public class TeamParameters
{
    public string league { get; set; }
    public string season { get; set; }
}

public class TeamPaging
{
    public int current { get; set; }
    public int total { get; set; }
}

public class TeamResponse
{
    public TeamTeam team { get; set; }
    public TeamVenue venue { get; set; }
}

public class TeamTeam
{
    public int id { get; set; }
    public string name { get; set; }
    public string country { get; set; }
    public int founded { get; set; }
    public bool national { get; set; }
    public string logo { get; set; }
}

public class TeamVenue
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public int capacity { get; set; }
    public string surface { get; set; }
    public string image { get; set; }
}
