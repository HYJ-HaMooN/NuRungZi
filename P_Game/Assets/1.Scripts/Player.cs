using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;   // ���� �� ���Ǵ� źȯ�Դϴ�.

    public Text atkCount;       // ���ù�ư�� Max ī��Ʈ�� �ΰ��ӿ��� ������ �� �ִ� Text�Դϴ�. (�ӽ��ڵ��Դϴ�. ���� ���� ����)

    int maxAttackCount;         // ���ù�ư�� ���� Max ī��Ʈ �� �Դϴ�.
    int numOfCount;             // ī��Ʈ�� �Ѿ Ƚ���Դϴ�.
    public Enemy enemy;
    void Start()
    {
        maxAttackCount = 1;
        numOfCount = 1;
       
    }

    public void AttackButton()  // ���ݹ�ư�� ���õ� �ڵ��Դϴ�.
    {
        if (maxAttackCount == 1)
        {
            numOfCount++;

            maxAttackCount += numOfCount;
            Attack();
        }

        maxAttackCount--;

        atkCount.text = maxAttackCount.ToString();
    }

    public void Attack()
    {        
       var bt = Instantiate(bullet,new Vector3(gameObject.transform.position.x+0.4f, gameObject.transform.position.y+1f, gameObject.transform.position.z), Quaternion.identity);          // bullet(Prefab)�� �����մϴ�.
       
    }
}
