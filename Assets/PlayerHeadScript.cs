using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadScript : MonoBehaviour
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            FrisbeeMoveScript frisbee = collision.gameObject.GetComponent<FrisbeeMoveScript>();
            frisbee.SetVelocity(target.position - transform.position);
        }
    }
}
