using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 25f;             // ความเร็ว Player
    public float horizontalSpeed = 15f;   // ความเร็วขยับซ้าย-ขวา
    public float rightLimit = 11f;  // ขอบเขตขยับไปขวา
    public float leftLimit = -11f;  //ขอบเขตขยับไปซ้าย
    public float slowSpeed = 1f;       // ลดความเร็วลงเหลือ 1 ไว้ใช้เมื่อชนสิ่งกีดขวาง
    public float slowDuration = 1f;      // ระยะเวลาที่ความเร็วลดลง

    private float currentSpeed; //ความเร็วที่ใช้งานในเกมจริง
    private bool isSlowed = false; //ไว้ใช้เช็คว่าชนของไหมจะได้ไม่ชนซ้ำ

    void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        // เดินไปข้างหน้า
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.World);

        // เลี้ยวซ้าย
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime, Space.World);
            }
        }

        // เลี้ยวขวา
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    // เช็คชนของ
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !isSlowed) //เช็คการชนด้วย tag และไม่ชนของอื่นอยู่
        {
            StartCoroutine(SlowDown());
        }
    }

    private System.Collections.IEnumerator SlowDown()
    {
        isSlowed = true;    //Player ชนของ
        currentSpeed = slowSpeed; // ลดความเร็วผู้เล่นลงตามค่า slowspeed
        yield return new WaitForSeconds(slowDuration); // ระยะเวลาที่สถานะอยู่ ตามค่า slowDuration
        currentSpeed = speed; // กลับมาเร็วเท่าเดิม
        isSlowed = false; //กลับมา false เพื่อให้ชนของได้อีก
    }
}

