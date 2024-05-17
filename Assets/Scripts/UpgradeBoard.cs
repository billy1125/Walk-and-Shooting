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
}
