using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
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
        StartNextPoint(false);
    }

    public void FrisbeeTouchedRightGoal()
    {
        _leftPlayerScore += 1;
        leftScoreText.SetText(_leftPlayerScore.ToString());
        StartNextPoint(true);
    }

    public void FrisbeeTouchedLeftGoal()
    {
        _rightPlayerScore += 1;
        rightScoreText.SetText(_rightPlayerScore.ToString());
        StartNextPoint(false);
    }
    
    private void StartNextPoint(bool throwToRight)
    {
        frisbee.SetPosition(frisbeeInitialPlace.position);
        
        int x = throwToRight ? 1 : -1;
        frisbee.ThrowFrisbee(new Vector2(x, 0));
    }
    
}
