using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracterpersonaje : MonoBehaviour
{
   private int vidas = 3;

    //float nivelPiso              = -0.85f;  //Este valor representa el nivel del piso para el personaje 
    float nivelTecho             =9.68f;     //Este valor representa la parte superior de la escena
    float fuerzaSalto            = 40f;     //x veces la masa del personaje
    float Velocidad              = 3.5f;    //Este valor es de la velocidad del desplazamiento del personaje


    float limiteL = -8.40f;

    bool enElpiso = true;

    void Start()
    {
        //Personaje siempre inicia en la posicion (11.51,8.76)   
        gameObject.transform.position = new Vector3 (11.51f,nivelTecho, 0);  
        Debug.Log("INIT");
        Debug.Log("Vidas: " + vidas);
    }  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right") && gameObject.transform.position.x < limiteR)
        {
            gameObject.transform.Translate(Velocidad * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("left") && gameObject.transform.position.x >= limiteL)
        {
            gameObject.transform.Translate(-Velocidad * Time.deltaTime, 0, 0);
        }

        if (gameObject.transform.rotation.z > 0 || gameObject.transform.rotation.z < -0){
            Debug.Log("ROTATION: " + gameObject.transform.rotation.z);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }    
         if(Input.GetKeyDown("up") && enElpiso){
            Debug.Log("UP - enElpiso: " + enElpiso);
             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -fuerzaSalto*Physics2D.gravity[1]*gameObject.GetComponent<Rigidbody2D>().mass));
            enElpiso = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Ground"){
            enElpiso = true;
            Debug.Log("GROUND COLLISION");
        }
        else if(collision.transform.tag == "Obstaculo"){
            enElpiso = true;
            Debug.Log("OBSTACULO COLLISION");
        }
    }
}
   