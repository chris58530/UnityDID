using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtr : MonoBehaviour
{
    [SerializeField] float moveSpeed,upSpeed;
    public GameObject bullet,firePoint;
    public GameObject Lili, Ethon;
    public GameObject flower;
    public int whitchPlayer = 1;
    public static bool canShoot;
    public bool Li_Walk, Li_Idle,Li_Fall, Li_Land, Li_Jump;
    public bool Et_Walk, Et_Idle, Et_Attack;
    public bool canTakeFlower;
    public bool isGround;

    Rigidbody2D myRB;
    Animator LiliAni;
    Animator EthonAni;
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        LiliAni = Lili.GetComponent<Animator>();
        EthonAni = Ethon.GetComponent<Animator>();
    }
    void Start()
    {
        canShoot = true;
        canTakeFlower = false;
        isGround = false;

        whitchPlayer = 1;
    }

    void Update()
    {
        SwitchPlayer();
        LiliControl();
        EthonControl();
    }   
    void SwitchPlayer()
    {
        switch (whitchPlayer)
        {
            case 1:
                Lili.gameObject.SetActive(true);
                Ethon.gameObject.SetActive(false);
                Debug.Log("LiliTime");
                break;
            case 2:
                Lili.gameObject.SetActive(false);
                Ethon.gameObject.SetActive(true);
                Debug.Log("EthonTime");
                break;
        }
        if (Input.GetKeyDown(KeyCode.Z))
            whitchPlayer = 1;
        if (Input.GetKeyDown(KeyCode.X))        
            whitchPlayer = 2;        
    }
    void LiliControl() 
    {
        if (whitchPlayer == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Li_Walk = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, -180, 0);
                Li_Walk = true;
            }
            if (Input.GetKey(KeyCode.T) && canTakeFlower)
            {
                transform.position = flower.transform.position;
                canTakeFlower = false;
            }
            if (myRB.velocity.y < 0)
            {
                Li_Idle = false;
                Li_Walk = false;
                Li_Fall = true;
            }
            if (myRB.velocity.y == 0)
                Li_Fall = false;
                Li_Jump = false;

            if (myRB.velocity.y > 0)
                Li_Jump = true;
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                isGround = false;
                myRB.AddForce(Vector2.up * upSpeed * 100);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                Li_Walk = false;
           
        }
        //-----動畫設置-----
        LiliAni.SetBool("Li_Walk",Li_Walk);
        LiliAni.SetBool("Li_Idle",Li_Idle);
        LiliAni.SetBool("Li_Fall",Li_Fall);
        LiliAni.SetBool("Li_Land", Li_Land);
        LiliAni.SetBool("Li_Jump", Li_Jump);

    }
    void EthonControl()
    {
        if(whitchPlayer == 2)
        {
            if (Input.GetKey(KeyCode.D) )
            {
                transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Et_Walk = true;
            }
            if (Input.GetKey(KeyCode.A) )
            {
                transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, -180, 0);
                Et_Walk = true;
            }
            if (Input.GetKeyDown(KeyCode.Space)&& isGround)
            {
                isGround = false;
                myRB.AddForce(Vector2.up * upSpeed * 100);
            }

            if (Input.GetKeyDown(KeyCode.K) && canShoot == true )
            {
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                canShoot = false;
                Et_Attack = true;
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                Et_Walk = false;
        }
        //-----動畫設置-----
        EthonAni.SetBool("Et_Walk", Et_Walk);
        EthonAni.SetBool("Et_Idle", Et_Idle);
        EthonAni.SetBool("Et_Attack", Et_Attack);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Flower")        
            canTakeFlower = true;             
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")        
            isGround = true;        
    }
}
