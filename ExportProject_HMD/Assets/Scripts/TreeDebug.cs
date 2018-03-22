using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeDebug : MonoBehaviour
{
    [SerializeField] Text m_text;

    void Start()
    {
        m_text.text = "";

        m_text.text += transform.gameObject.name.ToString() + "\n";
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            m_text.text += "+ " + go.name.ToString() + " > " + "Tracking: " + HasTrackedObjectCustom(go) + ", isActive: " + go.activeSelf.ToString() + "\n";

            int count = go.transform.childCount;
            for (int j = 0; j < count; j++)
            {
                GameObject g = go.transform.GetChild(j).gameObject;
                m_text.text += "++ " + g.name.ToString() + " > " + "Tracking: " + HasTrackedObjectCustom(g) + ", isActive: " + g.activeSelf.ToString() + "\n";

                int c = g.transform.childCount;
                for (int k = 0; k < c; k++)
                {
                    GameObject x = g.transform.GetChild(k).gameObject;
                    m_text.text += "+++ " + x.name.ToString() + " > " + "Tracking: " + HasTrackedObjectCustom(x) + ", isActive: " + x.activeSelf.ToString() + "\n";
                }
            }
        }
    }

    string  HasTrackedObjectCustom(GameObject _g)
    {
        if (_g.GetComponent<SteamVR_TrackedObjectCustom>())
        {
            return "Custom";
        }
        else if (_g.GetComponent<SteamVR_TrackedObject>())
        {
            return "Vanilla";
        }
        else
        {
            return "None";
        }
    }
}