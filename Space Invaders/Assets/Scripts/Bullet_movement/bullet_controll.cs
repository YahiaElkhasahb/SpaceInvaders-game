using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controll : MonoBehaviour
{
    public float speed = 15f;
    public float deactive_time = 25f;
    public bool player;
    public bool enemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("deactiveObject", deactive_time);
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {
        if (player)
        {
            Vector3 bullet = transform.position;
            bullet.y += speed * Time.deltaTime;
            transform.position = bullet;
        }
        else
        {
            Vector3 bullet = transform.position;
            bullet.y -= speed * Time.deltaTime;
            transform.position = bullet;
        }
    }
    void deactiveObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Bullet" || target.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }

    }
}
