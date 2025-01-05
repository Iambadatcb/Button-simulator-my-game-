using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerKeybinds : MonoBehaviour
{
    public GameObject playercam;
    // Start is called before the first frame update
    private VariableDeclaration test;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var test = playercam.GetComponent<PlayerCam>();
            
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }
}
