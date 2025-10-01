using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;  // ��ҧ�ԧ AudioSource
    public AudioClip introClip;      // �ŧ������� (��蹤�������)
    public AudioClip loopClip;       // �ŧ�ٻ (ǹ��������)

    private void Start()
    {
        // ���������ŧ Intro ��͹
        audioSource.clip = introClip;
        audioSource.loop = false; // ������ Intro �ٻ
        audioSource.Play();

        // ��������������¹���ŧ Loop ��ͷѹ�շ�� Intro ��
        Invoke(nameof(PlayLoop), introClip.length);
    }

    private void PlayLoop()
    {
        audioSource.clip = loopClip;
        audioSource.loop = true; // �ٻ�ŧ�����������
        audioSource.Play();
    }
}
