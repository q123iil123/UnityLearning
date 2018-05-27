using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptPlayer : MonoBehaviour {
    public Animation player;
    private float speed = 10;
    private Vector3 dict;
    private int moveFlag = 0;
    public OptCamera _optcamera;
    private float dianX;
    public GameObject playerTarget;
	// Use this for initialization
	void Start () {
        player.wrapMode = WrapMode.Loop;
        player.CrossFade("stand");
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            dianX = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0))
        {
            float dx = Input.mousePosition.x - dianX;
            Vector3 v = this.transform.localEulerAngles;
            v.y = dx/3;
            this.transform.localEulerAngles = v;
            playerTarget.transform.localEulerAngles = v;
        }
        playerMove(); 

	}
    void playerMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.CrossFade("run");
            dict = Vector3.forward;
            moveFlag = 1;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            player.CrossFade("stand");
            moveFlag = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.CrossFade("run");
            dict = Vector3.back;
            moveFlag = 1;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            player.CrossFade("stand");
            moveFlag = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.CrossFade("run");
            dict = Vector3.left;
            moveFlag = 1;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            player.CrossFade("stand");
            moveFlag = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.CrossFade("run");
            dict = Vector3.right;
            moveFlag = 1;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            player.CrossFade("stand");
            moveFlag = 0;
        }


        if (moveFlag == 1)
        {
            Vector3 moveDict = dict * Time.deltaTime * speed;
            this.transform.Translate(moveDict);
            //_optcamera.setThisPosition(moveDict);
            playerTarget.transform.position = this.transform.position;
        }
    }
}
