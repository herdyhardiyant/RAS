using UnityEngine;

namespace Environment.Scripts
{
    public class TheTree : MonoBehaviour, IEnvironmentInteractable
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void Interact()
        {
            print("The Great Tree");
        }
        public string GetInteractionText()
        {
            return $"This tree is protecting me.";
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
