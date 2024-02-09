using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoBehavior : MonoBehaviour
{

    public Vector3 EndPosition;
    public playerBehavior Player; 
    private Vector3 _curPosition;
    public float AnimTime=2f;
public float Speed = 1f;
private float _distance;
    private SpriteRenderer _sr;
private bool _grow;
private float _timer;
private float _startwidth;
private bool _grabWall;
    private Vector3 _nextPosition;


    // Start is called before the first frame update
    void Start()
    {
        _curPosition = transform.position;
        _distance = Vector3.Distance(_curPosition,EndPosition);
        _timer=0;
        _grow=true;
        Player.IsLasso = true;
        _sr = GetComponent < SpriteRenderer > ();


    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer ==  LayerMask.NameToLayer("pepper")){
            _grow=false;
            var anim =  other.gameObject.GetComponent<Animator>();
            if(!anim.GetBool("dead")){
                anim.SetBool("dead",true);
                Destroy(gameObject);
            } else{
                gameManager.instance.isWallGrab=true;
            }
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("surface")){
            gameManager.instance.isWallGrab=true;
            _grow =false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_grow){
            // _timer += Time.deltaTime;
            gameManager.instance.direction = EndPosition - _curPosition  ;
            transform.rotation = Quaternion.FromToRotation(Vector3.right, gameManager.instance.direction);
            
            
            // float targetWidth = Mathf.Lerp(0,distance, _timer / AnimTime);
            // Set the new width
            Vector2 newScale = _sr.size;
            newScale.x += Speed * Time.deltaTime;
            _sr.size = newScale;    


            if( _sr.size.x >= _distance ){
                _grow=false;
                Destroy(gameObject);
            }
        }
        if(gameManager.instance.isWallGrabStop){
            gameManager.instance.isWallGrabStop=false;
            Destroy(gameObject);
        }
    }
}
