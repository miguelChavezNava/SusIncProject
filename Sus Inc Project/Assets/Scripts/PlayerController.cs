using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
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
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        
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
        if(Input.GetButtonDown("Fire1") && !BulletController.isFired)
        {
            playerPosX = transform.position.x;
            Instantiate(bullet, new Vector3(transform.position.x+1,transform.position.y,transform.position.z), transform.rotation);
            BulletController.setIsFired(true);
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
}
