using UnityEngine; // Thư viện chính của Unity – chứa các lớp quan trọng như MonoBehaviour, AudioSource, AudioClip

// Khai báo class SoundManager kế thừa từ MonoBehaviour – để gắn vào GameObject
public class SoundManager : MonoBehaviour
{
    // Các biến public kiểu AudioClip để gán file âm thanh từ Unity Editor
    public AudioClip jumpSound;   // Âm thanh khi nhân vật nhảy
    public AudioClip shootSound;  // Âm thanh khi bắn
    public AudioClip winSound;    // Âm thanh khi chiến thắng

    // Biến private dùng để lưu thành phần AudioSource (thành phần phát âm)
    private AudioSource audioSource;

    // Hàm Start() sẽ được Unity tự động gọi khi game chạy
    void Start()
    {
        // Lấy AudioSource gắn trên GameObject này và lưu vào biến audioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Hàm công khai để phát âm thanh nhảy
    public void PlayJump()
    {
        // Phát âm jumpSound 1 lần mà không ảnh hưởng âm khác đang chạy
        audioSource.PlayOneShot(jumpSound);
    }

    // Hàm công khai để phát âm thanh bắn
    public void PlayShoot()
    {
        // Phát âm shootSound 1 lần
        audioSource.PlayOneShot(shootSound);
    }

    // Hàm công khai để phát âm thanh chiến thắng
    public void PlayWin()
    {
        // Phát âm winSound 1 lần
        audioSource.PlayOneShot(winSound);
    }
    // Hàm công khai để thay đổi âm lượng của AudioSource
    public void SetSFXVolume(float volume)
    {
        audioSource.volume = volume; // Gán âm lượng mới cho AudioSource
    }

}
