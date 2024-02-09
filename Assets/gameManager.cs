using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum STEPS {
        CAM_SCROLL,
        OPEN_DOOR,
        PLAYER_LEAVE,
        CLOSE_DOOR,
        CHOKBAR,
        PEPPER_WALK,
        PEPPER_TALK,
        PEPPER_GETC,
        END
    };
public class gameManager: MonoBehaviour {
    public static gameManager instance;
    public doorBehavior door;
    public bool isWallGrab =false;
    public playerBehavior player;
    public mainCameraBehavior cinematiqueCam;
    public bool isWallGrabStop=false;
    public Vector3 direction;
    
    public STEPS Step;
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Start() {
        Step = STEPS.CAM_SCROLL;
    }

    // Update is called once per frame
    void Update() {
    

    }
}