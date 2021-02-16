using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraVelocity;

    [SerializeField] private float smoothValue = 0.5f;
    [SerializeField] private sbyte lowerLimit = -2;

    [SerializeField] private bool lookAtPlayer;

    private void Update()
    {
        if (player.position.y >= lowerLimit)
        {

            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
        
            // Smoothens the camera following speed.
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothValue);
         
            if (lookAtPlayer)
            {
                // Tell the camera to look at the player.
                transform.LookAt(player);
            } 
        }

    }
}