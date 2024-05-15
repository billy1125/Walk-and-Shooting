using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    [Header("移動設定")]
    public string playerTag = "Player";
    public float moveSpeed = 30.0f;
    public float rotationAngle = 45f;
    public float accelerationDistance = 3.0f;
    public float accelerationMultiplier = 2.0f;

    private float realtimeSpeed;
    private bool isDead = false;
    private Rigidbody rbEnemy;
    private Collider coEnemy;
    private Transform playerTransform;

    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        realtimeSpeed = moveSpeed;
        Destroy(gameObject, 10);

        rbEnemy = GetComponent<Rigidbody>();
        coEnemy = GetComponent<Collider>();
     
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
            playerTransform = playerObject.transform;
        else
            Debug.LogError("Player object not found!");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
      
        if (distanceToPlayer < accelerationDistance)
        {
            realtimeSpeed = moveSpeed * accelerationMultiplier;
            // 计算朝向主角的方向
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            // 面向主角
            transform.forward = -direction;
        }
        else
        {
            realtimeSpeed = moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (!isDead) {
            Move();
        }        
    }

    private void Move()
    {
        // 推動第一人稱物件
        //transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        rbEnemy.velocity = transform.forward * realtimeSpeed;
    }
    

    void OnCollisionEnter(Collision collision)
    {
        //// 碰撞發生時，反彈物體
        //Vector3 normal = collision.contacts[0].normal;
        //direction = Vector3.Reflect(direction, Vector3.up);

        //transform.Rotate(Vector3.up, rotationAngle);
        if (collision.gameObject.tag == "Bullet")
        {
            rbEnemy.isKinematic = true;
            coEnemy.enabled = false;
            isDead = true;  
        }
    }
}
