using UnityEngine;
using UnityEngine.SceneManagement;

public class BackwardMonster : MonoBehaviour
{
    public float moveSpeed = 5f;          // ��������㹡�ö����ѧ
    public float distanceDespawn = 200f;  // ���з���ź����ͧ

    private Transform player;             // ��ҧ�ԧ Player

    void Start()
    {
        // �ҵ�� Player ���� Tag 
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        // ����ѹ�Թ��Ѻ��ѧ
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // ��������ҧ�ҡ Player ����Թ���з���˹����ź����ͧ(㹷������ 200 ����)
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > distanceDespawn)
            {
                Destroy(gameObject); // ź�͹�������
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��Ŵ Scene ����˹�
            //SceneManager.LoadScene("SampleScene");
            FindObjectOfType<DeadMenu>().Dead();
            //ⴹ player ��͵��
        }
    }
}
