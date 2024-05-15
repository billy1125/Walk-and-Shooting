using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpgradeBoard : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 30.0f;

    [Header("產生物件")]
    public string playerTag = "Player";
    public float radius;
    public GameObject body;

    public int point = 10;
    public Text pointText;

    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = point.ToString();
        playerObject = GameObject.FindWithTag(playerTag);
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
        if (other.gameObject.tag == "PlayerBody")
        {
            GenerateObject(playerObject);
        }
    }

    void GenerateObject(GameObject playerObject)
    {
        // 在球形范围内生成随机位置
        Vector3 randomPosition = Random.insideUnitSphere * radius;

        // 将Y轴设为0以确保在平面上生成
        randomPosition.y = 0f;

        // 将位置从本地坐标系转换为世界坐标系
        Vector3 worldPosition = playerObject.transform.position + randomPosition;

        // 在计算出的位置生成物体
        GameObject newObject = Instantiate(body, worldPosition, Quaternion.identity);

        // 将生成的物体设置为特定物体的子物体
        newObject.transform.parent = playerObject.transform;
    }
}
