using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //public Text atkCount;       // ���ù�ư�� Max ī��Ʈ�� �ΰ��ӿ��� ������ �� �ִ� Text�Դϴ�. (�ӽ��ڵ��Դϴ�. ���� ���� ����)

    public GameObject bullet;   // ���� �� ���Ǵ� źȯ�Դϴ�.
    public Enemy enemy;

    /*public int maxAttackCount;         // ���ù�ư�� ���� Max ī��Ʈ �� �Դϴ�.
    public int numOfCount;             // ī��Ʈ�� �Ѿ Ƚ���Դϴ�.

    InGameBtnManager Palse;*/

    /*void Start()
    {
        maxAttackCount = 1;
        numOfCount = 1;

        Palse = FindObjectOfType<InGameBtnManager>();
    }*/

    /*private void Update()
    {
        if (!Palse.isPause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (maxAttackCount == 1)
                {
                    numOfCount++;

                    maxAttackCount += numOfCount;

                    // �÷��̾ ������ �� Bullet �������� �����մϴ�.
                    Attack();
                }

                maxAttackCount--;

                atkCount.text = maxAttackCount.ToString();
            }
        }
    }
    */
    public void Attack()
    {        
       var bt = Instantiate(bullet,new Vector3(gameObject.transform.position.x+0.4f, gameObject.transform.position.y+1f, gameObject.transform.position.z), Quaternion.identity);          // bullet(Prefab)�� �����մϴ�.
  
    }
}
