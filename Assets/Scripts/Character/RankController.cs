using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankController : MonoBehaviour
{
    private List<OpponentAI> opponents;
    private bool[] isOpponentAhead;
    [SerializeField] private TMP_Text rankText;
    private string rankDisplay = "Rank: {0}";
    private int rank=1;
    void Awake()
    {
        var opponentArray = FindObjectsOfType<OpponentAI>();
        opponents = new List<OpponentAI>(opponentArray);
        isOpponentAhead = new bool[opponents.Count];
        rankText.text = string.Format(rankDisplay, rank);
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (OpponentAI opponent in opponents)
        {
            if (opponent.transform.position.z >= transform.position.z && isOpponentAhead[opponents.IndexOf(opponent)]!=true)
            {
                isOpponentAhead[opponents.IndexOf(opponent)] = true;
                rank += 1;
                rankText.text = string.Format(rankDisplay, rank);

            }
            if(opponent.transform.position.z < transform.position.z && isOpponentAhead[opponents.IndexOf(opponent)] == true)
            {
                isOpponentAhead[opponents.IndexOf(opponent)] = false;
                rank -= 1;
                rankText.text = string.Format(rankDisplay, rank);
            }
        }
        
    }
}
