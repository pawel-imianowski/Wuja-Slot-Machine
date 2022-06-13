namespace wujasanator.Interfaces
{
    ///<summary>
    ///Service which contains Wujasonator's logic
    ///</summary>
    public interface IWujasanatorService
    {
        ///<summary>
        ///Calculates and returns an outcome of a spin.
        ///</summary>
        ///<returns>
        ///Calculated <paramref name="IWujasanatorSpinOutcome">
        ///</returns>
        WujasanatorSpinOutcome GetSpinOutcome(decimal cost);
    }
}
