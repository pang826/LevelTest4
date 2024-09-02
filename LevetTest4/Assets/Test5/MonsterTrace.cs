using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterTrace : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    float detectiveDistance;
    float moveSpeed;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    Rigidbody rigid;
    private void Awake()
    {
        detectiveDistance = 5;
        moveSpeed = 1f;
    }
    private void Update()
    {
        Trace(player);
    }
    public void Trace(GameObject target)
    {
        transform.LookAt(target.transform.position); // 여기선 그냥 계속 플레이어를 쳐다보도록하고 실제 게임에서는 주변을 정찰하는 느낌으로 하면 될듯
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, detectiveDistance, layerMask))
        {
            Debug.Log($"{hit.collider.name} 발견!");
            if(hit.collider.gameObject == target)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            // else if로 wall를 발견하면 다시 주변을 탐색하는 명령어를 넣으면 될 것 같다.
        }
        else
        {
            // 인식을 못 할 경우 확인용 드로우레이
            Debug.DrawRay(transform.position, transform.forward*5, Color.red);
        }
    }
}
