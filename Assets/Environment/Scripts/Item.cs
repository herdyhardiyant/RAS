using UnityEngine;

namespace Environment.Scripts
{
    
    public class Item : MonoBehaviour,IEnvironmentInteractable
    {
        public string itemName = "Unrecognizable Object";
        // Start is called before the first frame update
        void Start()
        {
        
        }
        
        public void Interact()
        {
            print($"Interact with {itemName}");
        }

        public string GetInteractionText()
        {
            return $"This is a {itemName}";
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
