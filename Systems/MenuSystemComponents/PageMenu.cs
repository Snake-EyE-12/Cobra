using System;
using UnityEngine;

namespace Cobra.GUI
{
    public class PageMenu : BaseMenuPiece
    {
        [field:SerializeField, Min(0), Tooltip("Highest Priority is Initial Page")] public int Priority { get; private set; }

        public void SetPriority(int priority)
        {
            Priority = priority;
            parentMenuController.Reset();
        }
        
        public override void Initialize(MenuControllerDefault controller)
        {
            base.Initialize(controller);
            controller.OnPageChange += OnSwitchPage;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            parentMenuController.OnPageChange -= OnSwitchPage;
        }

        private void OnSwitchPage(PageMenu newPage)
        {
            if (newPage == this)
            {
                OnShow();
            }
            else
            {
                OnHide();
            }
        }

        public void RequestOpen()
        {
            parentMenuController.GoTo(this);
        }

        private void OnShow()
        {
            gameObject.SetActive(true);
        }

        private void OnHide()
        {
            gameObject.SetActive(false);
        }
    }
}