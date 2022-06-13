namespace wujasanator.Services
{
    ///<see cref="IWujasanatorService">
    public class WujasanatorService : IWujasanatorService
    {
        int[] possibleRolls = Enumerable.Range(0, 8).ToArray();

        ///<see cref="IWujasanatorService.GetSpinOutcome(decimal)">
        public WujasanatorSpinOutcome GetSpinOutcome(decimal cost)
        {
            int[,] tileMatrix = new int[5,3];
                
            for(int i = 0; i < tileMatrix.GetLength(0); i++) // iterate columns
            {
                for(int j = 0; j < tileMatrix.GetLength(1); j++) // iterate rows
                    tileMatrix[i,j] = possibleRolls[Random.Shared.Next(possibleRolls.Count())]; 
            }

            // TODO: bonus/wild logic here

            decimal reward = cost; // TODO: reward logic here - calculate reward according to drawn tiles, bonuses and cost parameter

            return new WujasanatorSpinOutcome
                (
                    tileMatrix,
                    reward,
                    new string[0]
                    // TODO: send info about bonuses to display animations
                );
        }
    }
}
