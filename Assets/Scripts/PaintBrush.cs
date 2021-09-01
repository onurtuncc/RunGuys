using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PaintBrush : MonoBehaviour
{
    public GameObject brush;
    [SerializeField] private Transform brushParent;
    [SerializeField] private TMP_Text percentageText;
    [SerializeField] private GameObject completedPanel;
    private float brushSize = 0.25f;
    private int percentage = 0;
    private string displayText = "%{0} Paınted";
    
    private void Start()
    {
        percentageText.text = string.Format(displayText, percentage);
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                if (hit.collider.tag != "Wall") return;
                if (hit.collider.gameObject.layer == 8)
                {
                    percentage += 1;
                    percentageText.text = string.Format(displayText, percentage);
                    hit.collider.gameObject.layer = 0;
                    if (percentage == 100)
                    {
                        completedPanel.SetActive(true);
                    }
                    
                }
                var paint = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(-90,0,0), brushParent);
                paint.transform.localScale = Vector3.one * brushSize;
                paint.transform.localPosition -= Vector3.forward * (hit.collider.transform.position.z-brushParent.position.z);
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
}
