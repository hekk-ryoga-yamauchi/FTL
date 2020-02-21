namespace Contracts.Game
{
    public interface IUnitPresenter
    {
        int Damage(int damage);
        int GetId();
        int GetHp();
    }

    public interface IUnitModel
    {
        int Damage(int damage);
        int GetId();
        int GetHp();
    }
}