using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float speedOfFirstThrow;
    
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public FrisbeeMoveScript frisbee;
    public Transform frisbeeInitialPlace;
    
    private int _leftPlayerScore = 0;
    private int _rightPlayerScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        leftScoreText.SetText(_leftPlayerScore.ToString());
        rightScoreText.SetText(_rightPlayerScore.ToString());
        StartCoroutine(StartNextPoint(false) );
    }

    public void FrisbeeTouchedRightGoal()
    {
        _leftPlayerScore += 1;
        leftScoreText.SetText(_leftPlayerScore.ToString());
        StartCoroutine(StartNextPoint(false) );
    }

    public void FrisbeeTouchedLeftGoal()
    {
        _rightPlayerScore += 1;
        rightScoreText.SetText(_rightPlayerScore.ToString());
        StartCoroutine(StartNextPoint(false) );
    }
    
    private IEnumerator StartNextPoint(bool throwToRight)
    {
        frisbee.CatchFrisbee(frisbeeInitialPlace);
        yield return StartCoroutine(frisbee.FadeIn());
        
        float x = throwToRight ? speedOfFirstThrow : (float)(speedOfFirstThrow * -1);
        frisbee.ThrowFrisbee(new Vector2(x, 0));
    }
    
}
