using Framework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views.Main
{
    public class CustomView : ButtonView
    {
        
        public override void OnClick()
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}