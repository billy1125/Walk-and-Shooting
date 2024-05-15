using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Æg¿ª≥]©w")]
    public float shootingForce = 10.0f;
    public GameObject shootingPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
