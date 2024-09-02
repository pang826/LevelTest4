using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_test3 : MonoBehaviour
{
    [SerializeField]
    bullet_test3 frefab;
    [SerializeField]
    Transform shootPoint;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        bullet_test3 bullet = Instantiate(frefab, shootPoint.position, shootPoint.rotation);
    }
}
