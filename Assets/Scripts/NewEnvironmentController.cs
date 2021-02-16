using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnvironmentController : MonoBehaviour
{
    [SerializeField] private GameObject[] environmentElement;
    [SerializeField] private Transform referencePoint;
    
    private void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }
    
    private IEnumerator CreateEnvironmentElement()
    {
        int randomRange = Random.Range(0, environmentElement.Length);
        
        Instantiate(environmentElement[randomRange], referencePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(7);
        StartCoroutine(CreateEnvironmentElement());
        
    }
}
