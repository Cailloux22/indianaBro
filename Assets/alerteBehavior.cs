using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alerteBehavior : MonoBehaviour
{
    private SpriteRenderer _sr;
    private float _timer ;


    // Start is called before the first frame update
    void Start()
    {
        _sr = gameObject.GetComponent < SpriteRenderer > ();
        _timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.instance.Step==STEPS.CHOKBAR){
            _timer += Time.deltaTime;
            if(!_sr.enabled){
            _sr.enabled=!_sr.enabled;
            }

            if(_timer>1){
            _sr.enabled=!_sr.enabled;
            gameManager.instance.Step=STEPS.PEPPER_WALK;
            _timer=0;
            }
        }
    }
}
