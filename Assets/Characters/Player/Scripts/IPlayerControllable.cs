using UnityEngine;

namespace Characters.Player.Scripts
{
    public interface IPlayerControllable
    {
        public void SetEnable(bool isEnable);
        public void ToggleEnable();
    }
}
