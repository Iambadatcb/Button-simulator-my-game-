using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatGain : MonoBehaviour
{
    [Header("Stats")]
     public float cash = 0;
     public float multi = 1;
    public float reb = 0;
    private Button buttonmulti;
     private TextMesh cost;
     private TextMesh prize;
     public TextMeshProUGUI ammount;
     public TextMeshProUGUI multiAmmount;
     [Header("Shooting myself in the head")]
     public new GameObject gameObject;
    public LayerMask multiButton;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI prizeText;
    //  private Collider collision;
    // Start is called before the first frame update
    void Start()
    {
        buttonmulti = GetComponent<Button>();
        Debug.Log("turns on");
        gameObject.GetComponent<GameObject>();
        cash = PlayerPrefs.GetFloat("cash", 0);
        multi = PlayerPrefs.GetFloat("multi",1);
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        var Addition = collision.gameObject.GetComponent<Button>();
        
        if(collision.gameObject.CompareTag("MultiButton1")){
            Debug.Log("Collided with button");


            if (cash >= Convert.ToInt32(Addition.cash.text))
            {   
                cash = cash - Convert.ToInt32(Addition.cash.text);
                multi = multi + Convert.ToInt32(Addition.multi.text);
                cashText.text = cash.ToString();
                prizeText.text = multi.ToString();
                StatGain();
                Debug.Log("Cash decreased. New cash: "+cash);
                Debug.Log("Multi increased. New multi: "+multi);
            }
            else
            {
                Debug.Log("Not enough cash to increase multiplier");
            }
        }
        else if (collision.gameObject.CompareTag("RebirthButton1"))
        {
            Debug.Log("Collided with button");
            if (cash >= Convert.ToInt32(Addition.cash.text))
            {
                multi = cash - Convert.ToInt32(Addition.cash.text);
                reb = multi + Convert.ToInt32(Addition.multi.text);
                cashText.text = cash.ToString();
                prizeText.text = multi.ToString();
                StatGain();
                Debug.Log("Cash decreased. New cash: " + cash);
                Debug.Log("Multi increased. New multi: " + multi);
            }
            else
            {
                Debug.Log("Not enough cash to increase multiplier");
            }
        }
    }
    void Update()
    {
        // Debug.Log(Convert.ToInt32(cost.text));
        // Debug.Log(Convert.ToInt32(prize.text));
        StatGain();
        ammount.text = cash.ToString("0");
        multiAmmount.text = multi.ToString("0");
    }
    // void FixedUpdate(){
    // }
    public void StatGain()
     {
        if(multi>0)
        {
            cash += 1*multi*Time.deltaTime;

        }
        else if (reb > 0)
        {
            multi += 1 * reb * Time.deltaTime;
        }
     }

    private void OnApplicationPause(bool pauseStatus){
        if(pauseStatus){
            Save();
        }
    }
    private void OnApplicationQuit(){
        Save();
    }
    private void Save(){
        PlayerPrefs.SetFloat("multi", multi);
        PlayerPrefs.SetFloat("cash", cash);
        PlayerPrefs.Save();
    }
}
