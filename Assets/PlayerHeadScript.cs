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
            _frisbee.SetVelocity(_target.position - transform.position);
            _frisbee = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _frisbee = collision.gameObject.GetComponent<FrisbeeMoveScript>();
            _frisbee.SetTargetPos(_frisbeePos);
        }
    }
}