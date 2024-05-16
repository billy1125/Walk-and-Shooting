using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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
    public GameObject playerObject = null;

    public Vector3 direction;
    public Vector3 defaultRotation; // 預設移動方向

    // Start is called before the first frame update
    void Start()
    {
        realtimeSpeed = moveSpeed;
        Destroy(gameObject, 10);

        rbEnemy = GetComponent<Rigidbody>();
        coEnemy = GetComponent<Collider>();
     
        playerObject = GameObject.FindWithTag(playerTag);
        defaultRotation = transform.rotation.eulerAngles;
        direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < accelerationDistance)
            {
                realtimeSpeed = moveSpeed * accelerationMultiplier;
                // 计算朝向主角的方向
                direction = (playerTransform.position - transform.position).normalized;
                // 面向主角
                transform.forward = -direction;
            }
            else
            {
                MoveInDefaultDirection();
            }
        }
        else
        {
            MoveInDefaultDirection();
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
    
    private void MoveInDefaultDirection()
    {
        if (realtimeSpeed != moveSpeed || transform.localRotation != Quaternion.Euler(Vector3.zero))
        {
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            realtimeSpeed = moveSpeed;
        }        
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
