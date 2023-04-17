using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    public Playercontroller playerController;

    [SerializeField]
    public Weapon weapon;

    [SerializeField]
    public inflictDamage InflictDamage;

    public void setUpPowerUp(Collider2D P)
    {
        this.InflictDamage = P.GetComponent<inflictDamage>();
        this.weapon = P.GetComponent<Weapon>(); ;
        this.playerController = P.GetComponent<Playercontroller>(); ;
    }
    public void SniperArrowStartAction()
    {
        weapon.arrowDamage = 50;
        weapon.arrowSpeed = 50;
    }

    public void SniperArrowEndAction()
    {
        weapon.arrowDamage = 10;
        weapon.arrowSpeed = 30;
    }
    public void HealthStartAction()
    {
        if (InflictDamage.health < 100)
        {
            if (InflictDamage.health > 80)
            {
                InflictDamage.health = 100;
            }
            else
            {
                InflictDamage.health += 20;
            }
        }
    }
    public void PoisonStartAction()
    {
        weapon.arrowType = 1;
    }
    public void TypeResetAction()
    {
        weapon.arrowType = 0;
    }
    public void ExplosionStartAction()
    {
        weapon.arrowType = 2;
    }
}
