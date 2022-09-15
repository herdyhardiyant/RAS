
namespace RAS.Environment.Scripts
{
    
    public interface IEnvironmentInteractable
    {
        
        /// <summary>
        /// Player action after pressing the interact action
        /// </summary>
        void Interact();
        
        /// <summary>
        /// Get Player speech text about the object
        /// </summary>
        string GetInteractionText();

    }
}
