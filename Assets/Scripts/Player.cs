using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;


    public Swipe mySwipe;

    public direccionSwipe mydirectionSWIPE;
    public bool swipeControl;

    public Rigidbody2D myRB;
    public float velocidadSwipe;
    public float velocidadAce;
    public int directionMovement;

    private Vector3 aceleration;



    //VIDA  PU7NTOS
    public bool choco;
    public int puntos;
    public int lives;
    void Start()
    {
        puntos = 0;
        lives = 3;
        myRB = GetComponent<Rigidbody2D>();

        text.text = puntos.ToString();
        text2.text = lives.ToString();
    }

    void Update()
    {
        if (swipeControl)
        {
            mydirectionSWIPE = mySwipe.SwipeDirection();
            if (mydirectionSWIPE != direccionSwipe.none)
            {

                if (mydirectionSWIPE == direccionSwipe.abajo)
                {
                    //directionMovement = -1;
                    myRB.AddForce(new Vector2(0, -1 * velocidadSwipe) * Time.deltaTime);
                }
                if (mydirectionSWIPE == direccionSwipe.arriba)
                {
                    //directionMovement = +1;
                    myRB.AddForce(new Vector2(0, 1 * velocidadSwipe) * Time.deltaTime);
                }

                //myRB.AddForce(new Vector2(0, directionMovement * velocidadSwipe) * Time.deltaTime);
            }
        }
        else 
        {
            aceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);

            if (Mathf.Abs(aceleration.x) > 0.05f && Mathf.Abs(aceleration.z) > 0.05f)
            {
                Vector3 movimiento = (this.transform.up * velocidadAce * aceleration.y) * Time.deltaTime;
                myRB.AddForce(movimiento * Time.deltaTime);

            }
        }

    }

    public void changeControls() 
    {
        swipeControl = !swipeControl;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) 
        {
            ObjectEscene objetoo = collision.gameObject.GetComponent<ObjectEscene>();
            if (objetoo.bueno)
            {
                puntos += 10;

                text.text = puntos.ToString();
            }
            else
            {
                lives -= 1;

                text2.text = lives.ToString();
            }
            Destroy(collision.gameObject);
        }
    }


}
