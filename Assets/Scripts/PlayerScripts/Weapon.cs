using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string num;

    public Transform firepoint;
    public GameObject arrowprefab;
    public Arrow arrowshot;
    public float arrowDamage = 10;
    public float arrowSpeed = 30;
    public int arrowType; // 0 = normal, 1 = poison, 2 = exploding

    public bool canShoot;
    public float delay;
    public AudioClip shot;
    public AudioClip cock;
    public AudioSource musicsource;
    void Start()
    {
        arrowType = 0;
        delay = 0.6f;
        canShoot = true;
        musicsource.clip = shot;
    }
    void Update () {
		if(Input.GetButtonDown("Fire" + num)&& canShoot)
        {
            arrowshot.hitdamage = arrowDamage;
            arrowshot.speed = arrowSpeed;
            arrowshot.Type = arrowType;
            musicsource.clip = shot;
            musicsource.Play();
            shoot();
            canShoot = false;
            StartCoroutine("usedshot");

        }
	}
    IEnumerator usedshot()
    {
        yield return new WaitForSeconds(0.1f);
        musicsource.clip = cock;
        musicsource.Play();
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
    void shoot()
    {
            Instantiate(arrowprefab, firepoint.position, firepoint.rotation);
    }
}
