using System;
using Framework;
using MasterDatas;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class RoomView : ButtonView
    {

        [SerializeField]
        private RoomTypeMasterData _roomType;

        public  override void OnClick()
        {
            Debug.Log(_roomType.ToString() + "がおされたよ");
        }
    }
}