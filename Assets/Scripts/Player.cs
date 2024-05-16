using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed;

    [Header("身體產生設定")]
    [SerializeField]
    private List<GameObject> bodyList = new List<GameObject>();

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
            if (bodyList[i] != null)
                numbers += 1;
        }

        return numbers;
    }
}
