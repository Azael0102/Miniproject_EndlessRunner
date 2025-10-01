using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 23f; // ความเร็วในการวิ่ง

    void Update()
    {
        // วิ่งไปข้างหน้า
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ถ้าชน Player ให้โหลด Scene ใหม่
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("SampleScene");
            FindObjectOfType<DeadMenu>().Dead();
            //โดน player คือตาย
        }
    }
}
