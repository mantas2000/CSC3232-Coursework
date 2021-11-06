using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GroundEnemySM GroundEnemySm;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Collision with player
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Roll") && controller.IsGrounded())
            {
                // Enemy dies
                gameObject.SetActive(false);
            }
            
            else if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Crouch") && !controller.IsGrounded())
            {
                // Enemy dies
                gameObject.SetActive(false);
            }
            
            else if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump") && !controller.IsGrounded())
            {
                // Stun enemy
                GroundEnemySm.ChangeState(GroundEnemySm.StuntState);
            }
            
            else
            {
                // Player dies, restart level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
