using Contracts.Jump;

namespace Models
{
    public class JumpModel : IJumpModel
    {
        public PlayerModel PlayerModel { get; private set; }

        private JumpModel()
        {
            PlayerModel = new PlayerModel(1);
        }
    }
}