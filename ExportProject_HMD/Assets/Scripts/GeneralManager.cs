using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour {
    PlaySequenceManager     m_PSM;
    OutputWriter            m_OutputWriter;

    /* INITIALIZATION */
    void Start ()
    {
        m_PSM = GetComponent<PlaySequenceManager>();
        m_OutputWriter = GetComponent<OutputWriter>();
    }

    void Update()
    {
        // Start sequence: Y_manette ou A_clavier
        if ((Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.A)) && !m_PSM.GetIsRunning())
        {
            if(m_OutputWriter.GetRecord())
                m_OutputWriter.CreateFile();

            StartCoroutine(m_PSM.FirstStep());
        }

        // Toggle menu: LeftAlt_clavier ou Start_manette
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            //panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }

        // Quitter: Back_manette ou Echap_clavier
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Application.Quit();
        }
    }
}