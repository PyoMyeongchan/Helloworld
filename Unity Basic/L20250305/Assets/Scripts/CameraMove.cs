using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    Transform player;

    public float positionLagTime = 3.0f;
    public float rotationLagTime = 3.0f;
    public float smoothTime = 0.3f;
    public float angleSmoothTime = 0.3f;

    public bool isRotationLag = false;
    public bool isPositionLag = false;

    Quaternion currentRotation;
    Vector3 currnetVelocity;

    public Quaternion saveRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // LateUpdate - 업데이트의 순서를 정해서 부자연스러움을 없앤다. - 카메라보정
    void LateUpdate()
    {
        if (isPositionLag)
        {
            //transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * positionLagTime);
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref currnetVelocity, smoothTime);
        }
        else 
        { 
            transform.position = player.position;
        }

        if (isRotationLag)
        {
            //transform.rotation = CameraMove.SmoothDamp(transform.rotation, player.rotation, ref currentRotation, angleSmoothTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, Time.deltaTime * rotationLagTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            saveRotation = transform.rotation;
        
        }
        if (Input.GetKeyUp(KeyCode.R))
        { 
            transform.rotation = player.rotation;
        }
        

        transform.Rotate(new Vector3(0, Input.mousePositionDelta.x, 0) * 180.0f * Time.deltaTime, Space.World);

        // 마우스휠로 줌인 줌아웃
        float wheelDelta = Input.GetAxisRaw("Mouse ScrollWheel");   
        Vector3 moveDirection = player.position - Camera.main.transform.position;
        Camera.main.transform.Translate(moveDirection.normalized * Time.deltaTime * wheelDelta * 200.0f);


        Debug.DrawLine(transform.position, Camera.main.transform.position,Color.blue);


    }

    // 회전에서의 SmoothDamp

    public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time)
    {
        if (Time.deltaTime < Mathf.Epsilon) return rot;
        // account for double-cover
        var Dot = Quaternion.Dot(rot, target);
        var Multi = Dot > 0f ? 1f : -1f;
        target.x = Multi;
        target.y = Multi;
        target.z = Multi;
        target.w = Multi;
        // smooth damp (nlerp approx)
        var Result = new Vector4(
            Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time),
            Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time),
            Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time),
            Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time)
        ).normalized;

        // ensure deriv is tangent
        var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), Result);
        deriv.x -= derivError.x;
        deriv.y -= derivError.y;
        deriv.z -= derivError.z;
        deriv.w -= derivError.w;

        return new Quaternion(Result.x, Result.y, Result.z, Result.w);
    }

}
