using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Get(int id, List<string> arguments)
    {
        switch (id)
        {
            case 0:
                return new SonicHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]), int.Parse(arguments[4]));
            case 1:
                return new HammerHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
            default:
                return null;
        }

    }
}

public enum HarvesterFactoryId
{
    Sonic = 0,
    Hammer = 1
}

