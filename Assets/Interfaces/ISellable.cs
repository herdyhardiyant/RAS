using UnityEngine;

namespace Interfaces
{
    public interface ISellable
    {
        string Name { get; }
        int Price { get; }
        Sprite Icon { get; }
        Sprite TrashIcon { get; }
        Sprite MaterialIcon { get; }
    }
}