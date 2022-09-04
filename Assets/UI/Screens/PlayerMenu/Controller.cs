using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Screens.PlayerMenu
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour
    {
        
        private PlayerInput _playerInput;
        private VisualElement _playerMenuDocument;

        // Start is called before the first frame update
        void Start()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _playerMenuDocument = GetComponent<UIDocument>().rootVisualElement;
            _playerMenuDocument.visible = false;
        }
        
        
        // Update is called once per frame
        void Update()
        {
            if (_playerInput.IsInventoryPressed)
            {
                print("toggle inventory");
                _playerMenuDocument.visible = !_playerMenuDocument.visible;
            }
        }
    }
}
