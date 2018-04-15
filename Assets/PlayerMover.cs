using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMover : MonoBehaviour {
    public GameObject sphere;

    void Start () {
	}

	void Update () {
        sphere.transform.Translate(CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 2, 0.0f, CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 2);	
    }
}
