using System.Collections.Generic;
using Contracts.Game;

namespace Models.Game
{
    public class UnitsModel : IUnitsModel
    {
        public List<UnitModel> _units = new List<UnitModel>();

        public UnitsModel(int count)
        {
            var unit = new UnitModel(0,100);
            _units.Add(unit);
            unit = new UnitModel(1,100);
            _units.Add(unit);
            unit = new UnitModel(2,100);
            _units.Add(unit);
        }

        public List<UnitModel> GetUnitModels()
        {
            return _units;
        }
    }
}