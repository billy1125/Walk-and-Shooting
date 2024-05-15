using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("參考物件")]
    public Transform EnemyInstantiatePoint;

    [Header("預置物件")]
    public float spawnInterval = 1f; // 生成間隔時間
    public float maxRotation = 45f; // 最大旋轉角度
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 生成物件的函數
    void SpawnObject()
    {
        // 隨機生成旋轉角度
        //float randomRotation = Random.Range(-maxRotation, maxRotation);
        //Quaternion rotation = Quaternion.Euler(0f, randomRotation, 0f);

        float randomX = Random.Range(-2.0f, 3.0f);
        // 生成物件並應用隨機旋轉
        GameObject spawnedObject = Instantiate(Enemy, EnemyInstantiatePoint.position + new Vector3(randomX, 0, 0), Quaternion.identity);
    }
}
