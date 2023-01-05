using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Transform _holdPosition;
    [SerializeField] private float _grabRange = 2f;
    [SerializeField] private float _throwForce = 20f;
    [SerializeField] private float _snapSpeed = 40f;

    private Rigidbody _grabbedObject;
    private bool _grabPressed = false;

    // Update is called once per frame
    void FixedUpdate()                                                                                                        //doesn't work in frames, Physics calculations have to be done in fixed time like real world time
    {                                                                                                                         //also update functions starts running after unity has done all physics calculations, we dont want that
        if (_grabbedObject)
        {
            _grabbedObject.velocity = (_holdPosition.position - _grabbedObject.transform.position) * _snapSpeed;              //rigidbody has velocity
            
        }
    }

    private void OnGrab()
    {
        if (_grabPressed)
        {
            _grabPressed = false;
            
            Debug.Log("Grab released");

            if (!_grabbedObject) return;

            DropGrabbedObject();
        }
        else
        {
            _grabPressed = true;
            
            Debug.Log("Grab pressed");

            if (Physics.Raycast(_cameraPosition.position, _cameraPosition.forward, out RaycastHit hit, _grabRange))  //if raycast meets something
            {
                if (!hit.transform.gameObject.CompareTag("Grabbable")) return;                                                   //if it's grabbable object

                _grabbedObject = hit.transform.GetComponent<Rigidbody>();                                                        //becomes our grabbed object rigidbody
                _grabbedObject.transform.parent = _holdPosition;

            }
        }
    }

    private void DropGrabbedObject()
    {
        _grabbedObject.transform.parent = null;
        _grabbedObject = null;
    }

    private void OnThrow()
    {
        if (!_grabbedObject) return;
        
        _grabbedObject.AddForce(_cameraPosition.forward * _throwForce, ForceMode.Impulse);                                        //Just add force before dropping it
        
        DropGrabbedObject();
    }
    
    
}
