using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inflictDamage : MonoBehaviour
{

    public float health;
    public float maxhealth;
    public int timesDied;

    public Image life;
    public Sprite poisonbar;
    private Sprite normalBar;

    private SpriteRenderer sprite;
    public AudioClip ouch;
    public AudioSource musicsource;

    public Vector2 T;
    private Rigidbody2D rb;
    public Sprite damaged;
    private Sprite normal;
    void Start()
    {
        timesDied = 0;
        rb = GetComponent<Rigidbody2D>();
        T = rb.transform.position;
        maxhealth = 100;
        health = maxhealth;
        sprite = GetComponent<SpriteRenderer>();
        normal = sprite.sprite;
        normalBar = life.sprite;
        musicsource.clip = ouch;
    }
    void Update()
    {
        life.fillAmount = health / maxhealth;
        if (health <= 0)
        {
            timesDied++;
            health = maxhealth;
            rb.transform.position = T;
            life.fillAmount = 1;
        }
    }
    public void TakeDamage(float damage, int arrowType)
    {
        health -= damage;
        musicsource.Play();
        StartCoroutine("hit");
        Debug.Log(arrowType);
        Debug.Log(arrowType == 1);
        if (arrowType == 1)
        {
            if (health > 5)
            {
                life.sprite = poisonbar;
                StartCoroutine("poison");
            }
        }
    }
    IEnumerator hit()
    {
        sprite.sprite = damaged;
        yield return new WaitForSeconds(0.5f);
        sprite.sprite = normal;
    }
    IEnumerator poison()
    {
        sprite.sprite = damaged;
        Debug.Log(rb.name + " took poison damage");
        health -= 5;
        musicsource.Play();
        yield return new WaitForSeconds(1.8f);
        sprite.sprite = normal;
        sprite.sprite = damaged;
        Debug.Log(rb.name + " took poison damage");
        health -= 5;
        musicsource.Play();
        yield return new WaitForSeconds(1.8f);
        sprite.sprite = normal;
        sprite.sprite = damaged;
        Debug.Log(rb.name + " took poison damage");
        health -= 5;
        musicsource.Play();
        sprite.sprite = normal;
        life.sprite = normalBar;
    }

}
