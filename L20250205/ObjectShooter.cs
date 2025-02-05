using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ObjectShooter : MonoBehaviour
{
    // �߻� ����� �������ִ� Ŭ����
    // �浹 �� ������Ʈ�� ���������ִ� ���ҵ� �����մϴ�.
    GameObject ObjectGenarate;
    ObjectGenarate obj;
    
    private void Start()
    {
        ObjectGenarate = GameObject.Find("ObjectGenarate");
        //������ �ش� �̸��� ���� ���ӿ�����Ʈ�� ã�� �� ���� ������ GameObject.Find ���
        //ObjectGenarate = GameObject.FindWithTag("Generate") // Generate �±׸� ���� ������Ʈ�� Ž��
        //obj = FindObjectOfType<ObjectGenarate>(); < >�ȿ� �־��� Ÿ�Կ� �´� ������Ʈ�� Ž��

        //���� ���� �� Find()
        //������ �˻� ������ �ʹ� �������� ���ʿ��ϰ� ���� ���ϰ� �߻��� �� ����.
        //���� �׶����� Tag�� Type ������ �˻������� �����ؼ� ã�� ����� ���

        //���� �ش� ���� ���ٸ� null

    }

    /// <summary>
    /// ��ü�� �߻��ϴ� ����� ���� �Լ�(�޼ҵ�)
    /// </summary>
    /// <param name="direction">��ü�� �߻� ����</param>

    public void Shoot(Vector3 direction)
    { 
        GetComponent<Rigidbody>().AddForce(direction);
       
                    
    }
    



    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if (collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
            Debug.Log("����!");
        }
        else //������ ���
        {
            ObjectGenarate.GetComponent<ObjectGenarate>().ScorePlus(10);
            Debug.Log("����!");
        }

    }

}
