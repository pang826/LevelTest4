using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_test4 : MonoBehaviour
{
    [SerializeField]
    bullet_test4 frefab;
    [SerializeField]
    Transform shootPoint;

    Coroutine autoFire;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            autoFire = StartCoroutine(AutoFire());
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(autoFire);
        }
    }

    void FireBullet()
    {
        bullet_test4 bullet = Instantiate(frefab, shootPoint.position, shootPoint.rotation);
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            WaitForSeconds delay = new WaitForSeconds(0.5f);
            yield return delay;
            FireBullet();
        }
    }
}
