using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 23f; // ��������㹡�����

    void Update()
    {
        // ���仢�ҧ˹��
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��Ҫ� Player �����Ŵ Scene ����
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("SampleScene");
            FindObjectOfType<DeadMenu>().Dead();
            //ⴹ player ��͵��
        }
    }
}
