using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Umbraco.Community.ExtensionMethods.ASPNET
{
    public static class ASPNET
    {
        /// <summary>
        /// Gets a masterpage of the current page by type.
        /// Example usage: SomeMasterPage someMasterPage = (SomeMasterPage)Page.FindMasterPageByType(typeof(SomeMasterPage))
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="type">The type of the masterpage to find</param>
        /// <returns>The instance of the found masterpage, or null when not found</returns>
        public static MasterPage GetMasterPageByType(this Page page, Type type)
        {
            MasterPage currentMaster = page.Master;
            do
            {
                if (currentMaster.GetType().BaseType == type)
                    return currentMaster;
                currentMaster = currentMaster.Master != null ? currentMaster.Master : null;
            }
            while (currentMaster != null);

            return null;
        }

        /// <summary>
        /// Renders a usercontrol and returns the string representation of the rendered output
        /// </summary>
        /// <param name="path">The path of the usercontrol</param>
        /// <param name="propertiesToSet">Optional properties of the usercontrol to set</param>
        /// <returns>The rendered output of the usercontrol as a string</returns>
        public static string RenderUserControl(this string path, Dictionary<string, object> propertiesToSet = null)
        {
            Page pageHolder = new Page();
            UserControl viewControl = (UserControl)pageHolder.LoadControl(path);

            if (propertiesToSet != null && propertiesToSet.Any())
            {
                Type viewControlType = viewControl.GetType();
                foreach (KeyValuePair<string, object> property in propertiesToSet)
                {
                    PropertyInfo propertyInfo = viewControlType.GetProperty(property.Key);

                    if (propertyInfo != null)
                        propertyInfo.SetValue(viewControl, property.Value, null);
                    else
                        throw new NotSupportedException(string.Format("Usercontrol '{0}' does not have a public property called {1}", path, property.Key));
                }
            }

            pageHolder.Controls.Add(viewControl);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, false);
            return output.ToString();
        }

        /// <summary>
        /// Renders a control to a string.
        /// </summary>
        /// <param name="ctrl">The control to render.</param>
        /// <returns>
        /// Returns a string of the rendered control.
        /// </returns>
        public static string RenderControlToString(this Control ctrl)
        {
            var sb = new StringBuilder();

            using (var tw = new StringWriter(sb))
            using (var hw = new HtmlTextWriter(tw))
            {
                ctrl.RenderControl(hw);
            }

            return sb.ToString();
        }
    }
}
