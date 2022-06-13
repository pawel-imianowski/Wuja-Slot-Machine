namespace wujasanator.Models
{
    ///<see cref="IWujasanatorSpinOutcome">
    public class WujasanatorSpinOutcome : IWujasanatorSpinOutcome
    {
        ///<see cref="ISpinOutcome.TileMatrix">
        public int[,] TileMatrix { get; set; } = new int[5,3];
        ///<see cref="ISpinOutcome.Reward">
        public decimal Reward {get;set;}
        ///<see cref="IWujasanatorSpinOutcome.TileMatrix">
        public IEnumerable<string> Bonuses {get;set;} = new string[0];

        public WujasanatorSpinOutcome(int[,] tileMatrix, decimal reward)
        {
            TileMatrix = tileMatrix;
            Reward = reward;
        }
        public WujasanatorSpinOutcome(int[,] tileMatrix, decimal reward, IEnumerable<string> bonuses)
        {
            TileMatrix = tileMatrix;
            Reward = reward;
            Bonuses = bonuses;
        }
    }
}