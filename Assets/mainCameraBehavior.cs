using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraBehavior : MonoBehaviour
{

    public float Distance;
    public float AnimTime;
    private float _timer ;
    // Start is called before the first frame update
private Vector3 _nextPosition;
private Vector3 _curPosition;

    void Start()
    {
        _curPosition = transform.position;
        _nextPosition = transform.position + new Vector3(Distance,0f);
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.instance.Step == STEPS.CAM_SCROLL){

        _timer += Time.deltaTime;
        transform.position = Vector3.Lerp(_curPosition,_nextPosition  , _timer / AnimTime);
            if(_timer > AnimTime){    
                gameManager.instance.Step = STEPS.OPEN_DOOR;
            }
        }
        if(gameManager.instance.Step == STEPS.END   ){
            GetComponent<Camera>().enabled = false;
            gameManager.instance.player.playerCamera.GetComponent<Camera>().enabled = true;
        }
    }
}
