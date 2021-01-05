using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;
public class Answer_Btn : MonoBehaviour
{
    public GameManager Inst;
    public RTLTextMeshPro3D TheAnswer;
    private void Awake ()
    {
        var vrTargetItem= GetComponent<VRTargetItem>();
        if (vrTargetItem)
        {
            vrTargetItem.m_completionEvent.AddListener(() =>
            {
                Inst.ValidateAnswer(TheAnswer.OriginalText);
            });
        }

    }
    public void OnMouseDown ()
    {
        Inst.ValidateAnswer (TheAnswer.OriginalText);
    }
}
