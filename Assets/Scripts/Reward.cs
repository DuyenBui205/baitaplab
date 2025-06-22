using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1); // tăng 1 điểm 
            Destroy(gameObject); // xóa phần thưởng
        }
    }
}
