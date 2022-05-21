using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public GameObject player;
    private float speed = 13.0f;
    private float horizontalInput;
    private Vector3 jump = new Vector3(0, 1, 0);
    private bool isGrounded;
    private Rigidbody playerRB;
    private float jumpForce = 4;
    public GameObject bullet;
    public float playerPosX;
    public float health = 10;
    public static float lives = 3;
    private BulletController bulletScript;
    public AudioSource jumpSound;
    public AudioSource gunSound;
    private bool onPlatform = false;
    public GameObject movingPlatform;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        bulletScript = bullet.GetComponent<BulletController>();
        healthBar.setMaxHealth(health);
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
            jumpSound.Play();
            transform.parent = null;
            onPlatform = false;
        }
        if(Input.GetButtonDown("Fire1") && bulletScript.getIsFired())
        {
            playerPosX = transform.position.x;
            bulletScript.setIsFired(true);
            gunSound.Play();
            if(horizontalInput < 0)
            {
                Shoot(-1);
                bulletScript.updateDirection(false);
            }
            else
            {
                Shoot(1);
                bulletScript.updateDirection(true);
            }
        }
        if(transform.position.y <= -5)
        {
            lives--;
            SceneManager.LoadScene("Main");
        }
        if(onPlatform)
        {
            transform.parent = movingPlatform.transform;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EndGame"))
        {
            lives--;
            SceneManager.LoadScene("Level 1");
        }
        isGrounded = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            lives--;
            SceneManager.LoadScene("Level 1");
        }
        if(collision.gameObject.CompareTag("Moving Platform"))
        {
            onPlatform = true;
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene("Win");
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
