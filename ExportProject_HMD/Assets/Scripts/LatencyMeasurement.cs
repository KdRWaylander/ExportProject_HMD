using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatencyMeasurement : MonoBehaviour {
    [SerializeField] GameObject m_trackedDevice;
    [SerializeField] Image m_outputImage;

    float m_Y;
    Color m_transpRed, m_transpGreen;

    void Start()
    {
        m_transpRed = new Color(1, 0, 0, 0.5f);
        m_transpGreen = new Color(0, 1, 0, 0.5f);

        m_Y = m_trackedDevice.transform.position.y;
    }

    void Update ()
    {
        if (m_trackedDevice.transform.position.y >= m_Y)
        {
            m_outputImage.color = m_transpGreen;
        }
        else
        {
            m_outputImage.color = m_transpRed;
        }

        m_Y = m_trackedDevice.transform.position.y;
    }
}