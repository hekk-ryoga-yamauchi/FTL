namespace Contracts.Game
{
    public interface IUnitPresenter
    {
        int Damage(int damage);
        int GetId();
        int GetHp();
        void SetSelectUnit();
    }

    public interface IUnitModel
    {
        int Damage(int damage);
        int GetId();
        int GetHp();
    }
}