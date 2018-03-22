using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour {
    public static float LATENCY_OFFSET;
    [SerializeField] float m_latency = 0;

    PlaySequenceManager     m_PSM;

    /* INITIALIZATION */
    void Awake()
    {
        LATENCY_OFFSET = m_latency;
    }

    void Start ()
    {
        m_PSM = GetComponent<PlaySequenceManager>();
    }

    void Update()
    {
        // Start sequence: Y_manette ou A_clavier
        if ((Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.A)) && !m_PSM.GetIsRunning())
        {
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