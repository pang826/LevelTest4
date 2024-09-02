using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_test6 : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Vector3 moveDir;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Monster")
        // collision.collider.gameObject == GameObject.FIndGameObjectWihtTag("Monster")�� �������� ���� ù��° ���͸� �����ϰ�� ����� ������� �ʾҴ�.
        // ��ó�� �ٲٴ� ��� ���ͷκ��� ����� �۵��Ǿ���.
        {
            gameObject.SetActive(false);
            Debug.Log("���� ����");
        }
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(x, 0, z);
        transform.Translate(transform.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(transform.right * -x * moveSpeed * Time.deltaTime);
        transform.LookAt(transform.position + moveDir * Time.deltaTime);
    }
}
