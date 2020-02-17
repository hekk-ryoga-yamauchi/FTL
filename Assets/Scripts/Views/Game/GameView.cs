using Contracts.Jump;
using Framework;
using Models;
using UnityEngine;
using Zenject;

namespace Views.Main
{
    public class GameView : ViewBase
    {
        [Inject]
        private void Construct(GameModel model)
        {
            Debug.Log(model);
        }
    }
}