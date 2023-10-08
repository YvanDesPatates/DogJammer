using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public PlayerFacadeScript player1;
    public PlayerFacadeScript player2;

    private ICommand _spaceCommand;
    private ICommand _cCommand;
    void Start()
    {
        _spaceCommand = new DashCommand();
        _cCommand = new ThrowFrisbeeCommand();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spaceCommand.Execute(player1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _cCommand.Execute(player1);
        }
    }
}
