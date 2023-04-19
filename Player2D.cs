using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour
{
    protected float h; //desplazamiento horizontal
    public float velocidad;
    private bool bloquearDerecha;
    private bool bloquearIzquierda;

   // private int numToques;
    public GameObject puntuacion;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 5.0f;
        bloquearDerecha = false;
        bloquearIzquierda = false;
        General.numeroToques = 0;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        if (h > 0.0f){
            if (!bloquearDerecha) {
             this.gameObject.transform.Translate(h, 0.0f, 0.0f); //desplazamiento del objeto
            }
        } else if (h < 0.0f){
            if (!bloquearIzquierda){
             this.gameObject.transform.Translate(h, 0.0f, 0.0f); //desplazamiento del objeto
            }
        }
    }
    //colisión de la barra con los límites laterales
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "LimiteDerecho"){ //tag creado y asignado en el Inspector del objeto
            // Debug.Log("Detecto el límite derecho"); -> para comprobar que lo coge
            bloquearDerecha = true; //si toca el sensor, no se desplaza a la dcha.
        }
        if (other.gameObject.tag == "LimiteIzquierdo"){
           // Debug.Log("Detecto el límite izquierdo");
           bloquearIzquierda = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "LimiteDerecho"){ 
            bloquearDerecha = false; 
        }
        if (other.gameObject.tag == "LimiteIzquierdo"){
           bloquearIzquierda = false;
        }
    }

    //evento para colision del balon con la barra
    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Balon"){
            General.numeroToques = General.numeroToques + 1;
            puntuacion.GetComponent<Text>().text = General.numeroToques.ToString();
        }
    }
}
