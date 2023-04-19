using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{
    public GameObject panelDerrota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "LimitePorteria"){
            panelDerrota.SetActive(true);
            Time.timeScale = 0.0f;

            if(PlayerPrefs.HasKey("TOQUESRECORD")){
                if (General.numeroToques > PlayerPrefs.GetInt("TOQUESRECORD")){
                    PlayerPrefs.SetInt("TOQUESRECORD", General.numeroToques);
                }
            } else {
                PlayerPrefs.SetInt("TOQUESRECORD", General.numeroToques);
            }
        }
    }
}