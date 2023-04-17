using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraScaling : MonoBehaviour {

    public int targetWidth = 1920;
    public float pixelsPreUnit = 100f;
    public Camera Mcamera;
	
	// Update is called once per frame
	void Update () {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
        Mcamera.orthographicSize = height / pixelsPreUnit / 2;
	}
}
