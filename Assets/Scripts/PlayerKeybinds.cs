using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerKeybinds : MonoBehaviour
{
    public GameObject playercam;
    public GameObject settings;
    public GameObject canvas;
    public GameObject player;
    public GameObject button;
    
    public GameObject playerMovement;
    
    private bool Menu = false;
    // Start is called before the first frame update
    
    void Start()
    {
        
        settings.SetActive(false);
        canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& Menu==false)
        {
            var test = playercam.GetComponent<PlayerCam>();
            test.enabled = false;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            var movement = playerMovement.GetComponent<PlayerMovement>();
            movement.enabled = false;
            settings.SetActive(true);
            canvas.SetActive(true);
            playercam.transform.position = new Vector3(settings.transform.position.x,settings.transform.position.y,settings.transform.position.z-1);
            playercam.transform.rotation = settings.transform.rotation;
            
            Menu = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape)&& Menu == true)
        {
            var test = playercam.GetComponent<PlayerCam>();
            test.enabled = true;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            settings.SetActive(false);
            canvas.SetActive(false);
            playercam.transform.position = player.transform.position;
            playercam.transform.rotation = player.transform.rotation;
            var movement = playerMovement.GetComponent<PlayerMovement>();
            movement.enabled = true;
            
            Menu = false;
        }
    }
}
