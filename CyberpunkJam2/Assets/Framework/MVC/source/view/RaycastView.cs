﻿using UnityEngine;
using System.Collections;
using Framework.MVC;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Framework.MVC
{

    /// <summary>
    /// Extension to support generic applications.
    /// </summary>
    public class RaycastView<T> : RaycastView where T : BaseApplication
    {
        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        public T app { get { return (T)base.App; } }
    }

    /// <summary>
    /// Base class for all Raycast vs Collider features.
    /// </summary>
    public class RaycastView : NotificationView
    {
        /// <summary>
        /// Flag that indicates if the input is pressed on this element.
        /// </summary>
        public bool down;

        /// <summary>
        /// Flag that indicates the input is over this element.
        /// </summary>
        public bool over;

        /// <summary>
        /// Flag that indicates how many seconds the input is being held.
        /// </summary>
        public float hold;

        /// <summary>
        /// List of colliders.
        /// </summary>
        public Collider[] colliders;

        /// <summary>
        /// Init.
        /// </summary>
        void Awake()
        {            
            hold = 0f;
            down = false;
            over = false;
            colliders = GetComponentsInChildren<Collider>();
        }

        /// <summary>
        /// Updates the collider check.
        /// </summary>
        void Update()
        {            
            Camera cam = Camera.main;
            bool is_over = false;
            if(cam)
            {                
                RaycastHit hit;
                Ray r = cam.ScreenPointToRay(Input.mousePosition);
                for (int i = 0; i < colliders.Length;i++)
                {
                    Collider c = colliders[i];
                    if(c.Raycast(r,out hit,1000f))
                    {
                        is_over = true;
                        break;
                    }
                }
            }

            if (over) 
            { 
                if (!is_over) { Notify(notification + "@out"); } 
            }
            else
            {
                if (is_over) { Notify(notification + "@over"); }
            }
            

            over = is_over;

            bool is_down = over && (Input.GetKey(KeyCode.Mouse0) || (Input.touchCount==1));

            if (down)
            {
                if (!is_down) 
                { 
                    Notify(notification + "@up"); 
                    if(is_over)
                    {
                        Notify(notification + "@click"); 
                    }
                    hold = 0f; 
                }
            }
            else
            {
                if (is_down) { Notify(notification + "@down"); hold = 0f; }
            }            
            
            down = is_down;

            if (down)
            {
                Notify(notification + "@hold");
                hold += Time.unscaledDeltaTime;
            }
        }
    }

}