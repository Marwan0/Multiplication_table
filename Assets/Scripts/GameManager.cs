using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RTLTMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject Ballon_1;
    public GameObject Ballon_2;
    public GameObject Ballon_3;
    public GameObject Ballon_4;
    public GameObject Ballon_5;
    public GameObject Animation_ballon_Pos1;
    public GameObject Animation_ballon_Pos2;
    public GameObject Animation_ballon_Pos3;
    public GameObject Animation_ballon_Pos4;
    public GameObject Animation_ballon_Pos5;

    [Space]
    public RTLTextMeshPro3D Question;

    int Q_num_1;
    int Q_num_2;
    int Answer;

    public List<RTLTextMeshPro3D> Answers_List = new List<RTLTextMeshPro3D> ();

    public List<AudioClip> WinSound;
    public AudioClip ChildChearing;
    public AudioClip LoseSound;
    void Start ()
    {
        Choose_Question ();
    }

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Choose_Question ();
        }
        if (Input.GetKeyDown (KeyCode.A))
        {
            AnimateBallons ();
        }
        if (Input.GetKeyDown (KeyCode.S))
        {
            scaleDownBallons ();
        }
    }

    /// <summary>
    /// Change the question.
    /// </summary>
    void Choose_Question ()
    {
        Q_num_1 = Random.Range (1, 13);
        Q_num_2 = Random.Range (1, 13);
        Question.text = Q_num_1.ToString () + " x " + Q_num_2.ToString ();
        Answer = Q_num_1 * Q_num_2;
        //print (Answer);
        Random_Answers ();

    }



    void Random_Answers ()
    {
        int random_index = Random.Range (0, Answers_List.Count);
        for (int i = 0; i < Answers_List.Count; i++)
        {
            if (i != random_index)
            {
                Answers_List [i].text = Random.Range (1, 99).ToString ();
            }
        }
        Answers_List [random_index].text = Answer.ToString ();

    }


    /// <summary>
    /// 
    /// </summary>
    void scaleDownBallons ()
    {
        Ballon_1.transform.DOScale (Vector3.zero, 2f);
        Ballon_2.transform.DOScale (Vector3.zero, 2f);
        Ballon_3.transform.DOScale (Vector3.zero, 2f).OnComplete (() =>
        {
            AnimateBallons ();
            Choose_Question ();
            Ballon_1.GetComponent<BoxCollider> ().enabled = true;
            Ballon_2.GetComponent<BoxCollider> ().enabled = true;
            Ballon_3.GetComponent<BoxCollider> ().enabled = true;
            Ballon_4.GetComponent<BoxCollider> ().enabled = true;
            Ballon_5.GetComponent<BoxCollider> ().enabled = true;
        });
        Ballon_4.transform.DOScale (Vector3.zero, 2f);
        Ballon_5.transform.DOScale (Vector3.zero, 2f);
    }



    /// <summary>
    /// Scale up ballons
    /// </summary>
    void AnimateBallons ()
    {
        Ballon_1.transform.DOScale (new Vector3 (0.4605395f, 0.4605395f, 0.4605395f), 2f);
        Ballon_2.transform.DOScale (new Vector3 (0.4605395f, 0.4605395f, 0.4605395f), 2f);
        Ballon_3.transform.DOScale (new Vector3 (0.4605395f, 0.4605395f, 0.4605395f), 2f);
        Ballon_4.transform.DOScale (new Vector3 (0.4605395f, 0.4605395f, 0.4605395f), 2f);
        Ballon_5.transform.DOScale (new Vector3 (0.4605395f, 0.4605395f, 0.4605395f), 2f);

        Ballon_1.transform.DOMove (Animation_ballon_Pos1.transform.position, 2f).From (Ballon_1.transform.position + (Vector3.up * 5));
        Ballon_2.transform.DOMove (Animation_ballon_Pos2.transform.position, 2f).From (Ballon_2.transform.position + (Vector3.up * 5));
        Ballon_3.transform.DOMove (Animation_ballon_Pos3.transform.position, 2f).From (Ballon_3.transform.position + (Vector3.up * 5));
        Ballon_4.transform.DOMove (Animation_ballon_Pos4.transform.position, 2f).From (Ballon_4.transform.position + (Vector3.up * 5));
        Ballon_5.transform.DOMove (Animation_ballon_Pos5.transform.position, 2f).From (Ballon_5.transform.position + (Vector3.up * 5));
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="TheAnswer"></param>
    public void ValidateAnswer (string TheAnswer)
    {

        if (TheAnswer == Answer.ToString ())
        {
            GetComponent<AudioSource> ().PlayOneShot (ChildChearing, .2f);
            GetComponent<AudioSource> ().PlayOneShot (WinSound [Random.Range (0, WinSound.Count)]);
            Ballon_1.GetComponent<BoxCollider> ().enabled = false;
            Ballon_2.GetComponent<BoxCollider> ().enabled = false;
            Ballon_3.GetComponent<BoxCollider> ().enabled = false;
            Ballon_4.GetComponent<BoxCollider> ().enabled = false;
            Ballon_5.GetComponent<BoxCollider> ().enabled = false;
            scaleDownBallons ();
        }
        else
        {
            GetComponent<AudioSource> ().PlayOneShot (LoseSound);
            print ("Answer is wrong");
        }

    }
}
