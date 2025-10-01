using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBehindSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;    // มอนสเตอร์ที่จะเกิดด้านหลัง
    public Transform player;            // ตัวผู้เล่น
    public float spawnDistance = 30f;   // ระยะด้านหลังที่จะ spawn
    public float spawnInterval = 5f;    // ช่วงเวลา spawn
    public float monsterSpeed = 10f;    // ความเร็ววิ่งเข้าหา player
    public float despawnDistance = 100f;// ระยะที่จะหายไปเมื่อเกิน player
    public float spawnHeight = 1f;     // ความสูงตอน spawn
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        // หาตำแหน่งด้านหลัง player
        Vector3 spawnPos = player.position - player.forward * spawnDistance;
        spawnPos.y = player.position.y + spawnHeight; // ให้อยู่ระดับเดียวกับ player

        // สร้างมอนสเตอร์
        GameObject monster = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);

        // ให้มอนสเตอร์มีสคริปต์ควบคุมการวิ่ง
        monster.AddComponent<MonsterBehind>().Init(player, monsterSpeed, despawnDistance);
    }
}

public class MonsterBehind : MonoBehaviour
{
    private Transform player;
    private float speed;
    private float despawnDistance;

    public void Init(Transform player, float speed, float despawnDistance) //ระบุตำแหน่ง player
    {
        this.player = player;
        this.speed = speed;
        this.despawnDistance = despawnDistance;
    }

    void Update()
    {
        if (player == null) return;

        // วิ่งตรงไปข้างหน้า
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // ถ้าเกินระยะ player 100 เมตร despawn 
        if (transform.position.z > player.position.z + despawnDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // โหลด Scene ที่กำหนด
            //SceneManager.LoadScene("SampleScene");
            FindObjectOfType<DeadMenu>().Dead(); //โหลดเมนูตาย
        }
    }
}
