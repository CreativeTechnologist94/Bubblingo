using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] private GameObject _failedPanel;
    [SerializeField] private GameObject _successPanel;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _wrongSound;
    [SerializeField] private AudioClip _rightSound;
    [SerializeField] private GameObject[] _methods;

    public int methodIndex = 0; 
    private GameObject _currentMethod;                                    //keeps changing acc to Logic for all game - select random phrase - stages for phrase 1-2-3-4
                        
    // Start is called before the first frame update
    void Start()
    {
        _failedPanel.SetActive(false);
        _successPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _currentMethod = _methods[methodIndex];                            //switches index!!
    }
    public void RightAnswer()                                             //logic for right answer will be in element/method
    {
        _successPanel.SetActive(true);
        _audioSource.clip = _rightSound;
        _audioSource.Play();
    }

    public void WrongAnswer()
    {
        _failedPanel.SetActive(true);
        _audioSource.clip = _wrongSound;
        _audioSource.Play();
    }

    public void NextQuestion()
    {
        _successPanel.SetActive(false);
        _failedPanel.SetActive(false);

        /*
        foreach (var t in _methods)
        {
            t.SetActive(false);
        }
        _currentMethod.SetActive(true);
        */
    }
}
