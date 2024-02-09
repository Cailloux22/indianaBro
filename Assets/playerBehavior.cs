using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{

    public rightArmBehavior rightArm;
    public leftArmBehavior leftArm;
    public playerCamera playerCamera;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private SpriteRenderer _srl;
    private SpriteRenderer _srr;
    private Animator _anim;
    public bool IsLasso = false;
    public LassoBehavior lassoPrefab;
    public Transform lassoSpawn;
    public PointBehaviorCine cinematiquePoint; 

    private
    // public List<type> list; 
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent < Rigidbody2D > ();
        _sr = GetComponent < SpriteRenderer > ();
        _srr = rightArm.GetComponent < SpriteRenderer > ();
        _srl = leftArm.GetComponent < SpriteRenderer > ();
        // gravityScale
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.instance.Step == STEPS.PLAYER_LEAVE){

            if(_rb.gravityScale==0){

                _rb.gravityScale=1;
                _sr.sortingLayerID = SortingLayer.NameToID("player");
                _srr.sortingLayerID = SortingLayer.NameToID("player");
                _srl.sortingLayerID = SortingLayer.NameToID("player");
                
            }else{
                gameManager.instance.Step = STEPS.CLOSE_DOOR;
            }
        }
        if(gameManager.instance.Step == STEPS.PEPPER_GETC){

            Attak(cinematiquePoint.transform.position);
        }
        if(gameManager.instance.Step == STEPS.END){
            if(Input.GetMouseButtonDown(0)){
                Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                click.z = 0 ;
                Attak(click);
            }
            if(Input.GetMouseButtonUp(0)){
                gameManager.instance.isWallGrabStop=true;
                gameManager.instance.isWallGrab=false;
            }
            if(gameManager.instance.isWallGrab){
                _rb.AddForce(gameManager.instance.direction * 60);
            }
        }
    }

    void Attak(Vector3 click){
        if(_srr.enabled){
                _srr.enabled=!_srr.enabled;
                _srl.enabled=!_srl.enabled;
                
            }
            if(!_anim.GetBool("attaking")){
                Debug.Log("attak");
        

                StartCoroutine(AttendreFinAnimation(click));
                
            }
    }
    private IEnumerator AttendreFinAnimation(Vector3 click)
    {
        _anim.SetBool("attaking",true);
    yield return new WaitForEndOfFrame();


        Debug.Log(_anim.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("stop");
        _anim.SetBool("attaking",false);
        _srr.enabled=!_srr.enabled;
        _srl.enabled=!_srl.enabled;
        var lasso = Instantiate(lassoPrefab, lassoSpawn.position, lassoSpawn.rotation);
                lasso.Player = this;
                lasso.EndPosition = click;
        gameManager.instance.Step = STEPS.END;

       // L'animation est terminée, exécutez votre autre action ici

    }
}
