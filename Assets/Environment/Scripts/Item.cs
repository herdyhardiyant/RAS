using UnityEngine;

namespace Environment.Scripts
{
    public class Item : MonoBehaviour
    {
        private const string TAG_NAME = "Pickupable";
        void Awake()
        {
            tag = TAG_NAME;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
