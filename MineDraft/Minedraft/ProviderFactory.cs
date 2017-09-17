using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Get(int id, List<string> arguments)
    {
        switch (id)
        {
            case 0:
                return new SolarProvider(arguments[1], double.Parse(arguments[2]));
            case 1:
                return new PressureProvider(arguments[1],double.Parse(arguments[2]));
            default:
                return null;
        }
    }
}

public enum ProviderFactoryId
{
    Solar = 0,
    Pressure = 1
}

