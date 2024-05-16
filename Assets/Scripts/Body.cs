using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body: MonoBehaviour
{
    [Header("�ͩR�]�w")]
    public int maxLife = 10;

    [Header("�g���]�w")]
    public float shootingForce = 10.0f;
    public GameObject shootingPoint;
    public GameObject bullet;

    public int healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, shootingPoint.transform.position, Quaternion.identity);
        currentBullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, shootingForce), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthPoints -= 1;
            if (healthPoints < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
