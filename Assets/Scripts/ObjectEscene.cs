using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEscene : MonoBehaviour
{
    private SpriteRenderer mySprite;
    public bool bueno;
    public int direction;
    public float velocidad;
    void Start()
    {
        //Invoke("muerte", 8);
        velocidad = 2;

        if (direction > 0) 
        {
            mySprite = GetComponent<SpriteRenderer>();
            mySprite.flipX = true;
        }
    }

    void Update()
    {
        this.transform.position += Vector3.right * direction * Time.deltaTime * velocidad;
    }

    public void muerte() 
    {
        Destroy(this.gameObject);
    }

}
