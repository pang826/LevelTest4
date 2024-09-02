using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterTrace_test6 : MonoBehaviour
{
    [SerializeField]
    GameObject player; // 따라갈 플레이어 오브젝트
    [SerializeField]
    Rigidbody rigid; // 리지드바디 입력
    [SerializeField]
    LayerMask layerMask; // 인식할 레이어마스크
    [SerializeField]
    float moveSpeed; // 속도

    float detectiveDistance; // 인식거리 (여기선 25m)
    
    
    Vector3 spawnPoint; // 몬스터 스폰장소(랜덤용)
    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        detectiveDistance = 25;
        spawnPoint = new Vector3(Random.Range(-18, 18), 0, Random.Range(-18, 18));
        Spawn();
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
            Debug.DrawRay(transform.position, transform.forward*detectiveDistance, Color.red);
        }
    }
    void Spawn()
    {
        transform.position = spawnPoint;
    }
}
