using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hands
{
    public class XRTeleportManager : MonoBehaviour
    {
        [SerializeField] private XRBaseInteractor _teleportController;
        [SerializeField] private XRBaseInteractor _mainController;
        [SerializeField] private Animator _handAnimator;
        [SerializeField] private GameObject _pointer;

        private void Start()
        {
            _teleportController.selectEntered.AddListener(MoveselectiontoMainController);
        }

        private void MoveselectiontoMainController(SelectEnterEventArgs arg0)
        {
            var interactable = arg0.interactableObject;
            if (interactable is BaseTeleportationInteractable) return;
            
            if (interactable!= null ) _teleportController.interactionManager.SelectEnter(_mainController, interactable);  //Force select deprecated
                
        }

        // Update is called once per frame
        void Update()
        {
            _pointer.SetActive(_handAnimator.GetCurrentAnimatorStateInfo(0).IsName("Point") && _handAnimator.gameObject.activeSelf);
        }
    }
}
