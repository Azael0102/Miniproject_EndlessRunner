using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;  // อ้างอิง AudioSource
    public AudioClip introClip;      // เพลงเริ่มต้น (เล่นครั้งเดียว)
    public AudioClip loopClip;       // เพลงลูป (วนไปเรื่อยๆ)

    private void Start()
    {
        // เริ่มเล่นเพลง Intro ก่อน
        audioSource.clip = introClip;
        audioSource.loop = false; // ไม่ให้ Intro ลูป
        audioSource.Play();

        // ตั้งเวลาให้เปลี่ยนเป็นเพลง Loop ต่อทันทีที่ Intro จบ
        Invoke(nameof(PlayLoop), introClip.length);
    }

    private void PlayLoop()
    {
        audioSource.clip = loopClip;
        audioSource.loop = true; // ลูปเพลงนี้ไปเรื่อยๆ
        audioSource.Play();
    }
}
