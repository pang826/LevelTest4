using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet_test4 : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    float deleteTime;

    [SerializeField]
    Rigidbody rigid;

    Coroutine deleteBullet;

    private void Awake()
    {
        rigid.velocity = transform.forward * bulletSpeed;
        deleteBullet = StartCoroutine(DeleteBullet());
    }

    void OnDestroy()
    {
        StopCoroutine(deleteBullet);
    }

    IEnumerator DeleteBullet()
    {
        WaitForSeconds delay = new WaitForSeconds(deleteTime);
        yield return delay;
        Destroy(gameObject);
    }
}
