using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score;

    public void updateScore(int scoreValue)
    {
        _score += scoreValue;
    }
}
