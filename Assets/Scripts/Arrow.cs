using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject explodePrefab;

    bool hitground;
    public float speed = 30;
    public float hitdamage = 0;
    public Rigidbody2D rb;
    public int Type;
    void Start()
    {
        hitground = false;
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        float lastRotation = rb.rotation;
        Vector3 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (!hitground)
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        else
            rb.rotation = lastRotation;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        inflictDamage damage = hitInfo.GetComponent<inflictDamage>();
        if (damage != null && !hitground)
            damage.TakeDamage(hitdamage, Type);
        if (Type == 2)
            Instantiate(explodePrefab, rb.transform.position, Quaternion.identity);
        if (hitInfo.name.Substring(0, 5).ToLower() != "arrow" && hitInfo.name.Substring(0, 6).ToLower() != "invisa" && !hitground)
        {
            hitground = true;
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0;
            if (hitInfo.name.Substring(0, 6).ToLower() == "player" || Type == 2)
                Destroy(gameObject);
            else
                StartCoroutine("stickInGround");

        }
    }
    IEnumerator stickInGround()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
