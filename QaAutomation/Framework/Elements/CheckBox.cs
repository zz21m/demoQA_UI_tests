using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utilities;

namespace Framework.Elements
{
    public class CheckBox : BaseElement
    {
        public CheckBox(By locator, string name) : base(locator, name)
        {
        }

        public bool IsSelected()
        {
            return Find().Selected;
        }

        public void Select()
        {
            if (!IsSelected())
            {
                Logger.Info($"Select checkbox: {Name}");
                Click();
            }
        }

        public void Unselect()
        {
            if (IsSelected())
            {
                Logger.Info($"Unselect checkbox: {Name}");
                Click();
            }
        }
    }
}
