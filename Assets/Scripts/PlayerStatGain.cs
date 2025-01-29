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
        reb = PlayerPrefs.GetFloat("rebirth", 0);
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        var Addition = collision.gameObject.GetComponent<Button>();
        
        if(collision.gameObject.CompareTag("MultiButton1")){
            Debug.Log("Collided with button");


            if (cash >= Convert.ToInt32(Addition.cash.text))
            {   
                if(reb>0)
                {
                cash = cash - Convert.ToInt32(Addition.cash.text);
                multi = multi + Convert.ToInt32(Addition.multi.text)*(2*reb);
                cashText.text = cash.ToString();
                prizeText.text = multi.ToString();
                }
                else if(reb<=0)
                {
                cash = cash - Convert.ToInt32(Addition.cash.text);
                multi = multi + Convert.ToInt32(Addition.multi.text);
                cashText.text = cash.ToString();
                prizeText.text = multi.ToString();
                }
                StatGain();
                Debug.Log("Cash decreased. New cash: "+cash);
                Debug.Log("Multi increased. New multi: "+multi);
            }
            else
            {
                Debug.Log("Not enough cash to increase multiplier");
            }
        }
        if (collision.gameObject.CompareTag("RebirthButton1"))
        {
            Debug.Log("Collided with button");
            if (multi >= Convert.ToInt32(Addition.cash.text))
            {
                multi = multi - Convert.ToInt32(Addition.cash.text);
                reb = reb + Convert.ToInt32(Addition.multi.text);
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
        PlayerPrefs.SetFloat("rebirth", reb);
        PlayerPrefs.Save();
    }
}
