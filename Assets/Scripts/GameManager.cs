using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("�ѦҪ���")]
    public Transform EnemyInstantiatePoint;

    [Header("�w�m����")]
    public float spawnInterval = 1f; // �ͦ����j�ɶ�
    public float maxRotation = 45f; // �̤j���ਤ��
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

    // �ͦ����󪺨��
    void SpawnObject()
    {
        // �H���ͦ����ਤ��
        //float randomRotation = Random.Range(-maxRotation, maxRotation);
        //Quaternion rotation = Quaternion.Euler(0f, randomRotation, 0f);

        float randomX = Random.Range(-2.0f, 3.0f);
        // �ͦ�����������H������
        GameObject spawnedObject = Instantiate(Enemy, EnemyInstantiatePoint.position + new Vector3(randomX, 0, 0), Quaternion.identity);
    }
}
