using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public GameObject recordUI;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("TOQUESRECORD")){
            //Hemos jugado al menos una vez
            recordUI.GetComponent<Text>().text = PlayerPrefs.GetInt("TOQUESRECORD").ToString();
        } else {
            //no hemos jugado nunca
            recordUI.GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}