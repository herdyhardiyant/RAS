using UnityEngine;

namespace Interfaces
{
    public interface ICashier
    {
        void Sell(ISellable sellableObject, GameObject sellableGameObject);
    }
}