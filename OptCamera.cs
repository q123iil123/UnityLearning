using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void setThisPosition(Vector3 moveSpace)
    {
        this.transform.Translate(moveSpace);
    }

}
