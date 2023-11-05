using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            _frisbee = other.gameObject.GetComponent<FrisbeeMoveScript>();
            _frisbee.CatchFrisbee(_frisbeePos);
        }
    }

    public void ThrowFrisbee()
    {
        if (_frisbee is null) return;
        
        _frisbee.ThrowFrisbee(_target.position - transform.position);
        _frisbee = null;
    }

    internal bool HasFrisbee()
    {
        return _frisbee is not null;
    }
}