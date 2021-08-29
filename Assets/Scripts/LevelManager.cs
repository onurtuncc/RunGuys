using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SwerveMovement playerMovement;
    private float loadSceneTime = 1.5f;

    private void Awake()
    {
        Instance = this;
    }
    

    public void EndLevel()
    {
        playerMovement.enabled = false;
        playerAnimator.SetTrigger("deadTrigger");
        Invoke("ReplayLevel", loadSceneTime);
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
