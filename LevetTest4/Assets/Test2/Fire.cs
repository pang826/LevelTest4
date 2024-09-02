using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    bullet frefab;
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
        bullet bullet = Instantiate(frefab, shootPoint.position, shootPoint.rotation);
    }
}
