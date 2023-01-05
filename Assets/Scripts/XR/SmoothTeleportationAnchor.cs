using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace XR
{
    public class SmoothTeleportationAnchor : BaseTeleportationInteractable
    {
        [SerializeField] private float _teleportSpeed = 3f;
        [SerializeField] private float _stoppingDistance = 0.1f;
        
        private Vector3 _teleportEnd;
        private bool _isTeleporting;
        private XROrigin _rig;
        private XRCustomTeleportationProvider _customTeleportationProvider;

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            Debug.Log("On Select Entered");
            BeginTeleport(args.interactorObject);
        }

        private void BeginTeleport(IXRSelectInteractor interactor)
        {
            _rig = interactor.transform.GetComponentInParent<XROrigin>();
            _customTeleportationProvider = _rig.GetComponent<XRCustomTeleportationProvider>();
            
            if (_customTeleportationProvider.isTeleporting) return;
            _customTeleportationProvider.TeleportBegin();
            
            var interactorPos = interactor.transform.localPosition;
            interactorPos.y = 0;
            _teleportEnd = transform.position - interactorPos;
            _isTeleporting = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isTeleporting)
            {

                _rig.transform.position = Vector3.MoveTowards(_rig.transform.position, _teleportEnd, _teleportSpeed * Time.deltaTime);
                
                if (Vector3.Distance(_rig.transform.position, _teleportEnd) < _stoppingDistance)
                {
                    _isTeleporting = false;
                    _customTeleportationProvider.TeleportEnd();
                }
            }

        }
    }
}
