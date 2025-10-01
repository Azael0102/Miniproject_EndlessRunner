using UnityEngine;
using UnityEngine.SceneManagement;

public class Creamraku : MonoBehaviour
{
    public Transform player;
    public float DistanceDespawn = 200f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position); //�������ҧ�ҡ player ������� ����Թ 200 despawn
        if (distance > DistanceDespawn)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("MainMenu");

            FindObjectOfType<DeadMenu>().Dead();

            //ⴹ player ��͵��
        }
    }
}
