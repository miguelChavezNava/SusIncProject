using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10.0f;
    public static bool isFired = false;
    private PlayerController playerCtrlScript;
    public static string shooter;
    private EnemyController enemyCtrlScript;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrlScript = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyCtrlScript = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.Equals("player"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= (playerCtrlScript.playerPosX + 10))
            {
                Destroy(gameObject);
                setIsFired(false);
            }
        }
        if(shooter.Equals("enemy"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if(transform.position.x <= (enemyCtrlScript.enemyPosX - 10))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EndGame")
        {
            Destroy(other.gameObject);
            setIsFired(false);
        }
        if(other.gameObject.tag == "Player")
        {
            playerCtrlScript.health--;
            Debug.Log(playerCtrlScript.health);
        }
    }
    public static void setIsFired(bool change)
    {
        isFired = change;
    }
    public static void setShooter(string newShooter)
    {
        shooter = newShooter;
    }
}
