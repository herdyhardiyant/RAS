using UnityEngine;

namespace Environment.Scripts
{
    public class Item : MonoBehaviour,IEnvironmentInteractable
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }
        
        public void Interact()
        {
            print("Interact with item");
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
