namespace Ants
{

    public class Location : IEquatable<Location>
    {

        /// <summary>
        /// Gets the row of this location.
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// Gets the column of this location.
        /// </summary>
        public int Col { get; private set; }

        public Location(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Location))
                return false;

            return Equals((Location)obj);
        }

        public bool Equals(Location other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return other.Row == Row && other.Col == Col;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1067:Override Object.Equals(object) when implementing IEquatable<T>", Justification = "<Pending>")]
    public class TeamLocation : Location, IEquatable<TeamLocation>
    {
        /// <summary>
        /// Gets the team of this ant.
        /// </summary>
        public int Team { get; private set; }

        public TeamLocation(int row, int col, int team) : base(row, col)
        {
            Team = team;
        }

        public bool Equals(TeamLocation other)
        {
            return base.Equals(other) && other.Team == Team;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Col;
                result = (result * 397) ^ Row;
                result = (result * 397) ^ Team;
                return result;
            }
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1067:Override Object.Equals(object) when implementing IEquatable<T>", Justification = "<Pending>")]
    public class Ant : TeamLocation, IEquatable<Ant>
    {
        public Ant(int row, int col, int team) : base(row, col, team)
        {
        }

        public bool Equals(Ant other)
        {
            return base.Equals(other);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1067:Override Object.Equals(object) when implementing IEquatable<T>", Justification = "<Pending>")]
    public class AntHill : TeamLocation, IEquatable<AntHill>
    {
        public AntHill(int row, int col, int team) : base(row, col, team)
        {
        }

        public bool Equals(AntHill other)
        {
            return base.Equals(other);
        }
    }
}

