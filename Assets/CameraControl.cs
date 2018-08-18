using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    
	// Update is called once per frame
	void LateUpdate () {
        this.transform.eulerAngles = Vector3.zero;
	}
}
