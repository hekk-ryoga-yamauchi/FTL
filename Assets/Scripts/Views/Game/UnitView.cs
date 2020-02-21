using Contracts.Game;
using Framework;
using MasterDatas;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Main
{
    public class UnitView : ViewBase
    {
        private int _id;
        private int _hp;
        private IUnitPresenter _presenter;

        private RoomTypeMasterData _currentRoom;

        [SerializeField]
        private Slider _hpSlider;


        public void Init(IUnitPresenter presenter)
        {
            _presenter = presenter;
            _id = presenter.GetId();
            _hp = presenter.GetHp();
            _hpSlider.maxValue = _hp;
            UpdateSlider();
        }

        public void Damage(int damage)
        {
            _hp = _presenter.Damage(damage);
            UpdateSlider();
        }

        private void UpdateSlider()
        {
            _hpSlider.value = _hp;
        }
    }
}