using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodController : MonoBehaviour
{
    public int phraseIndexx = 0;
    [SerializeField] private GameEventManager _gameManager;
    [SerializeField] private GameObject[] _phrases;
    private GameObject _activePhrase;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (phraseIndexx == 5) _gameManager.methodIndex++;
        
        _activePhrase = _phrases[phraseIndexx];
        _activePhrase.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
