namespace wujasanator.Interfaces
{
    ///<summary>
    ///Generic entity containing slots' spin outcome information.
    ///</summary>
    ///<remarks>
    ///Created mainly to be implemented in slot-specific interfaces, but can as well be used for simple slots.
    ///</remarks>
    public interface ISpinOutcome
    {
        ///<summary>
        ///A 2d array containing IDs of tile types to be displayed to the user
        ///</summary>
        int[,] TileMatrix { get; set; }
        ///<summary>
        ///Generic entity containing slots' spin outcome information.
        ///</summary>
        decimal Reward { get; set; }
    }
}