using System.Collections;
using System.Collections.Generic;
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

        [SerializeField]
        private Button _button;


        public void Init(IUnitPresenter presenter)
        {
            _presenter = presenter;
            _id = presenter.GetId();
            _hp = presenter.GetHp();
            _hpSlider.maxValue = _hp;
            UpdateSlider();
            _button.onClick.AddListener(presenter.SetSelectUnit);
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

        public void Move(List<RoomView> roomView)
        {
            StartCoroutine(PlayAnimation(roomView));
        }

        private IEnumerator PlayAnimation(List<RoomView> roomView)
        {
            foreach (var room in roomView)
            {
                var pos = gameObject.transform.position;
                for (int i = 0; i < 30; i++)
                {
                    yield return null;
                    var target = Vector3.Lerp(pos, room.transform.position, i);
                    gameObject.transform.position = target;
                }
            }
        }
    }
}