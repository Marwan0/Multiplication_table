using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class Class_AnswerElement : MonoBehaviour
{
    public Answer TheAnswer;

    private void Start ()
    {
        if (GetComponent<VRTargetItem> ())
        {
            GetComponent<VRTargetItem> ().m_completionEvent.AddListener (ValidateAnswer);
        }
    }
    public void ValidateAnswer ()
    {
        if (TheAnswer._AnswerType == Class_GameManager.init.ActiveAnswer)
        {
            transform.DOScale (Vector3.zero, 1f);
            Class_GameManager.init.NumberOfAnswers--;
            Class_GameManager.init.PlayWinSound ();
            if (Class_GameManager.init.NumberOfAnswers == 0)
            {
                Class_GameManager.init.StartCoroutine (Class_GameManager.init.RestartGame ());
            }
        }
        else
        {
            Class_GameManager.init.PlayLoseSound ();
            print ("Wrong Answer");
            // transform.DOScale (Vector3.one, 1f);
        }
    }

    void OnMouseDown ()
    {
        ValidateAnswer ();
    }
}
