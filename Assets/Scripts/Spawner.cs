using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private ObjectEscene objectEscene;
    private int directionObjectEscene;



    public float offset;
    public Vector2 rangoX;
    public Vector2 rangoY;
    public Vector2 rangoCooldown;
    public List<ObjectEscene> prefabs;

    public float cooldown;
    public float cooldownContador;
    void Start()
    {
        cooldown = Random.Range(rangoCooldown.x, rangoCooldown.y);
    }
    void Update()
    {
        cooldownContador += Time.deltaTime;
        if (cooldownContador>cooldown) 
        {
            spawnFunction();
            cooldown = Random.Range(rangoCooldown.x, rangoCooldown.y);
            cooldownContador = 0;
        }
    }
    public void spawnFunction() 
    {
        Vector3 position = randomPosition();
        int personajeRandom = randomCharacter();

        objectEscene = Instantiate(prefabs[personajeRandom], position, Quaternion.identity);
        objectEscene.direction = directionObjectEscene;
    }

    public Vector3 randomPosition() 
    {
        float posy = Random.Range(rangoY.x, rangoY.y);
        float posx = Random.Range(rangoX.x, rangoX.y);
        if (posx < 0)
        {
            posx += -offset;
            directionObjectEscene = 1;
        }
        else
        {
            posx += offset;
            directionObjectEscene = -1;
        }
        Vector3 position = this.transform.position + new Vector3(posx, posy, 0);
        return position;
    }

    public int randomCharacter() 
    {
        int personajeRandom = Random.Range(0, 100);
        if (personajeRandom > 20)
        {
            personajeRandom = 2;
        }
        else
        {
            personajeRandom = Random.Range(0, 1);
        }

        return personajeRandom;
    }
}
