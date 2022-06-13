namespace wujasanator.Models
{
    ///<see cref="IWujasanatorSpinOutcome">
    public class WujasanatorSpinOutcome
    {
        public int[,] TileMatrix { get; set; } = new int[5,3];
        public decimal Reward {get;set;}
        public IEnumerable<string> Bonuses {get;set;} = new string[0];

        public WujasanatorSpinOutcome(int[,] tileMatrix, decimal reward, IEnumerable<string> bonuses)
        {
            TileMatrix = tileMatrix;
            Reward = reward;
            Bonuses = bonuses;
        }
    }
}