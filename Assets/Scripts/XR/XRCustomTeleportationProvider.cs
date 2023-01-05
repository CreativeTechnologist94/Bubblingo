using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomTeleportationProvider : MonoBehaviour
{
    [SerializeField] private XRBaseInteractor _leftHandInteractor;
    [SerializeField] private XRBaseInteractor _rightHandInteractor;
    [SerializeField] private Animator _vignetteAniamtor;
    public bool isTeleporting;

    private Transform _leftHandCurrentSelection;
    private Transform _rightHandCurrentSelection;

    private void Start()
    {
        _leftHandInteractor.selectEntered.AddListener(LeftHandEnter);
        _leftHandInteractor.selectExited.AddListener(LeftHandExit);
        _rightHandInteractor.selectEntered.AddListener(RightHandEnter);
        _rightHandInteractor.selectExited.AddListener(RightHandExit);
    }
    private void RightHandEnter(SelectEnterEventArgs arg0)
    {
        _rightHandCurrentSelection = BindGrab(arg0.interactableObject);
    }
    private void RightHandExit(SelectExitEventArgs arg0)
    {
        _rightHandCurrentSelection = UnbindGrab(_rightHandCurrentSelection);
    }
    private void LeftHandEnter(SelectEnterEventArgs arg0)
    {
        _leftHandCurrentSelection = BindGrab(arg0.interactableObject);
    }
    private void LeftHandExit(SelectExitEventArgs arg0)
    {
        _leftHandCurrentSelection = UnbindGrab(_leftHandCurrentSelection);
    }

    private Transform BindGrab(IXRInteractable interactable)
    {
        if (interactable is XRGrabInteractable)
        {
            return interactable.transform;
        }

        return null;
    }

    private Transform UnbindGrab(Transform currentSelection)
    {
        currentSelection.parent = null;
        return null;
    }

    private void ParentInteractable( XRBaseInteractor interactor,Transform currentSelection)
    {
        if (currentSelection) currentSelection.parent = interactor.transform;
    }
    
    private void UnParentInteractable( XRBaseInteractor interactor,Transform currentSelection)
    {
        if (currentSelection) currentSelection.parent = null;
    }

    public void TeleportBegin()
    {
        isTeleporting = true;
        _vignetteAniamtor.SetBool("isTeleporting", isTeleporting);
        ParentInteractable(_rightHandInteractor, _rightHandCurrentSelection);
        ParentInteractable(_leftHandInteractor, _rightHandCurrentSelection);
    }
    
    public void TeleportEnd()
    {
        isTeleporting = false;
        _vignetteAniamtor.SetBool("isTeleporting", isTeleporting);
        UnParentInteractable(_rightHandInteractor, _rightHandCurrentSelection);
        UnParentInteractable(_leftHandInteractor, _rightHandCurrentSelection);
    }
}
