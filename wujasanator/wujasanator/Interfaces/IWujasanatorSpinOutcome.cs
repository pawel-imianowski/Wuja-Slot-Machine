namespace wujasanator.Interfaces
{
    ///<summary>
    ///Spin outcome entity to be used in Wujasonator information.
    ///</summary>
    ///<remarks>
    ///Adds a <paramref name="Bonuses"/> field to <paramref name="ISpinOutcome"/>
    ///</remarks>
    public interface IWujasanatorSpinOutcome : ISpinOutcome
    {
        ///<summary>
        ///Contains a list of bonuses to be applied
        ///</summary>
        IEnumerable<string> Bonuses { get; set; }
    }
}