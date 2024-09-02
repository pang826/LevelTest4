using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_test3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
