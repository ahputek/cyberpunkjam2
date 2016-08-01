using UnityEngine;
using System.Collections;
using Framework.MVC;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Framework.MVC
{

    /// <summary>
    /// Extension to support generic applications.
    /// </summary>
    public class DropView<T> : DragView where T : BaseApplication
    {
        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        public T app { get { return (T)base.App; } }
    }

    /// <summary>
    /// Base class for all Mouse Drop features related classes.
    /// </summary>
    public class DropView : NotificationView, IDropHandler
    {
        
        /// <summary>
        /// Init.
        /// </summary>
        void Start()
        {
            
        }

        /// <summary>
        /// Handles the drop callback.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData e)
        {
            Notify(notification + "@drop", e);
            
        }

    }

}