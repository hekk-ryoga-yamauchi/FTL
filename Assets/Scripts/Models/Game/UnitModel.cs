using Contracts.Game;
using MasterDatas;

namespace Models.Game
{
    public class UnitModel : IUnitModel
    {
        private int _id;
        private int _hp;
        private RoomTypeMasterData _currentRoom;
        private int _roomId;

        public UnitModel(int id, int hp, int roomId)
        {
            _id = id;
            _hp = hp;
            _roomId = roomId;
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

        public int GetRoomId()
        {
            return _roomId;
        }

        public void SetRoomId(int getId)
        {
            _roomId = getId;
        }
    }
}