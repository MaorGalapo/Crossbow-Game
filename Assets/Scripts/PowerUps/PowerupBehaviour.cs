using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{

    #region Component References
    
    public PowerupController controller;

    [SerializeField]
    private Powerup powerup;

    private Transform transform_;


    #endregion



    #region Monobehaviour API
    private void Awake()
    {
        transform_ = transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            controller = other.GetComponent<Playercontroller>().playerPowerUpController;
            ActivatePowerup(other);
            Destroy(gameObject);
        }
    }

    #endregion

    private void ActivatePowerup(Collider2D hitInfo)
    {
        controller.ActivatePowerup(powerup, hitInfo);
    }

    public void SetPowerup(Powerup powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
    }
}
