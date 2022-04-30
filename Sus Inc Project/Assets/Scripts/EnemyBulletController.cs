using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private EnemyController enemyCtrlScript;
    private PlayerController playerCtrlScript;
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyCtrlScript = GameObject.Find("Enemy").GetComponent<EnemyController>();
        playerCtrlScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= (enemyCtrlScript.enemyPosX - 10))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCtrlScript.health--;
            Debug.Log(playerCtrlScript.health);
        }
    }
}
