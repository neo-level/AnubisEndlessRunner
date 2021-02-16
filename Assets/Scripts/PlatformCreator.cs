using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private GameObject lastCreatedPlatform;
    [SerializeField] private GameObject[] platformPrefab;

    [SerializeField] private Transform referencePoint;

    [SerializeField] private float spaceBetweenPlatforms = 2.0f;

    private float _endBoundX= -5.0f;
    private float _spawnPointX= 10.0f;

    private void Start()
    {
        CreateRandomPlatform();
    }

    private void Update()
    {
        if (lastCreatedPlatform.transform.position.x < _endBoundX)
        {

            CreateRandomPlatform();
        }
    }
    
    private void CreateRandomPlatform()
    {
        Vector3 targetCreationPoint =
            new Vector3(_spawnPointX  + spaceBetweenPlatforms,
                0, 0);

        int randomPlatform = Random.Range(0, platformPrefab.Length);
        lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);
    }
}