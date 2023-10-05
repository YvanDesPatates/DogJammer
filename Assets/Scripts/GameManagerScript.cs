using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    
    private int _leftPlayerScore = 0;
    private int _rightPlayerScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        leftScoreText.SetText(_leftPlayerScore.ToString());
        rightScoreText.SetText(_rightPlayerScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FrisbeeTouchedRightGoal()
    {
        _leftPlayerScore += 1;
        leftScoreText.SetText(_leftPlayerScore.ToString());
    }

    public void FrisbeeTouchedLeftGoal()
    {
        _rightPlayerScore += 1;
        rightScoreText.SetText(_rightPlayerScore.ToString());
    }
    
    
    
}
