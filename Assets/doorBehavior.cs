using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private float _timer ;
    private float targetRotationY = 90f; // Target rotation in degrees
    private float rotationSpeed = 9f; // Speed of rotation (degrees per second)
    private float currentRotationY = 0f; // Current rotation value
    void Start()
    {
        _timer = 0;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(gameManager.instance.Step == STEPS.OPEN_DOOR){
            _timer += Time.deltaTime;

            if(_timer>0.5){
                 // Calculate the new rotation value using Lerp
                currentRotationY = Mathf.Lerp(currentRotationY, targetRotationY, Time.deltaTime * rotationSpeed);

                // Apply the new rotation to the GameObject
                transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);

                // Check if the rotation has reached the target
                if (Mathf.Abs(currentRotationY - targetRotationY) < 0.01f)
                {
                    targetRotationY=0f;
                    gameManager.instance.Step=STEPS.PLAYER_LEAVE;
                    _timer=0;
                }
            }
        }
    
        if(gameManager.instance.Step==STEPS.CLOSE_DOOR){
            _timer += Time.deltaTime;

            if(_timer>1){
            currentRotationY = Mathf.Lerp(currentRotationY, targetRotationY, Time.deltaTime * rotationSpeed);

                // Apply the new rotation to the GameObject
                transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);

                // Check if the rotation has reached the target
                if (currentRotationY < 0.1f)
                {
                    gameManager.instance.Step=STEPS.CHOKBAR;
                }
            }

        }
    }
}
