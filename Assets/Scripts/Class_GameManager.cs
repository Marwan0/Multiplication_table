using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RTLTMPro;
using UnityEngine;
public class Class_GameManager : MonoBehaviour
{
    public static Class_GameManager init;
    public RTLTextMeshPro3D Question;
    public List<Answer> AllAnswers;
    public List<RTLTextMeshPro3D> AnswersTextList;

    public List<Answer> TempAnswers = new List<Answer> ();
    public List<Answer> PickedAnswers = new List<Answer> ();

    public AnswerType ActiveAnswer;

    public int NumberOfAnswers;

    public List<AudioClip> Win;
    public AudioClip ChildrenCheers;
    public AudioClip Lose;
    public AudioClip Sun_Q;
    public AudioClip Moon_Q;

    AudioSource AS;

    // Start is called before the first frame update
    void Start ()
    {
        init = this;

        RandomAnswers ();
        AS = GetComponent<AudioSource> ();
        AS.PlayOneShot (Sun_Q);
    }

    public void PlayWinSound ()
    {
        AS.PlayOneShot (Win [Random.Range (0, Win.Count)], .7f);
        AS.PlayOneShot (ChildrenCheers, .2f);
    }
    public void PlayLoseSound ()
    {
        AS.PlayOneShot (Lose, .5f);

    }
    void RandomAnswers ()
    {
        TempAnswers.Clear ();
        PickedAnswers.Clear ();
        NumberOfAnswers = 0;
        for (int i = 0; i < AllAnswers.Count; i++)
        {
            TempAnswers.Add (AllAnswers [i]);
        }
        for (int i = 0; i < 9; i++)
        {
            int RandomIndex = Random.Range (0, TempAnswers.Count);
            PickedAnswers.Add (TempAnswers [RandomIndex]);
            AnswersTextList [i].text = TempAnswers [RandomIndex].TheAnswer;
            var Temp = AnswersTextList [i].gameObject.transform.parent.GetComponent<Class_AnswerElement> ();
            Temp.TheAnswer._AnswerType = TempAnswers [RandomIndex]._AnswerType;
            Temp.TheAnswer.TheAnswer = TempAnswers [RandomIndex].TheAnswer;
            if (TempAnswers [RandomIndex]._AnswerType == ActiveAnswer)
            {
                NumberOfAnswers++;
                print ("Number Of Answers" + NumberOfAnswers);
            }
            TempAnswers.RemoveAt (RandomIndex);
        }
    }

    public IEnumerator RestartGame ()
    {
        for (int i = 0; i < AnswersTextList.Count; i++)
        {
            AnswersTextList [i].transform.parent.transform.DOScale (Vector3.zero, 1f);
        }
        yield return new WaitForSeconds (1);

        if (ActiveAnswer == AnswerType.Moon)
        {
            ActiveAnswer = AnswerType.Sun;
            Question.text = "اختار الكلمات التى بها لام شمسية";
            AS.PlayOneShot (Sun_Q);
        }
        else
        {
            Question.text = "اختار الكلمات التى بها لام قمرية";
            ActiveAnswer = AnswerType.Moon;
            AS.PlayOneShot (Moon_Q);
        }

        RandomAnswers ();
        for (int i = 0; i < AnswersTextList.Count; i++)
        {
            AnswersTextList [i].transform.parent.transform.DOScale (Vector3.one, 1f);
        }
    }
}

[System.Serializable]
public class Answer
{
    public string TheAnswer;
    public AnswerType _AnswerType;

}

public enum AnswerType
{
    Moon,
    Sun
}
