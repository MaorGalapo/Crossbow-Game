using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject powerupPrefab;

    public List<Powerup> powerups;

    public Powerup powerup1;
    public bool powerup1B = false;
    private int x = 0;
    private float timeSpawned;
    // Update is called once per frame
    void Update()
    {
        if (!powerup1B && x == 0 && Time.time - timeSpawned >3)
        {
            timeSpawned = Time.time;
            SpawnRandomPowerup(new Vector2(-9.5f, 4));
            powerup1B = true;
            x = 5;
            StartCoroutine("wait");
        }
    }
    // Spawns a powerup by given name at given position.
    public GameObject SpawnPowerup(Powerup powerup, Vector2 position)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        powerupGameObject.GetComponent<SpriteRenderer>().sprite = powerup.powerUpSprite;

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

        // powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerup);
        Debug.Log(powerup.name + "has spawned");
        powerupGameObject.transform.position = position;

        return powerupGameObject;
    }

    public GameObject SpawnRandomPowerup(Vector2 position)
    {
        int x = Random.Range(0, powerups.Count);
        powerup1 = powerups[x];
        return SpawnPowerup(powerups[x], position);
    }
    IEnumerator wait()
    {
        while (x != 0)
        {
            yield return new WaitForSeconds(1.2f);
            x = Random.Range(0, 9);
        }
    }
}
