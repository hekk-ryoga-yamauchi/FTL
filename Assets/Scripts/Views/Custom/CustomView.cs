using Framework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views.Custom
{
    public class CustomView : ButtonView
    {
        
        public override void OnClick()
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}