using System.Collections.Generic;
using Models.Jump;
using Views.Jump;

namespace Contracts.Jump
{
    public interface INodesPresenter
    {
        void OnClicked(int id);
    }

    public interface INodesModel
    {
        Dictionary<int,NodeModel> GetNodes();
    }
}