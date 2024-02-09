using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepperBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    private float _timer ;
    public float Range=1;
    public float speed = 8;
    public alerteBehavior alerte;
    private Animator _anim;

    void Start()
    {
        _rb = GetComponent < Rigidbody2D > ();
        _timer = 0;
        _anim = GetComponent<Animator>();
        
    }
    void dies(){
        GetComponent<Animator>().enabled = false;


    }
    // Update is called once per frame
    void Update()
    {

        if(gameManager.instance.Step==STEPS.PEPPER_WALK){
            _timer += Time.deltaTime;
            if(_timer<Range){
                _anim.SetBool("isrunning",true);
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            }else{
                _anim.SetBool("isrunning",false);
                gameManager.instance.Step=STEPS.PEPPER_TALK;
            }
        }
    }
}
