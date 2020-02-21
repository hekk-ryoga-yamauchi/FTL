using Contracts.Game;
using MasterDatas;

namespace Models.Game
{
    public class UnitModel : IUnitModel
    {
        private int _id;
        private int _hp;
        private RoomTypeMasterData _currentRoom;

        public UnitModel(int id, int hp)
        {
            _id = id;
            _hp = hp;
        }

        public int Damage(int damage)
        {
            return _hp -= damage;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetHp()
        {
            return _hp;
        }
    }
}