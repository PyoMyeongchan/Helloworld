using UnityEngine;


//�Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�.
//���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
//����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.
public class PlayerController : MonoBehaviour
{
    public GameObject missle;
    public Transform[] fire;
    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;


    void Awake()
    {
        fire = transform.Find("fire").GetComponentsInChildren<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        //velocity => vector ũ��� ����
        //s = v * t => speed * direction * time 

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        //������ǥ��, ���� ��ǥ��
        //������ ������
        //transform.position += transform.up * v * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed);
        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;


        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < fire.Length; i++)
            {
                Instantiate(missle, fire[i].transform.position, fire[i].transform.rotation);
            }

        
        }
    }
}
