using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float min_position_x, max_position_x, min_position_y, max_position_y;
    [SerializeField]
    private GameObject p_fire;
    [SerializeField]
    private Transform fire_point;

    public float fire_timer = 0.10f;
    private float cuurunt_fire_timer;
    private bool canattack;
    // Start is called before the first frame update
    void Start()
    {
        cuurunt_fire_timer = fire_timer;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
      
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 player = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0); ;

         if (player.x > max_position_x && player.y < min_position_y)
        {
            player.x = max_position_x;
            player.y = min_position_y;
        }
        else if (player.x > max_position_x && player.y > max_position_y)
        {
            player.x = max_position_x;
            player.y = max_position_y;
        }
        else if (player.x<min_position_x && player.y > max_position_y)
        {
            player.x = min_position_x;
            player.y = max_position_y;
        }
        else if (player.x < min_position_x && player.y < min_position_y)
        {
            player.x = min_position_x;
            player.y = min_position_y;
        }
        else if(player.y > max_position_y)
            player.y = max_position_y;
        else if (player.y < min_position_y)
            player.y = min_position_y;
        else if (player.x > max_position_x)
            player.x = max_position_x;
        else if (player.x < min_position_x)
            player.x = min_position_x;
        transform.position = player;
        Debug.Log(transform.position);
        attack();
    }
    void attack()
    {
        fire_timer += Time.deltaTime;
        if (fire_timer >cuurunt_fire_timer)
        {
            canattack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canattack)
            {
                canattack = false;
                fire_timer = 0f;
                Instantiate(p_fire, fire_point.position, Quaternion.identity);
            }
        }

    }
}
