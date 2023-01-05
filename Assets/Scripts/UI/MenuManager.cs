using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _learnspanishObject;
    [SerializeField] private GameObject _categoryObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchtoCategory()
    {
        _learnspanishObject.SetActive(false);
        _categoryObject.SetActive(true);
    }

    public void SwitchOffCategory()
    {
        _categoryObject.SetActive(false);
    }
}
