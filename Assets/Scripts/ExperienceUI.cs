using System;
using TMPro;

public class ExperienceUI : ContextBehaviour
{
    private TMP_Text _expText;

    private void Start()
    {
        _expText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _expText.text = "EXP: " + Context.ObservedAgent?.AgentGrade.CurrentExp.ToString() + "/" +
                        ((Context.ObservedAgent?.AgentGrade.CurrentExp / 10) * AgentGrade.ExpToNextGrade +
                         AgentGrade.ExpToNextGrade);
    }
}