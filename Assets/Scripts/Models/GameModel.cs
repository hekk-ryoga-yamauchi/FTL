using Contracts.Game;
using Contracts.Jump;
using Models.Game;
using Models.Jump;

namespace Models
{
    public class GameModel
    {
        public PlayerModel PlayerModel { get; private set; }
        public INodesModel NodesModel { get; private set; } 
        public IUnitsModel UnitsModel { get; private set; }

        public GameModel()
        {
            PlayerModel = new PlayerModel(0);
            NodesModel = new NodesModel(10);
            UnitsModel = new UnitsModel(3);
        }
    }
}