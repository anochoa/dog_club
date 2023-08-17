using System;
using System.Threading;

namespace dog.infra;

public static class ThreadExtensions
{
    public static int Config(this int elem)
    {
        Random random = new Random();
        int randomNumber = random.Next(1000, 5001) * elem;

        Thread.Sleep(randomNumber);
        return elem;
    }

    public static List<T> ConfigList<T>(this List<T> elem) where T : class
    {
        elem.Count().Config();
        return elem;
    }
}