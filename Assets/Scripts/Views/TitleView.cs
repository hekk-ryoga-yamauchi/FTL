using Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class TitleView : ButtonView
    {
        public override void OnClick()
        {
             SceneManager.LoadSceneAsync("Custom");
        }
    }
}