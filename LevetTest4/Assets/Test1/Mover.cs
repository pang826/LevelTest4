using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Vector3 moveDir;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(x, 0, z);
        transform.Translate(transform.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(transform.right * -x * moveSpeed * Time.deltaTime);
        transform.LookAt(transform.position + moveDir * Time.deltaTime);
    }
}
