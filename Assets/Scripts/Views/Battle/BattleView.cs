using Framework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Views.Battle
{
    public class BattleView : ButtonView
    {
      
        public override void OnClick()
        {
            SceneManager.LoadSceneAsync("Start");
        }
    }
}