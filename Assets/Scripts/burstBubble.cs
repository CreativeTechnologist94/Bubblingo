using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class burstBubble : MonoBehaviour
{
    public UnityEvent _onBubbleBurst;
    [SerializeField] private GameEventManager _gameManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeshRenderer _bubbleRenderer;
    [SerializeField] private GameObject[] _phrases;
    public int _currentIndex = 0;
    private GameObject _activePhrase;
    
    public bool _istrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_phrases, "You have not assigned phrases "+ name);
    }

    private void OnEnable()
    {
        _bubbleRenderer.enabled = true;
        /*
        if (_currentIndex > 6)
        {
            _gameManager.methodIndex++;
        }
        */
        
        _activePhrase = _phrases[_currentIndex];
        _activePhrase.SetActive(true);

        _currentIndex++;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " , " + other.tag);
        if (!other.CompareTag("Finger")) return;
        _istrigger = true;
        _onBubbleBurst.Invoke(); //particle system
        _audioSource.Play();
        
        _activePhrase.SetActive(false);
        _bubbleRenderer.enabled = false;
        
        _gameManager.RightAnswer();
        Invoke (nameof(MoveToNext), 2);
    }

    private void MoveToNext()
    {
        _gameManager.NextQuestion();
    }
}
