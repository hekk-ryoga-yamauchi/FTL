using System.Collections.Generic;
using Models.Game;
using Views.Main;

namespace Contracts.Game
{
    public interface IUnitsModel
    {
        List<UnitModel> GetUnitModels();
    }

    public interface IUnitsPresenter
    {
        int GetUnitRoomId(int id);
        void MoveUnit(List<RoomView> roomView);
    }
}