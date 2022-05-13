using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10.0f;
    public static bool isFired = false;
    private PlayerController playerCtrlScript;
   
    // Start is called before the first frame update
    void Start()
    {
        playerCtrlScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x >= (playerCtrlScript.playerPosX + 10))
        {
            Destroy(gameObject);
            setIsFired(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EndGame")
        {
            Destroy(other.gameObject);
            setIsFired(false);
        }
    }
    public static void setIsFired(bool change)
    {
        isFired = change;
    }
}
