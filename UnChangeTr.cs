    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UnChangeTr : MonoBehaviour
    {
        public Vector3 FixTranslationToParents;
    
        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = transform.parent.transform.position;
            transform.Translate(FixTranslationToParents, Space.World);
        }
    }
