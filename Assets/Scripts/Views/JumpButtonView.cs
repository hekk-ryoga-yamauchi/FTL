using System;
using Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class JumpButtonView : ButtonView
    {
        
        public  override void OnClick()
        {
            SceneManager.LoadSceneAsync("Jump");
        }
    }
}