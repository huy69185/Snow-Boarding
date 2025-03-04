using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioClip hitSound; // Thay vì AudioSource
    public float blinkDuration = 0.5f;
    public float knockbackForce = 2f;
    public float lifetime = 30f;

    private void Start()
    {
        Invoke(nameof(DestroyBird), lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HearthsController hearts = FindObjectOfType<HearthsController>();
            if (hearts != null)
            {
                // Mất tim trước khi Respawn
                hearts.RemoveHeart();
                hearts.player.Respawn();

                if (hitSound != null)
                {
                    // Phát âm thanh tại vị trí chim va chạm
                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
                }

                StartCoroutine(BlinkEffect(collision.gameObject));

                Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                    playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }

                Destroy(gameObject);
            }
        }
    }

    IEnumerator BlinkEffect(GameObject player)
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            for (int i = 0; i < 5; i++)
            {
                sr.enabled = !sr.enabled;
                yield return new WaitForSeconds(blinkDuration / 10);
            }
            sr.enabled = true;
        }
    }

    private void DestroyBird()
    {
        Destroy(gameObject);
    }
}
