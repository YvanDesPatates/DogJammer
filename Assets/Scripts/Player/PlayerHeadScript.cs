using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadScript : MonoBehaviour
{
    private FrisbeeMoveScript _frisbee;
    private Transform _target;
    private Transform _frisbeePos;

    // Start is called before the first frame update
    void Start()
    {
        _target = transform.GetChild(0);
        _frisbeePos = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && _frisbee is not null)
        {
            _frisbee.ThrowFrisbee(_target.position - transform.position);
            _frisbee = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            _frisbee = other.gameObject.GetComponent<FrisbeeMoveScript>();
            _frisbee.CatchFrisbee(_frisbeePos);
        }
    }
}