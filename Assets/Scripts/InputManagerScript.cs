using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public PlayerFacadeScript player1;
    public PlayerFacadeScript player2;

    private ICommand _spaceCommand;
    void Start()
    {
        _spaceCommand = new DashCommand();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spaceCommand.Execute(player1);
        }
    }
}
