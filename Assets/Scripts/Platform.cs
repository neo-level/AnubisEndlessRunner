using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float _platformBoundary = -20.0f;
    private float _speed = 4;
    
    // Update is called once per frame
    private void Update()
    {
        // transform.Translate(-1,0,0);
        transform.position += new Vector3(-_speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < _platformBoundary)
        {
            Destroy(gameObject);
        }
    }
}