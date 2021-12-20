using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCtr : MonoBehaviour
{
    Rigidbody2D myRB;
    [SerializeField] float speed,backTime;
    [SerializeField] GameObject player;
    
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        myRB.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player");
        backTime = 0;
    }

    void Update()
    {
        backToPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerCtr.canShoot = true;
        }
    }
    void backToPlayer()
    {
        backTime += Time.deltaTime;
        if (backTime >= 1)       
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 20 * Time.deltaTime);        
    }
}
