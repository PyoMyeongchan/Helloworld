using UnityEngine;


// 입력이나 다른 이벤트를 처리한다.
// 현재 게임 오브젝트에 다른 컴포넌트에 명령을 내린다.
// 사용자 컴포넌트는 한가지 일만 해야 된다.

public class PlayerController : MonoBehaviour
{
    //Transform playerTransform;

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;

    void Awake()
    {
        //playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 로컬좌표계 / 월드 좌표계

        //transform.position += transform.up * v * Time.deltaTime * moveSpeed ; // 초당
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed, Space.Self); // 자기자신기준)                                                                             

        transform.eulerAngles += transform.forward * h * Time.deltaTime * rotationSpeed;
 

        // 거리 = 속도 * 시간 / s = v * t = > speed * direction * time
        // velocity = vector 크기랑 방향


        // if (Input.GetKey(KeyCode.UpArrow))
        //{ 
        //   transform.position += new Vector3(0, 1, 0) * Time.deltaTime; // 초당
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //  transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
        //}



    }
}
