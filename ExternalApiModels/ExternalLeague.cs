
public class ExternalLeague
{
    public string get { get; set; }
    public object[] parameters { get; set; }
    public object[] errors { get; set; }
    public int results { get; set; }
    public ExternalPagingLeague paging { get; set; }
    public ExternalResponseLeague[] response { get; set; }
}

public class ExternalPagingLeague
{
    public int current { get; set; }
    public int total { get; set; }
}

public class ExternalResponseLeague
{
    public ExternalLeagueLeague league { get; set; }
    public ExternalCountryLeague country { get; set; }
    public ExternalSeasonLaegues[] seasons { get; set; }
}

public class ExternalLeagueLeague
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string logo { get; set; }
}

public class ExternalCountryLeague
{
    public string name { get; set; }
    public string code { get; set; }
    public string flag { get; set; }
}

public class ExternalSeasonLaegues
{
    public int year { get; set; }
    public string start { get; set; }
    public string end { get; set; }
    public bool current { get; set; }
    public ExternalCoverageLeague coverage { get; set; }
}

public class ExternalCoverageLeague
{
    public ExternalFixturesLeague fixtures { get; set; }
    public bool standings { get; set; }
    public bool players { get; set; }
    public bool top_scorers { get; set; }
    public bool predictions { get; set; }
    public bool odds { get; set; }
}

public class ExternalFixturesLeague
{
    public bool events { get; set; }
    public bool lineups { get; set; }
    public bool statistics_fixtures { get; set; }
    public bool statistics_players { get; set; }
}

