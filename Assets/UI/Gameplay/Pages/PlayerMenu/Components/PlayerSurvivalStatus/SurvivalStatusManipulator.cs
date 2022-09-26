using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.PlayerSurvivalStatus
{
    public class SurvivalStatusManipulator : MonoBehaviour
    {
        private VisualElement _statusElementRoot;
        [SerializeField] private VisualTreeAsset _survivalStatusTreeAsset;

        public VisualElement SurvivalStatusVisualElement => _statusElementRoot;
        
        void Awake()
        {
            _statusElementRoot = _survivalStatusTreeAsset.CloneTree();

        }
        
      
    }
}
