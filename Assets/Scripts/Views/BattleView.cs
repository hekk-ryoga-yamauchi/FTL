using Framework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class BattleView : ButtonView
    {
      
        public override void OnClick()
        {
            SceneManager.LoadSceneAsync("Start");
        }
    }
}