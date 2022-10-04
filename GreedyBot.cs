namespace Ants
{
    class GreedyBot : Bot
    {
        readonly Random rng;
        readonly HashSet<Location> destinations;

        public GreedyBot()
        {
            rng = new Random(42);
            destinations = new HashSet<Location>();
        }

        // doTurn is run once per turn
        public override void DoTurn(IGameState state)
        {

            destinations.Clear();

            // loop through all my ants and try to give them orders
            foreach (var ant in state.MyAnts)
            {

                Location closestFood = null;
                int closestDist = int.MaxValue;
                foreach (Location food in state.FoodTiles)
                {
                    int dist = state.GetDistance(ant, food);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closestFood = food;
                    }
                }

                IEnumerable<Direction> directions;
                if (closestFood != null) directions = state.GetDirections(ant, closestFood);
                else directions = Ants.Aim.Keys.Shuffle(rng);

                // try all the directions
                foreach (Direction direction in directions)
                {

                    // destination will wrap around the map properly
                    // and give us a new location
                    Location newLoc = state.GetDestination(ant, direction);

                    // passable returns true if the location is land
                    if (state.GetIsUnoccupied(newLoc) && !destinations.Contains(newLoc))
                    {
                        IssueOrder(ant, direction);
                        destinations.Add(newLoc);
                        // stop now, don't give 1 and multiple orders
                        break;
                    }
                }

                // check if we have time left to calculate more orders
                if (state.TimeRemaining < 10) break;
            }

        }

        public static void Main(string[] args)
        {
            new Ants().PlayGame(new GreedyBot());
        }
    }

    public static class Extensions
    {
        // Fisher-Yates shuffle courtesy of StackOverflow
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Length - 1; i > 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = rng.Next(i + 1);
                (elements[swapIndex], elements[i]) = (elements[i], elements[swapIndex]);
            }
            // Lazily yield (avoiding aliasing issues etc)
            foreach (T element in elements)
            {
                yield return element;
            }
        }
    }

}