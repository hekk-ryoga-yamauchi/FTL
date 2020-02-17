using System;
using Framework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Main
{
    public class DoorView : ButtonView
    {
        public  override void OnClick()
        {
           Debug.Log("ドアが押されたよ");
        }
    }
}