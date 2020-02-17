using Framework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views
{
    public class CustomView : ButtonView
    {
        
        public override void OnClick()
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}