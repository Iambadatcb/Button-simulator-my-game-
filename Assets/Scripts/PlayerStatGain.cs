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
     public TextMesh cost;
     public TextMesh prize;
     public TextMeshProUGUI ammount;
     public TextMeshProUGUI multiAmmount;
     [Header("Shooting myself in the head")]
     public new GameObject gameObject;
    //  private Collider collision;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("turns on");
        gameObject.GetComponent<GameObject>();
        cash = PlayerPrefs.GetFloat("cash", 0);
        multi = PlayerPrefs.GetFloat("multi",1);
    }

    // Update is called once per frame
    void OnCollisionEnter3D(Collider collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.CompareTag("MultiButton1")){
            Debug.Log("Collided with button");
            if(cash>=Convert.ToInt32(cost.text)){
                cash-=Convert.ToInt32(cost.text);
                multi+= Convert.ToInt32(prize.text);
                StatGain();
                Debug.Log("Cash decreased. New cash: "+cash);
                Debug.Log("Multi increased. New multi: "+multi);
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
        PlayerPrefs.Save();
    }
}
