using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool turnLeft = false;
    public GameObject bullet;
    public float enemyPosX;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shootBullets", 0.1f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnLeft)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(transform.position.x >= 15)
        {
            turnLeft = true;
        }
        if(transform.position.x <= 5)
        {
            turnLeft = false;
        }
    }
    void shootBullets()
    {
        BulletController.setShooter("enemy");
        enemyPosX = transform.position.x;
        Instantiate(bullet, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
    }
}
