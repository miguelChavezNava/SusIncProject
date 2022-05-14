using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public GameObject player;
    private float speed = 5.0f;
    private float horizontalInput;
    private Vector3 jump = new Vector3(0, 2, 0);
    private bool isGrounded;
    private Rigidbody playerRB;
    private float jumpForce = 2;
    public GameObject bullet;
    public float playerPosX;
    public float health = 10;
    public static float lives = 3;
    private BulletController bulletScript;
  
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        bulletScript = bullet.GetComponent<BulletController>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if(Input.GetButtonDown("Fire1") && bulletScript.getIsFired())
        {
            playerPosX = transform.position.x;
            bulletScript.setIsFired(true);
            if(horizontalInput < 0)
            {
                Debug.Log("Shoot");
                Shoot(-1);
                bulletScript.updateDirection(false);
            }
            else
            {
                Debug.Log("Shoot");
                Shoot(1);
                bulletScript.updateDirection(true);
            }
        }
        if(transform.position.y <= -5)
        {
            lives--;
            SceneManager.LoadScene("Main");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EndGame"))
        {
            lives--;
            SceneManager.LoadScene("Main");
        }
        isGrounded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            playerRB.AddForce(new Vector3(10,0,0)*10, ForceMode.Impulse);

        }

    }
    public void Shoot(int direction)
    {
        Instantiate(bullet, new Vector3(transform.position.x + direction, transform.position.y, transform.position.z), bullet.transform.rotation);
    }
    public float getInput()
    {
        return horizontalInput;
    }
}
