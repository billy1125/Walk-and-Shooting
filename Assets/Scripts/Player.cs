using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed;

    [Header("身體產生設定")]
    public GameObject body;
    public List<Body> bodyList = new List<Body>();
    [System.Serializable]
    public struct Body
    {
        public Vector3 localLocation;
        public GameObject bodyObject;
    }

    private Rigidbody rbFirstPerson; // 第一人稱物件(膠囊體)的剛體

    private float horizontalInput;   // 左右方向按鍵的數值(-1 <= X <= +1)
    private float verticalInput;     // 上下方向按鍵的數值(-1 <= Y <= +1)

    private Vector3 moveDirection;   // 移動方向

    // Start is called before the first frame update
    void Start()
    {
        //rbFirstPerson = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckForMissingReferences() > 0)
        {
            MyInput();
        }
        else
        {
            //this.gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
    }
        
    private void FixedUpdate()
    {
        MovePlayer();
        float newX = Mathf.Clamp(transform.position.x, -2.35f, 2.35f);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // 計算移動方向(其實就是計算X軸與Z軸兩個方向的力量)
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        //rbFirstPerson.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    private int CheckForMissingReferences()
    {
        int numbers = 0;

        for (int i = 0; i < bodyList.Count; i++)
        {
            if (bodyList[i].bodyObject != null)
                numbers += 1;
        }

        return numbers;
    }

    private void OnTriggerEnter(Collider other)
    {
        UpgradeBoard upgradeBoard = other.gameObject.GetComponent<UpgradeBoard>();

        if (other.gameObject.tag == "Bonus" && upgradeBoard != null)
        {
            GenerateObject();
            //Debug.Log(upgradeBoard.point.ToString());
        }
    }

    void GenerateObject()
    {
        //// 在球形范围内生成随机位置
        //Vector3 randomPosition = Random.insideUnitSphere * radius;

        //// 将Y轴设为0以确保在平面上生成
        //randomPosition.y = 0f;

        //// 将位置从本地坐标系转换为世界坐标系
        //Vector3 worldPosition = playerObject.transform.position + randomPosition;
        foreach (var item in bodyList)
        {
            if (item.bodyObject == null)
            {
                GameObject newObject = Instantiate(body, Vector3.zero, Quaternion.identity);
                newObject.transform.parent = this.transform;
                newObject.transform.localPosition = item.localLocation;
            }
        }
        //// 在计算出的位置生成物体
       

        //// 将生成的物体设置为特定物体的子物体
        //newObject.transform.parent = playerObject.transform;
    }
}
