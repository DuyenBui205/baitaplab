using UnityEngine; // Nhúng thư viện Unity cơ bản, chứa các lớp như MonoBehaviour, Transform,...

// Script dùng để Camera theo dõi đối tượng (ví dụ: Player)
public class FollowCamera : MonoBehaviour
{
    public Transform target; // Đối tượng mà camera sẽ theo dõi (thường là nhân vật người chơi)
    public Vector3 offset = new Vector3(0, 5, -10); // Độ lệch của camera so với đối tượng

    // LateUpdate được gọi sau Update – đảm bảo camera cập nhật sau khi player di chuyển
    void LateUpdate()
    {
        // Đặt vị trí camera tại vị trí target cộng thêm offset
        transform.position = target.position + offset;

        // Camera luôn hướng về đối tượng target
        transform.LookAt(target);
    }
}
