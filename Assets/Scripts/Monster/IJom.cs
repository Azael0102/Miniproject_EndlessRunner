using UnityEngine;
using UnityEngine.SceneManagement;

public class BackwardMonster : MonoBehaviour
{
    public float moveSpeed = 5f;          // ความเร็วในการถอยหลัง
    public float distanceDespawn = 200f;  // ระยะที่จะลบตัวเอง

    private Transform player;             // อ้างอิง Player

    void Start()
    {
        // หาตัว Player ด้วย Tag 
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        // ให้มันเดินหลับหลัง
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // เช็คระยะห่างจาก Player ถ้าเกินระยะที่กำหนดให้ลบตัวเอง(ในที่นี้คือ 200 เมตร)
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > distanceDespawn)
            {
                Destroy(gameObject); // ลบมอนสเตอร์ทิ้ง
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // โหลด Scene ที่กำหนด
            //SceneManager.LoadScene("SampleScene");
            FindObjectOfType<DeadMenu>().Dead();
            //โดน player คือตาย
        }
    }
}
