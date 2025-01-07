using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ButtonMenuScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //FIX
    //public void Volume()
    //{
    //    //Unity.vol
    //}
    public void Exit()
    {
            Application.Quit();
            Debug.Log("Game is Closing");
    }
}
