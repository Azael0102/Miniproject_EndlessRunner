using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] Monsters;    // ���͹��������ͧ��� spawn �� list
    public float[] spawnWeights;     // �͡���Դ�ͧ�͹��������е��
    public Transform Player;         // �������礵��˹� Player
    public float spawnDistance = 50f;  // ���� spawn ��ҹ˹��
    public float spawnHeight = 1f;     // �����٧�͹ spawn ���ç�����ؾ��
    public float spawnInterval = 2f;   // ����㹡������ spawn ��� 2 ���͡�ҵ�� 1
    private float timer; // �Ѻ�������

    void Update()
    {
        timer += Time.deltaTime; //�Ѻ�����������ҹ������ frame

        if (timer >= spawnInterval) //��������Ҽ�ҹ��ҡ���� 2 �� spawn monster ���������Ѻ time ����
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        int index = GetWeightedRandomIndex(); // ���� Index spawn monster

        Vector3 spawnPosition = Player.position + Player.forward * spawnDistance; //�礵��˹� player ���� spawn ��ҹ˹��
        spawnPosition.y += spawnHeight; // + Y ����٧��鹨ҡ��� �ѹ���ؾ��

        // spawn monster ����������ҹ˹�� player
        GameObject newMonster = Instantiate(Monsters[index], spawnPosition, Quaternion.identity); 
    }

    int GetWeightedRandomIndex()
    {
        float totalWeight = 0f; //�纵���Ţ monster �����㹡������
        foreach (float weight in spawnWeights)
            totalWeight += weight;

        float randomValue = Random.Range(0, totalWeight); //�����Ţ
        float cumulativeWeight = 0f;

        // �� index ���� spawn �����Ţ�����������º�Ѻ�͡���Դ monster ���е��
        for (int i = 0; i < spawnWeights.Length; i++)
        {
            cumulativeWeight += spawnWeights[i];
            if (randomValue < cumulativeWeight) // �͡���Դ�������Ţ�����§�Ѻ monster ����˹������͡���Դ��ǹ���ҡ����
                return i;
        }

        return 0; // �ѹ error ���
    }
}
