using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] Monsters;    // เก็บมอนสเตอร์ที่ต้องการ spawn เป็น list
    public float[] spawnWeights;     // โอกาสเกิดของมอนสเตอร์แต่ละตัว
    public Transform Player;         // เอาไว้เช็คตำแหน่ง Player
    public float spawnDistance = 50f;  // ระยะ spawn ด้านหน้า
    public float spawnHeight = 1f;     // ความสูงตอน spawn ให้ตรงไม่ทะลุพื้น
    public float spawnInterval = 2f;   // เวลาในการสุ่ม spawn คือ 2 วิออกมาตัว 1
    private float timer; // นับเวลาในเกม

    void Update()
    {
        timer += Time.deltaTime; //นับเวลาในเกมที่ผ่านไปในแต่ละ frame

        if (timer >= spawnInterval) //เมื่อเวลาผ่านไปมากกว่า 2 วิ spawn monster และเริ่มนับ time ใหม่
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        int index = GetWeightedRandomIndex(); // สุ่ม Index spawn monster

        Vector3 spawnPosition = Player.position + Player.forward * spawnDistance; //เช็คตำแหน่ง player เพื่อ spawn ด้านหน้า
        spawnPosition.y += spawnHeight; // + Y ให้สูงขึ้นจากพื้น กันทะลุพื้น

        // spawn monster ที่สุ่มได้ด้านหน้า player
        GameObject newMonster = Instantiate(Monsters[index], spawnPosition, Quaternion.identity); 
    }

    int GetWeightedRandomIndex()
    {
        float totalWeight = 0f; //เก็บตัวเลข monster ไว้ใช้ในการสุ่ม
        foreach (float weight in spawnWeights)
            totalWeight += weight;

        float randomValue = Random.Range(0, totalWeight); //สุ่มเลข
        float cumulativeWeight = 0f;

        // หา index ที่จะ spawn โดยใช้เลขที่สุ่มมาเทียบกับโอกาสเกิด monster แต่ละตัว
        for (int i = 0; i < spawnWeights.Length; i++)
        {
            cumulativeWeight += spawnWeights[i];
            if (randomValue < cumulativeWeight) // โอกาสเกิดโดยสุ่มเลขใกล้เคียงกับ monster ตัวไหนก็จะมีโอกาสเกิดตัวนั้นมากกว่า
                return i;
        }

        return 0; // กัน error เฉยๆ
    }
}
