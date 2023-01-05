using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomControllerInteractor : MonoBehaviour
{
    private XRBaseControllerInteractor _controller; //both LHC AND RHC have XRRayInteractor/ XRDirectInteractor that both have inherited from XRBaseControllerInteractor
    private void Start()
    {
        _controller = GetComponent<XRBaseControllerInteractor>();
        Assert.IsNotNull(_controller, "There is no XRBaseControllerInteractor assigned to this hand " + gameObject.name);   //we are making sure it is not null
        
        _controller.selectEntered.AddListener(ParentInteractable);
        _controller.selectExited.AddListener(Unparent);
    }

    private void ParentInteractable(SelectEnterEventArgs arg0)
    {
        arg0.interactableObject.transform.parent = transform;
    }
    
    private void Unparent(SelectExitEventArgs arg0)
    {
        arg0.interactableObject.transform.parent = null;
    }

}
