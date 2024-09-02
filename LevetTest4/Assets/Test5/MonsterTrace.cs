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
            Debug.DrawRay(transform.position, transform.forward*5, Color.red);
        }
    }
}
