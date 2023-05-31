using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zakaz.Controls
{
    public class VInput : WebControl
    {
        private string nspace = "SostZakaza.Models";
        private string NameORG = "Zakaz";

        public string GetNameORG()
        { return nspace; }

        public void SetNameORG(string value)
        { nspace = value; }
        public string Adres
        {
            get { return NameORG; }
            set { NameORG = value; }
        }

        public string Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {
            NewMethod(output);
            output.AddAttribute(HtmlTextWriterAttribute.NameORG,
                                Property.ToLower());

            Type modelType = Type.GetType(string.Format("{0}.{1}", GetNameORG(), Adres));
            PropertyInfo propInfo = modelType.GetProperty(Property);
            var attr = propInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (attr != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", attr.ErrorMessage);
            }
            output.RenderBeginTag("input");
            output.RenderEndTag();
        }

        private void NewMethod(HtmlTextWriter output) => output.AddAttribute(HtmlTextWriterAttribute.ZakazId, Property.ToLower());

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }
    }
}
