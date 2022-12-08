using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSalto : MonoBehaviour
{
    public Collider2D enemigo;
    public Animator animator;
    public SpriteRenderer sprite;

    public GameObject destroyParticle;
    public float jumpforce = 2.5f;
    public int vidas = 1;

    public AudioSource audioSalto;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpforce);
            PerderVida();
            ComprobarVida();
        }
    }

    public void PerderVida() {
        //audioSalto.Play();
        Instantiate(audioSalto);
        vidas--;
        animator.Play("Hit");
    }

    public void ComprobarVida() {
        if (vidas == 0) {
            //destroyParticle.SetActive(true);
            sprite.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie() {
        Destroy(gameObject);
    }
}
