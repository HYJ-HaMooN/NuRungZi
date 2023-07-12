using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    float rotateSpeed = 500f;       // Bullet�� ȸ���ӵ��� �����մϴ�.

    public int damage = 4;                 // bullet�� �������Դϴ�.
    [SerializeField] Transform target;               // target(Enemy)�� transform������ �������� �����Դϴ�.
    public float Speed = 10f;       // Bullet�� �ӵ��Դϴ�.
    public float HeightArc = 1f;    // Bullet�� ��ô�����Դϴ�. (��ġ������ Bullet �����տ� �ν����� â�� �̿����ּ���.)

    private Vector3 StartPosition;  // ������Ʈ ���� ��ġ�� �������ݴϴ�.

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Dummy").transform;               // target = bullet ��������
        StartPosition = transform.position;                                         // bullet ó������
    }

    void Update()
    {
        // bullet ȸ��
        gameObject.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
        // (Enemy)�� �ִٸ� IsStart ����
        if (target != null) { IsStart(); } //else return;
    }

    private void OnTriggerEnter2D(Collider2D collision) // bullet �߻�ü�� enemy �� �浹�� ������ �ı�
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<Enemy>().maxHp -= damage; //HYJ0712 <Player>Ŭ�������� �������� enemy������ <Enemy>Ŭ�������� ���������� �����߽��ϴ�.
            Destroy(gameObject);
        }
    }
    void IsStart()
    {
        float x0 = StartPosition.x;
        float x1 = target.position.x;
        float distance = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, Speed * Time.deltaTime);
        float baseY = Mathf.Lerp(StartPosition.y, target.position.y, (nextX - x0) / distance);
        float arc = HeightArc * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);

        Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);
        transform.position = nextPosition;
    }
}