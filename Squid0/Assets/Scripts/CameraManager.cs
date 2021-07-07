using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if(cam.aspect<1.6f)
        {
            Debug.Log(cam.aspect);
            cam.orthographicSize = 14.5f;
        }else{
            cam.orthographicSize = 13;
        }
    }
}
