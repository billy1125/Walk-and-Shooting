using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("���ʳ]�w")]
    public float moveSpeed;

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
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
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
}
