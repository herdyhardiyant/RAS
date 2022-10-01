using Environment.Interfaces;
using UnityEngine;


namespace Environment.Scripts
{
    /// <summary>
    /// World object that can be interacted with
    /// </summary>
    public class Object : MonoBehaviour, IInteractable
    {
        public string itemName = "Unrecognizable Object";
        private const string TAG_NAME = "Interactable";

        private void Awake()
        {
            tag = TAG_NAME;
        }

        public void Interact()
        {
            print("Interact Object");
        }

        public string GetInteractionText()
        {
            return $"This is a {itemName}";
        }

        public Vector3 Position => transform.position;
    }
}