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
        // collision.collider.gameObject == GameObject.FIndGameObjectWihtTag("Monster")로 했을때는 가장 첫번째 몬스터를 제외하고는 기능이 적용되지 않았다.
        // 위처럼 바꾸니 모든 몬스터로부터 기능이 작동되었다.
        {
            gameObject.SetActive(false);
            Debug.Log("게임 오버");
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
