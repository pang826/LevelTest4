using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterTrace_test6 : MonoBehaviour
{
    [SerializeField]
    GameObject player; // ���� �÷��̾� ������Ʈ
    [SerializeField]
    Rigidbody rigid; // ������ٵ� �Է�
    [SerializeField]
    LayerMask layerMask; // �ν��� ���̾��ũ
    [SerializeField]
    float moveSpeed; // �ӵ�

    float detectiveDistance; // �νİŸ� (���⼱ 25m)
    
    
    Vector3 spawnPoint; // ���� �������(������)
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
        transform.LookAt(target.transform.position); // ���⼱ �׳� ��� �÷��̾ �Ĵٺ������ϰ� ���� ���ӿ����� �ֺ��� �����ϴ� �������� �ϸ� �ɵ�
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, detectiveDistance, layerMask))
        {
            Debug.Log($"{hit.collider.name} �߰�!");
            if(hit.collider.gameObject == target)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            // else if�� wall�� �߰��ϸ� �ٽ� �ֺ��� Ž���ϴ� ��ɾ ������ �� �� ����.
        }
        else
        {
            // �ν��� �� �� ��� Ȯ�ο� ��ο췹��
            Debug.DrawRay(transform.position, transform.forward*detectiveDistance, Color.red);
        }
    }
    void Spawn()
    {
        transform.position = spawnPoint;
    }
}
