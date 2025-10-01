using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] segments;         // �� prefab ���
    public Transform player;              // ����к� player �����礵��˹�
    public float segmentLength = 135f;    // ������ҧ��������ѹ�����͹�ѹ
    public float despawnDistance = 300f;  // ������ҧ����ź������

    private float nextZ = 0f;   //᡹ Z ���� spawn ������� �ѹ�������������
    private List<GameObject> activeSegments = new List<GameObject>(); // �������� spawn �͡������

    void Start()
    {
        //spawn ����á spawn ��������
        SpawnStartSegment();
        //���� spawn �����ҹ˹�� ��Ш� spawn �������� player ��� trigger
        SpawnSegment();
    }

    public void SpawnStartSegment()
    {
        GameObject startSeg = Instantiate(segments[0], new Vector3(0, 0, nextZ), Quaternion.identity); //spawn ����á��� index 0(���˹� player)
        activeSegments.Add(startSeg); //����������� �ѹ spawn ���ź�ѹ��
        nextZ += segmentLength; //+ ������������ �ѹ�����͹�ѹ
    }

    public void SpawnSegment()
    {
        // ���� ��� ¡��� ����á
        int index = Random.Range(1, segments.Length);
        GameObject newSeg = Instantiate(segments[index], new Vector3(0, 0, nextZ), Quaternion.identity);
        activeSegments.Add(newSeg);
        nextZ += segmentLength;

        // ź ��� ��ҷ��������ҧ�Թ
        DespawnSegments();
    }

    void DespawnSegments()
    {
        for (int i = activeSegments.Count - 1; i >= 0; i--) //�������������
        {
            if (player.position.z - activeSegments[i].transform.position.z > despawnDistance) //��� player ��ҧ�ҡ����Թ���з���˹�ź��駡ѹ�Ť
            {
                Destroy(activeSegments[i]);
                activeSegments.RemoveAt(i);
            }
        }
    }
}
