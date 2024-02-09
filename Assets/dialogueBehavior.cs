using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueBehavior : MonoBehaviour
{
    public dialogueTextBehavior text;
    private SpriteRenderer _sr;
    private float _timer ;

    private MeshRenderer _mr;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _mr = text.GetComponents<MeshRenderer>()[0];

        _sr = gameObject.GetComponent < SpriteRenderer > ();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.instance.Step==STEPS.PEPPER_TALK){
            _timer += Time.deltaTime;
            if(!_sr.enabled){
                Debug.Log("");
            _sr.enabled=!_sr.enabled;
            _mr.enabled=!_mr.enabled;
            }

            if(_timer>2){
            _sr.enabled=!_sr.enabled;
            _mr.enabled=!_mr.enabled;

            gameManager.instance.Step=STEPS.PEPPER_GETC;
            _timer=0;
            }



        }
        
    }
}
