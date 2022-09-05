using UnityEngine;

namespace UI.Gameplay
{
    public interface IPlayerUIInteractable
    {
        public void ShowInteractionText(string interactText);
        public void HideInteractionText();
    }
}
