using System;
using System.Collections.Generic;
using System.Linq;
using Cobra.DesignPattern;
using UnityEngine;

namespace Cobra.GUI
{
    public class MenuControllerDefault : MonoBehaviour
    {
        private CommandHandler menuSequencer = new CommandHandler();
        private PageMenu initialPageMenu;
        private PageMenu currentPageMenu;

        private void Awake()
        {
            foreach (var mp in GetComponentsInChildren<BaseMenuPiece>())
            {
                mp.Initialize(this);
            }
        }

        private void JumpToPage(PageMenu newPage)
        {
            currentPageMenu = newPage;
            OnPageChange?.Invoke(newPage);
        }
        
        public Action<PageMenu> OnPageChange;

        public void GoTo(PageMenu page)
        {
            menuSequencer.Execute(new GoToNewPageInMenuCommand(JumpToPage, page, currentPageMenu));
        }

        public void Return()
        {
            menuSequencer.Undo();
        }

        private class GoToNewPageInMenuCommand : Command
        {
            private PageMenu page;
            private PageMenu oldPage;
            private Action<PageMenu> pageChanger;
            public GoToNewPageInMenuCommand(Action<PageMenu> pageChangeMethod, PageMenu newPage, PageMenu currentPage)
            {
                page = newPage;
                oldPage = currentPage;
                pageChanger = pageChangeMethod;
            }
            public void Execute()
            {
                pageChanger?.Invoke(page);
            }

            public void Undo()
            {
                Debug.Log("Going to: " + oldPage.gameObject.name);
                pageChanger?.Invoke(oldPage);
            }
        }

        private PageMenu GetInitialPageMenu()
        {
            if (initialPageMenu == null)
            {
                initialPageMenu = GetComponentsInChildren<PageMenu>(true).OrderByDescending(x => x.Priority).First();
            }
            return initialPageMenu;
        }

        public void Open()
        {
            OpenInitialMenuPiece();
        }

        public void Close()
        {
            JumpToPage(null);
            menuSequencer.Clear();
        }

        private void OpenInitialMenuPiece()
        {
            GetInitialPageMenu().RequestOpen();
            currentPageMenu = initialPageMenu;
        }
    }

    public abstract class BaseMenuPiece : MonoBehaviour
    {
        protected MenuControllerDefault parentMenuController;

        public virtual void Initialize(MenuControllerDefault controller)
        {
            parentMenuController = controller;
        }
    }
}
