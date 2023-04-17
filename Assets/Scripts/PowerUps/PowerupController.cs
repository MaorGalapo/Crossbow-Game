using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public GameObject powerupPrefab;

    public List<Powerup> powerups;

    public Dictionary<Powerup, float> activePowerups = new Dictionary<Powerup, float>();

    private List<Powerup> keys = new List<Powerup>();

    private Collider2D playerP;

    public PowerupActions powerUpActions;

    public int num;

    public PowerUpSpawner spawner;

    #region Global Powerup Functions

    // Handles the beginning and ending of activated Powerups.
    // Inactive Powerups are removed automatically.
    private void HandleGlobalPowerups()
    {
        bool changed = false;

        if (activePowerups.Count > 0)
        {
            foreach (Powerup powerup in keys)
            {
                if (activePowerups[powerup] > 0)
                {
                    if (!powerup.isOneTime)
                        activePowerups[powerup] -= Time.deltaTime;
                    else
                    {
                        if (!playerP.GetComponent<Weapon>().canShoot && playerP != null)
                        {
                            activePowerups[powerup] = 0;
                        }
                    }
                }
                else
                {
                    changed = true;

                    activePowerups.Remove(powerup);

                    if (powerup.endAction != null)
                    {
                        powerUpActions.setUpPowerUp(playerP);
                        powerup.EndP();
                    }
                }
            }
        }

        if (changed)
        {
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    // Adds a global Powerup to the activePowerups list.
    public void ActivatePowerup(Powerup powerup, Collider2D hitInfo)
    {
        spawner.powerup1B = false;
        if (hitInfo.name.Substring(6, 1) == num.ToString())
        {
            playerP = hitInfo.GetComponent<Collider2D>();
            powerUpActions.setUpPowerUp(playerP);
        }
        if (!activePowerups.ContainsKey(powerup))
        {
            powerUpActions.setUpPowerUp(playerP);
            powerup.StartP();
            Debug.Log(powerup.name + "--" + powerup.duration + "-- " + powerup.isOneTime);
            activePowerups.Add(powerup, powerup.duration);
        }
        else
        {
            activePowerups[powerup] = powerup.duration;
        }

        keys = new List<Powerup>(activePowerups.Keys);
    }

    // Calls the end action of each powerup and clears them from the activePowerups
    public void ClearActivePowerups()
    {
        foreach (KeyValuePair<Powerup, float> Powerup in activePowerups)
        {
            powerUpActions.setUpPowerUp(playerP);
            Powerup.Key.EndP();
        }

        activePowerups.Clear();
    }

    #endregion

    // checks for disabling global powerups
    void Update()
    {
        HandleGlobalPowerups();
        //if (Input.GetKeyDown(KeyCode.T))
        //    SpawnPowerup(powerups[0], new Vector2(-9.5f, 4));
    }

}
