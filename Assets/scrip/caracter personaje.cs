using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracterpersonaje : MonoBehaviour
{
   private int vidas = 3;

    //float nivelPiso              = -0.85f;  //Este valor representa el nivel del piso para el personaje 
    float nivelTecho             =6.41f;     //Este valor representa la parte superior de la escena
    float fuerzaSalto            = 40f;     //x veces la masa del personaje
    float fuerzaDesplazamiento   = 100f;     //Fuerza en Newtons 
    float Velocidad              = 3.5f;    //Este valor es de la velocidad del desplazamiento del personaje
    float LimiteR                = 28.01f;   //Este valor respresenta el limite derecho de la camara para el personaje 
    float LimiteL                = -20.87f;  //Este valor respresenta el limite izquierdo de la camara para el personaje
    
    bool enElpiso = true;


    void Start()
    {
        //Personaje siempre inicia en la posicion (9.15,-1.21)   
        gameObject.transform.position = new Vector3 (9.15f,nivelTecho, 0);  
        Debug.Log("INIT");
        Debug.Log("Vidas: " + vidas);
    }  
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.rotation.z > 0 || gameObject.transform.rotation.z < -0){
            Debug.Log("ROTATION: " + gameObject.transform.rotation.z);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }    

        if(Input.GetKey("right") && gameObject.transform.position.x < LimiteR && enElpiso){
            Debug.Log("RIGHT");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento, 0));
        }  
        else if(Input.GetKey("left") && gameObject.transform.position.x >= LimiteL && enElpiso){
            Debug.Log("LEFT");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fuerzaDesplazamiento, 0));
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
    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("CAIDA");
        vidas-=1;
        Debug.Log("Vidas: " + vidas);
        if(vidas <=0){
            Debug.Log("GAME OVER");
        }
        gameObject.transform.position = new Vector3 (-12.3f,nivelTecho, 0);
    }
}
   