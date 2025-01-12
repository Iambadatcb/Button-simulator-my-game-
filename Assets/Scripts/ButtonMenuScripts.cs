using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SearchService;
using UnityEngine;

public class ButtonMenuScripts : MonoBehaviour
{
    [Header("Day/Night")]
    public TextMeshProUGUI text;
    public GameObject sun;

    [Header("Stats")]
    public GameObject cash;
    public PlayerStatGain fun;
    
    // Start is called before the first frame update
    void Start()
    {
        fun = cash.GetComponent<PlayerStatGain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DayNight()
    {
        if(text.text == "Day")
        {
            sun.transform.eulerAngles = new Vector3(-50,sun.transform.eulerAngles.y,sun.transform.eulerAngles.z);
            text.text = "Night";
        }
        else if(text.text == "Night")
        {
            sun.transform.eulerAngles = new Vector3(50,sun.transform.eulerAngles.y,sun.transform.eulerAngles.z);
            text.text = "Day";
        }
    }
    //FIX
    //public void Volume()
    //{
    //    //Unity.vol
    //}
    public void Exit()
    {
            Save();
            Application.Quit();
            Debug.Log("Game is Closing");
    }
    private void Save(){
         PlayerPrefs.SetFloat("multi", fun.cash);
         PlayerPrefs.SetFloat("cash", fun.multi);
         PlayerPrefs.Save();
    }
}
