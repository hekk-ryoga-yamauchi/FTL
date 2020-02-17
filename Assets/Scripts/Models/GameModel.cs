using Contracts.Jump;
using Models.Game;

namespace Models
{
    public class GameModel
    {
        public PlayerModel PlayerModel { get; private set; }

        public GameModel()
        {
            PlayerModel = new PlayerModel(0);
        }
    }
}