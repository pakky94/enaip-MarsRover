using System;

namespace MarsRover
{
    public static class RandomExtensions
    {
        public static T Enum<T>(this Random rand)
            where T : Enum
        {
            var values = typeof(T).GetEnumValues();
            return (T)values.GetValue(rand.Next(values.Length));
        }
    }
}
