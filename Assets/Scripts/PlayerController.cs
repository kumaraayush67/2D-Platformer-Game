using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private bool is_grounded;
    private bool is_jumping = false;

    public float speed;
    public float jump;
    public ScoreController scoreController;

    private void Awake() {
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            is_grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            is_grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Respawn"){
            KillPlayer();
        }
    }

    public void PickUpKey(){
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer(){
        Debug.Log("Player Death!");
        SceneManager.LoadScene(1);
    }

    void PlayerMovement(float horizontal, float vertical){
        // Horizontal movement of the player
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Jump Movement
        if (vertical > 0 && is_grounded) {
            rb2d.AddForce(new Vector2(0.0f, jump), ForceMode2D.Force);
        }
    }

    void PlayerAnimation(float horizontal, float vertical){
        // Run and Idle Animation
        if (is_grounded && !is_jumping) {
            animator.SetFloat("speed", Mathf.Abs(horizontal));
        }

        // Rotating the player
        Vector3 scale = transform.localScale;
        if (horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Jump Animation
        if (vertical > 0 && is_grounded) {
            animator.SetBool("jump", true);
            is_jumping = true;
        } else if (is_grounded && is_jumping) {
            animator.SetBool("jump", false);
            is_jumping = false;
        }
    }
}
