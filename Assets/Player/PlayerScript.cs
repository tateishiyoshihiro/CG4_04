using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameManager gameManagerScript;
    public Rigidbody rb;
    public Animator animator;
    public GameObject bullet;
    public GameObject gameManager;
    float bulletTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }

        float moveSpeed = 2.0f;
        float stageMax = 4.0f;
        float stageMin = -4.0f;
        
        //右キー入力で右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("Move", true);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > stageMin)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("Move", true);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Move", false);
        }
    }
    private void FixedUpdate()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }

        if (bulletTimer == 0)
        {
            //弾発射
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;

                Instantiate(bullet, position, Quaternion.identity);
                bulletTimer = 1;
            }
        }
        else
        {
            bulletTimer++;
            if (bulletTimer > 20)
            {
                bulletTimer = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameManagerScript.GameOverStart();
        }
    }
}
