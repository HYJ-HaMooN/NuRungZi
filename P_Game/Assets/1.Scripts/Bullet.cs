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
    private bool IsStart;           // ���� ������ üũ�մϴ�. ���� ���� �Ǵ� ���ŵ� �� �ִ� �ڵ��Դϴ�.

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Dummy").transform;               // target�� Vector ���� Enemy(Tag)�� ��ǥ�� �����մϴ�.
        StartPosition = transform.position;                                         // Bullet�� ó�� ��ġ�Դϴ�.
       // enemyHp = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        gameObject.transform.Rotate(0,0,-Time.deltaTime*rotateSpeed,Space.Self);    // ������Ʈ�� ȸ����ŵ�ϴ�.

        if (target != null)  // Ÿ�� ������Ʈ(Enemy)�� �ִٸ�
        {
            IsStart = true; // IsStart�� true�� �����մϴ�.
        }
        else
            return;

        if (IsStart)         // ���� �ִٸ�
        {
            // �Ʒ��� ��� ������ �����Դϴ�.
            // ������Ʈ �Լ��� �ּ����� �����ϸ� ������Ʈ�� ȸ������ �ʰ� Enemy������ ���� ���ư��ϴ�.(�ޱ׸�����ó��)

            float x0 = StartPosition.x;
            float x1 = target.position.x;
            float distance = x1 - x0;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, Speed * Time.deltaTime);
            float baseY = Mathf.Lerp(StartPosition.y, target.position.y, (nextX - x0) / distance);
            float arc = HeightArc * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);

            Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);
            //transform.rotation = LookAt2D(nextPosition - transform.position);

            transform.position = nextPosition;

            if (nextPosition == target.position)
                Destroy(gameObject);
        }


        /*Quaternion LookAt2D(Vector2 forward)
        {
            return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<Player>().enemy.maxHp -= damage;
            
            //enemyHp.maxHp -= damage;

           // Debug.Log(enemyHp.maxHp);

            Destroy(gameObject);
        }
    }
}

