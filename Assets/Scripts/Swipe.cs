using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direccionSwipe { derecha, izquierda, arriba, abajo, none }
public class Swipe : MonoBehaviour
{
    Vector3 startPositionSwipe;
    Vector3 endPositionSwipe;
    void Start()
    {
        startPositionSwipe = Vector3.zero;
        endPositionSwipe = Vector3.zero;
    }

    public direccionSwipe SwipeDirection()
    {
        if (Input.touchCount > 0)
        {
            Touch touch_ = Input.GetTouch(0);
            switch (touch_.phase)
            {
                case TouchPhase.Began:
                    startPositionSwipe = new Vector2(touch_.position.x, touch_.position.y);
                    break;

                case TouchPhase.Ended:
                    endPositionSwipe = new Vector2(touch_.position.x, touch_.position.y);
                    Vector3 swipe_ = (endPositionSwipe - startPositionSwipe).normalized;

                    if (swipe_.y > 0 && Mathf.Abs(swipe_.x) < 0.5f)
                    {
                        return direccionSwipe.arriba;
                    }

                    else if (swipe_.y < 0 && Mathf.Abs(swipe_.x) < 0.5f)
                    {
                        return direccionSwipe.abajo;
                    }

                    else if (swipe_.x < 0 && Mathf.Abs(swipe_.y) < 0.5f)
                    {
                        return direccionSwipe.izquierda;
                    }

                    else if (swipe_.x > 0 && Mathf.Abs(swipe_.y) < 0.5f)
                    {
                        return direccionSwipe.derecha;
                    }
                    else
                    {
                        return direccionSwipe.none;
                    }
            }
        }

        return direccionSwipe.none;
    }
}
