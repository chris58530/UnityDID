using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterCtr : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
   // Rigidbody2D myRB;
    void Awake()
    {
       // myRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        speed = 1;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            speed = -2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            speed = 1;
        }
    }
}
