
using System;

public class ExternalLeagueInSeazon
{
    public string get { get; set; }
    public ParametersLeagueInSeazon parameters { get; set; }
    public object[] errors { get; set; }
    public int results { get; set; }
    public PagingLeagueInSeazon paging { get; set; }
    public ResponseLeagueInSeazon[] response { get; set; }
}

public class ParametersLeagueInSeazon
{
    public string league { get; set; }
    public string season { get; set; }
}

public class PagingLeagueInSeazon
{
    public int current { get; set; }
    public int total { get; set; }
}

public class ResponseLeagueInSeazon
{
    public FixtureLeagueInSeazon fixture { get; set; }
    public LeagueLeagueInSeazon league { get; set; }
    public TeamsLeagueInSeazon teams { get; set; }
    public GoalsLeagueInSeazon goals { get; set; }
    public ScoreLeagueInSeazon score { get; set; }
}

public class FixtureLeagueInSeazon
{
    public int id { get; set; }
    public string referee { get; set; }
    public string timezone { get; set; }
    public DateTime date { get; set; }
    public int timestamp { get; set; }
    public PeriodsLeagueInSeazon periods { get; set; }
    public VenueLeagueInSeazon venue { get; set; }
    public StatusLeagueInSeazon status { get; set; }
}

public class PeriodsLeagueInSeazon
{
    public int first { get; set; }
    public int second { get; set; }
}

public class VenueLeagueInSeazon
{
    public int id { get; set; }
    public string name { get; set; }
    public string city { get; set; }
}

public class StatusLeagueInSeazon
{
    public string _long { get; set; }
    public string _short { get; set; }
    public int elapsed { get; set; }
}

public class LeagueLeagueInSeazon
{
    public int id { get; set; }
    public string name { get; set; }
    public string country { get; set; }
    public string logo { get; set; }
    public string flag { get; set; }
    public int season { get; set; }
    public string round { get; set; }
}

public class TeamsLeagueInSeazon
{
    public HomeLeagueInSeazon home { get; set; }
    public AwayLeagueInSeazon away { get; set; }
}

public class HomeLeagueInSeazon
{
    public int id { get; set; }
    public string name { get; set; }
    public string logo { get; set; }
    public bool? winner { get; set; }
}

public class AwayLeagueInSeazon
{
    public int id { get; set; }
    public string name { get; set; }
    public string logo { get; set; }
    public bool? winner { get; set; }
}

public class GoalsLeagueInSeazon
{
    public int home { get; set; }
    public int away { get; set; }
}

public class ScoreLeagueInSeazon
{
    public HalftimeLeagueInSeazon halftime { get; set; }
    public FulltimeLeagueInSeazon fulltime { get; set; }
    public ExtratimeLeagueInSeazon extratime { get; set; }
    public PenaltyLeagueInSeazon penalty { get; set; }
}

public class HalftimeLeagueInSeazon
{
    public int home { get; set; }
    public int away { get; set; }
}

public class FulltimeLeagueInSeazon
{
    public int home { get; set; }
    public int away { get; set; }
}

public class ExtratimeLeagueInSeazon
{
    public object home { get; set; }
    public object away { get; set; }
}

public class PenaltyLeagueInSeazon
{
    public object home { get; set; }
    public object away { get; set; }
}
