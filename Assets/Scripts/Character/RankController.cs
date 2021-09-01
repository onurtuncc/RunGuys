using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankController : MonoBehaviour
{
    private List<OpponentAI> opponents;
    private bool[] isOpponentAhead;
    [SerializeField] private TMP_Text rankText;
    private string rankDisplay = "Position {0}/{1}";
    private int rank=1;
    public bool finishedLevel=false;
    void Awake()
    {
        var opponentArray = FindObjectsOfType<OpponentAI>();
        opponents = new List<OpponentAI>(opponentArray);
        isOpponentAhead = new bool[opponents.Count];
        rankText.text = string.Format(rankDisplay, rank,opponents.Count+1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedLevel) return;
        foreach (OpponentAI opponent in opponents)
        {
            if (opponent.transform.position.z >= transform.position.z && isOpponentAhead[opponents.IndexOf(opponent)]!=true)
            {
                isOpponentAhead[opponents.IndexOf(opponent)] = true;
                rank += 1;
                rankText.text = string.Format(rankDisplay,rank,opponents.Count+1);

            }
            if(opponent.transform.position.z < transform.position.z && isOpponentAhead[opponents.IndexOf(opponent)] == true)
            {
                isOpponentAhead[opponents.IndexOf(opponent)] = false;
                rank -= 1;
                rankText.text = string.Format(rankDisplay, rank,opponents.Count+1);
                
            }
        }
        
    }
}
