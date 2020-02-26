namespace Contracts.Game
{
    public interface IUnitPresenter
    {
        int Damage(int damage);
        int GetId();
        int GetHp();
        void SetSelectUnit();
        int GetUnitRoomId();
    }

    public interface IUnitModel
    {
        int Damage(int damage);
        int GetId();
        int GetHp();
        int GetRoomId();
        void SetRoomId(int getId);
    }
}