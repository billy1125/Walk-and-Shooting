using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("���ʳ]�w")]
    public float moveSpeed;

    [Header("���鲣�ͳ]�w")]
    [SerializeField]
    private List<GameObject> bodyList = new List<GameObject>();

    private Rigidbody rbFirstPerson; // �Ĥ@�H�٪���(���n��)������

    private float horizontalInput;   // ���k��V���䪺�ƭ�(-1 <= X <= +1)
    private float verticalInput;     // �W�U��V���䪺�ƭ�(-1 <= Y <= +1)

    private Vector3 moveDirection;   // ���ʤ�V

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
        // �p�Ⲿ�ʤ�V(���N�O�p��X�b�PZ�b��Ӥ�V���O�q)
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
