using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBoard : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 30.0f;

    public int point = 10;
    public Text pointText;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 推動第一人稱物件
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("12345");
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("56789");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Bullet")
        {
            point -= 1;
            pointText.text = point.ToString();
        }
    }
}
