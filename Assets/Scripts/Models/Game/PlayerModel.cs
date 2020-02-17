namespace Models.Game
{
    public class PlayerModel
    {
        public int CurrentId { get; private set; }

        public PlayerModel(int currentId)
        {
            CurrentId = currentId;
        }

        public void SetCurrentId(int currentId)
        {
            CurrentId = currentId;
        }
    }
    
}