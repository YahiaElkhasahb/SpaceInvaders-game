using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controll : MonoBehaviour
{
    public float speed = 5f;
    public float rotate_Speed = 50f;

    public bool canShoot;
    public bool canRotate;
    public bool canMove_x;
    public bool canMove_y ;
    public float min_position_x, max_position_x, min_position_y;
    public bool touch = true;
    public Transform attack_Point;
    public GameObject bulletPrefab;

    private Animator anim;
    private AudioSource explosionSound;


    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {

                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;

            }
            else
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(10f, 15f));

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if (canMove_x)
        {


            Vector3 temp = transform.position;
            if (temp.x > min_position_x && touch==false)
            {
                temp.x -= speed * Time.deltaTime;
                transform.position = temp;

            }
            else
            {
                touch = true ;
                if (temp.x < max_position_x)
                {
                    temp.x += speed * Time.deltaTime;
                    transform.position = temp;
                }
                else
                    touch = false;
            }
            


        }
        else if (canMove_y)
        {
            Vector3 temp     = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < min_position_y)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {

        GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        //bullet.GetComponent<BulletScript>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));

    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Bullet")
        {

            canMove_x = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }

            Invoke("TurnOffGameObject", 3f);

            // play explosion sound
           
            anim.Play("Destroy");

        }

    }
}
