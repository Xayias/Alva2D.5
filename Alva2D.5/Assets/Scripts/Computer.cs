using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] Camera gameCam;
    [SerializeField] Camera hackingCam;

    // Start is called before the first frame update
    void Start()
    {
        gameCam.enabled = true;
        hackingCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameCam.enabled = !gameCam;
            hackingCam.enabled = !hackingCam.enabled;
        }
    }
}
