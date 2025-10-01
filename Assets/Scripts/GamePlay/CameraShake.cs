using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform player;              // กล้องตามตัว
    public float bobbingSpeed = 5f;       // ความเร็วการสั่นกล้อง
    public float bobbingAmount = 0.05f;   // ความแรงสั่น
    public float tiltAmount = 10f;        // เอียงซ้ายขวา
    public float tiltSpeed = 5f;          // ความเร็วเอียง
    public float turnSpeed = 5f;          // ความเร็วในการหมุนกลับหลัง

    private float timer = 0f;
    private Quaternion originalRotation; //เก็บตำแหน่งเดิมของกล้อง
    private bool isLookingBack = false;   // เช็คว่ากล้องหันหลังอยู่หรือไม่

    void Start()
    {
        originalRotation = transform.localRotation; //เก็บตำแหน่งเดิมของกล้อง
    }

    void Update()
    {
        // กด F เพื่อหันหลัง
        if (Input.GetKeyDown(KeyCode.F))
        {
            isLookingBack = !isLookingBack; //เช็คว่าหันหลังอยู่
        }

        // Camera Shake 
        if (player != null)
        {
            timer += Time.deltaTime * bobbingSpeed; //กล้องสั่นตามเวลาทุก frame
            float bobbing = Mathf.Sin(timer) * bobbingAmount; //กล้องสั่นขึ้นลง

            // ให้กล้องตามตำแหน่ง player และสั่นไปด้วย
            transform.position = player.position + new Vector3(0, 1 + bobbing, 0);
        }

        // กล้องเอียง
        float horizontal = Input.GetAxis("Horizontal"); //รับค่าจากปุ่ม A,D หรือ ลูกศรซ้ายขวา
        float targetZ = -horizontal * tiltAmount; //คูณค่าที่รับมาเพื่อให้กล้องเอียงตาม

        Quaternion baseRotation = originalRotation; // ตำแหน่งเดิมกล้อง

        // เช็คหันหลัง
        if (isLookingBack)
        {
            baseRotation *= Quaternion.Euler(0, 180, 0); //ถ้ากด F หันหลังปรับค่า Y ของกล้องเป็น 180
        }
        // หมุนกล้องไปตำแหน่งที่ต้องการซึ่งก็คือหันหลัง(Y = 180)
        Quaternion targetRotation = Quaternion.Euler(baseRotation.eulerAngles.x, baseRotation.eulerAngles.y, targetZ);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * tiltSpeed * turnSpeed); 
        //เพิ่ม deltaTime เพื่อให้การหมุนกล้องนุ่มนวลขึ้น
    }
}

