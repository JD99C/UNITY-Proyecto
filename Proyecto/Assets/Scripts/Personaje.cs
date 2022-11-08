using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class Personaje : MonoBehaviour
{
    //Movimientos del personaje
    public float speed = 5.0f;
    public float speedRatator = 200.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;
    //Menu - Contador - UI - Scene1
   [SerializeField] private int count;
    public TextMeshProUGUI countText;
    
    //Auidio Pick
    public GameObject audioPick;

    //UI Win Scene2
    public GameObject winTextObject;
    public TextMeshProUGUI countText2;
    [SerializeField] private int count2;


    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();

        // Add one to the score variable 'count'
        count = 0;
        count2 = 0;
        // Run the 'SetCountText()' function (see below)
        SetCountText();

        winTextObject.SetActive(false);
    }

     void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * speedRatator, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if(puedoSaltar == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) )
            {
                anim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
            
               
            
        }

        if (other.gameObject.CompareTag("PickUp"))
        {
            Instantiate(audioPick);
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count2 = count2 + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText2();
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            Instantiate(audioPick);
        }

        if (other.gameObject.CompareTag("Limite"))
        {
            Vector3 posicion = new Vector3(0, 0.5f, 0);
            transform.position = posicion;
        }

        if (other.gameObject.CompareTag("Limite2"))
        {
            Vector3 posicion = new Vector3(0, 31f, 0);
            transform.position = posicion;
        }
    }

    void SetCountText()
    {
        countText.text = "Puntos: " + count.ToString();

        if (count >= 12)
        {
            SceneManager.LoadScene("Juego2");
        }
    }

    void SetCountText2()
    {
        countText2.text = "Manzanas: " + count2.ToString();


        if (count2 >= 9)
        {
            winTextObject.SetActive(true);
        }
    }

}
