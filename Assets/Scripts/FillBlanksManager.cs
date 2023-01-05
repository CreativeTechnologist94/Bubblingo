using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBlanksManager : MonoBehaviour
{
    [SerializeField] private AudioSource _phraseSound;
    [SerializeField] private GameEventManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PhraseComplete()
    {
        _phraseSound.Play(1);
        _gameManager.RightAnswer(); //plays icon and sound
        gameObject.SetActive(false);
        //Invoke(nameof(MoveToNext), 3);
    }
    
    private void MoveToNext()
    {
        _gameManager.NextQuestion();
    }
}
