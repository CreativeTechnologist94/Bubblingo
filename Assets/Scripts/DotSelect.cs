using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSelect : MonoBehaviour
{
    [SerializeField] private ConnectionManager _connectionManager;
    [SerializeField] private Material _assignMaterial;
    [SerializeField] private MeshRenderer _meshMeshRenderer;
    [SerializeField] private AudioSource _correctSoundSource;
    [SerializeField] private AudioSource _wrongSoundSource;
    [SerializeField] private AudioSource _phraseSound;
    [SerializeField] private bool _isLast;

    public int _index;
    private bool _correctSelection = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Finger")) return;
        
        _correctSelection = _connectionManager.CheckSelection(_index, transform.position);

        if (_correctSelection)
        {
            _correctSoundSource.Play();
            _meshMeshRenderer.material = _assignMaterial;
        }
        else
        {
            _wrongSoundSource.Play();
        }
        
        if (_isLast == true)
        {
            _phraseSound.Play();
            Invoke(nameof(PhraseComplete), 1);
        }
    }
    
    private void PhraseComplete()
    {
        _connectionManager._gameManager.RightAnswer(); //plays icon and sound
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
