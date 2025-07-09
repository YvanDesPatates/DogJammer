using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeMoveScript : MonoBehaviour
{
    public float speed = 10;
    public float torqueRotation = 50;
    public float fadeInInverseSpeed;
    public float fadeOutInverseSpeed;
    
    private Rigidbody2D _rigidBody;
    private Transform _targetPos;
    private Material _fadeMaterial;
    
    private static readonly int FadeReference = Shader.PropertyToID("_Fade");


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _fadeMaterial = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPos != null) transform.position = _targetPos.position;
    }

    public void ThrowFrisbee(Vector2 velocity)
    {
        _rigidBody.freezeRotation = false;
        _rigidBody.totalTorque = torqueRotation;
        _targetPos = null;
        _rigidBody.velocity = velocity * speed;
    }

    public void CatchFrisbee(Transform targetPos)
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.freezeRotation = true;
        _targetPos = targetPos;
    }

    public IEnumerator FadeIn()
    {
        float fade = _fadeMaterial.GetFloat(FadeReference);
        while (fade < 1)
        {
            _fadeMaterial.SetFloat(FadeReference, fade);
            fade += 0.1f;
            yield return new WaitForSeconds(fadeInInverseSpeed/100);
        }
    }
    public IEnumerator FadeOut()
    {
        float fade = _fadeMaterial.GetFloat(FadeReference);
        while (fade > 0)
        {
            _fadeMaterial.SetFloat(FadeReference, fade);
            fade -= 0.1f;
            yield return new WaitForSeconds(fadeOutInverseSpeed/100);
        }
    }
    public void Stop()
    {
        CatchFrisbee(transform);
    }


}
