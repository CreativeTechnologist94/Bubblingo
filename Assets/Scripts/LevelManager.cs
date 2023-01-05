using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // This is not the final game logic for levels 
    
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private AudioSource _MenuBgmSource;
    [SerializeField] private AudioSource _GameBgmSource;
    private void CloseAllLevels()
    {
        foreach (var lvl in _levels)
        {
           lvl.SetActive(false);
        }
       
    }

    public void OpenLanguageSelection()
    {
        CloseAllLevels();
        _levels[1].SetActive(true);
    }
    
    public void OpenTopicSelection()
    {
        if (!_MenuBgmSource.isPlaying)
        {
            _GameBgmSource.Stop();
            _MenuBgmSource.Play();
        }
        CloseAllLevels();
        _levels[2].SetActive(true);
    }

    public void OpenGame()
    {
        _MenuBgmSource.Stop();
        //_GameBgmSource.Play();
        CloseAllLevels();
        _levels[3].SetActive(true);
    }
    
    public void OpenReport()
    {
        CloseAllLevels();
        _levels[4].SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }
    
}
