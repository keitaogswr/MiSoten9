using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Es.InkPainter.Sample
{
    public class Paint : MonoBehaviour
    {
        [SerializeField]
        private Brush brush;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var ray = new Ray(transform.position,new Vector3(0.0f, -1.0f, 0.0f));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                var paintObject = hitInfo.transform.GetComponent<InkCanvas>();
                bool success = true;
                if (paintObject != null) success = paintObject.Paint(brush, hitInfo);
            }
        }
    }
}