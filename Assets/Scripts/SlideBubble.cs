using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlideBubble : MonoBehaviour
{
    public UnityEvent _onBubbleMeet;
    //[SerializeField] private LevelController _lvlController;
    [SerializeField] private AudioSource _bubblePopSource;
    [SerializeField] private AudioSource _voiceSource;
    [SerializeField] private GameObject _rightObject;
    [SerializeField] private GameObject _wrongObject;
    [SerializeField] private GameEventManager _gameManager;
    
    // Start is called before the first frame update
    private void Start()
    {
        _voiceSource.Play();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == _rightObject)
        {
            _rightObject.SetActive(false);
            _wrongObject.SetActive(false);
            
            Transform firstChild = gameObject.transform.GetChild(0);
            Transform secondChild = gameObject.transform.GetChild(1);
            firstChild.gameObject.SetActive(false);
            secondChild.gameObject.SetActive(false);
            
            _onBubbleMeet.Invoke();
            _gameManager.RightAnswer();
        }
        else if(other.gameObject == _wrongObject)
        {
            _rightObject.SetActive(false);
            _wrongObject.SetActive(false);
            Transform firstChild = gameObject.transform.GetChild(0);
            Transform secondChild = gameObject.transform.GetChild(1);
           
            firstChild.gameObject.SetActive(false);
            secondChild.gameObject.SetActive(false);
            
            _onBubbleMeet.Invoke();
            _gameManager.WrongAnswer();
        }

        Invoke(nameof(MoveToNext), 3);
    }
    
    private void MoveToNext()
    {
        _gameManager.NextQuestion();
    }
}
