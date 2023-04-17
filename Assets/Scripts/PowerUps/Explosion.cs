using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explodeDamage = 35;
    public AudioSource musicsource;
    private bool exploded = false;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        inflictDamage damage = hitInfo.GetComponent<inflictDamage>();
        if (damage != null)
            damage.TakeDamage(explodeDamage, 0);
    }
    void FixedUpdate()
    {
        if (!exploded)
            StartCoroutine("Explode");
    }

    IEnumerator Explode()
    {
        exploded = true;
        musicsource.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
