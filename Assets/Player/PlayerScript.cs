using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //rb.velocity = new Vector3(-7, 0, 0);
            return;
        }
   
        float moveSpeed = 5.0f;
        
        //右キー入力で右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 6.5)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("Move", true);
            }
        }
        //左
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -6.5)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("Move", true);
            }
        }
        //前(上)
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.z < 5)
            {
                rb.velocity = new Vector3(0, 0, moveSpeed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("Move", true);
            }
        }
        //後(下)
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.z > -5)
            {
                rb.velocity = new Vector3(0, 0, -moveSpeed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
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
                position.x += 0.5f;

                Instantiate(bullet, position, Quaternion.identity);
                bulletTimer = 1;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;
                position.x += -0.5f;

                Instantiate(bullet, position, Quaternion.identity);
                bulletTimer = 1;
            }
        }
        else
        {
            bulletTimer++;
            if (bulletTimer > 10)
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
