using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBlank : MonoBehaviour
{
    [SerializeField] private GameObject _rightBubble;
    [SerializeField] private AudioSource _correctSoundSource;
    [SerializeField] private AudioSource _wrongSoundSource;
    [SerializeField] private bool _isLastpart;
    [SerializeField] private FillBlanksManager _fillmanager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bubbles")) return;
        
        if (other.gameObject == _rightBubble)
        {
            _correctSoundSource.Play();
            other.gameObject.SetActive(false);
            var child = gameObject.transform.GetChild(0);
            child.gameObject.SetActive(true);

            if (_isLastpart == true)
            {
                _fillmanager.PhraseComplete();
            }
        }
        else
        {
            _wrongSoundSource.Play();
        }
    }
}
