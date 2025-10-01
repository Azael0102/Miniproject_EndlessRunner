using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] segments;         // เก็บ prefab แมพ
    public Transform player;              // ไว้ระบุ player เพื่อเช็คตำแหน่ง
    public float segmentLength = 135f;    // ความห่างแต่ละแมพกันแมพซ้อนกัน
    public float despawnDistance = 300f;  // ระยะห่างที่จะลบแมพเก่า

    private float nextZ = 0f;   //แกน Z ที่จะ spawn แมพใหม่ กันไม่ให้แมพเอ๋อ
    private List<GameObject> activeSegments = new List<GameObject>(); // เก็บแมพที่ spawn ออกมาแล้ว

    void Start()
    {
        //spawn แมพแรก spawn ครั้งเดียว
        SpawnStartSegment();
        //สุ่ม spawn แมพด้านหน้า และจะ spawn ต่อเมื่อ player เข้า trigger
        SpawnSegment();
    }

    public void SpawnStartSegment()
    {
        GameObject startSeg = Instantiate(segments[0], new Vector3(0, 0, nextZ), Quaternion.identity); //spawn แมพแรกที่ index 0(ตำแหน่ง player)
        activeSegments.Add(startSeg); //และเก็บแมพไว้ กัน spawn และลบทันที
        nextZ += segmentLength; //+ ระยะไปเรื่อยๆ กันแมพซ้อนกัน
    }

    public void SpawnSegment()
    {
        // สุ่ม แมพ ยกเว้น แมพแรก
        int index = Random.Range(1, segments.Length);
        GameObject newSeg = Instantiate(segments[index], new Vector3(0, 0, nextZ), Quaternion.identity);
        activeSegments.Add(newSeg);
        nextZ += segmentLength;

        // ลบ แมพ เก่าที่อยู่ห่างเกิน
        DespawnSegments();
    }

    void DespawnSegments()
    {
        for (int i = activeSegments.Count - 1; i >= 0; i--) //เช็คแมพที่เก็บไว้
        {
            if (player.position.z - activeSegments[i].transform.position.z > despawnDistance) //ถ้า player ห่างจากแมพเกินระยะที่กำหนดลบทิ้งกันแลค
            {
                Destroy(activeSegments[i]);
                activeSegments.RemoveAt(i);
            }
        }
    }
}
