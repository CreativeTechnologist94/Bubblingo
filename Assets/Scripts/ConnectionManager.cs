using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    public int currentBubbleIndex = 0;
    public GameEventManager _gameManager;

    private void Start()
    {
        _line.positionCount = 0;
    }
    public bool CheckSelection(int indexNo, Vector3 bubblePos)
    {
        var correctAnswer = false;

        if (indexNo == currentBubbleIndex)
        {
            correctAnswer = true;
            _line.positionCount++;
            _line.SetPosition(currentBubbleIndex, bubblePos);
            currentBubbleIndex++;
        }
        return correctAnswer;
    }
    
}
