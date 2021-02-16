using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private float speed;

    private SpriteRenderer _background;

    private float _offset;

    // Start is called before the first frame update
    private void Start()
    {
        _background = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _offset += speed * Time.deltaTime;

        _background.material.mainTextureOffset = new Vector2(_offset, 0);
    }
}