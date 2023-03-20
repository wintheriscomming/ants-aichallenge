namespace Ants;

public static class EnumerableExtensions
{
    // Fisher-Yates shuffle courtesy of StackOverflow
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
    {
        T[] elements = source.ToArray();
        // Note i > 0 to avoid final pointless iteration
        for (var i = elements.Length - 1; i > 0; i--)
        {
            // Swap element "i" with a random earlier element it (or itself)
            var swapIndex = rng.Next(i + 1);
            (elements[swapIndex], elements[i]) = (elements[i], elements[swapIndex]);
        }
        // Lazily yield (avoiding aliasing issues etc)
        foreach (T element in elements)
        {
            yield return element;
        }
    }
}