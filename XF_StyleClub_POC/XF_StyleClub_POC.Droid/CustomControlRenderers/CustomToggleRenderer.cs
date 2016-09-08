using System.ComponentModel;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF_StyleClub_POC.CustomControls;
using XF_StyleClub_POC.Droid.CustomControlRenderers;

[assembly: ExportRenderer(typeof(CustomToggle), typeof(CustomCheckboxRenderer))]

namespace XF_StyleClub_POC.Droid.CustomControlRenderers
{
    public class CustomCheckboxRenderer : ViewRenderer<CustomToggle, CheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomToggle> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var checkBox = new CheckBox(Context);
                checkBox.CheckedChange += CheckBoxCheckedChange;
                SetNativeControl(checkBox);
            }

            if (Control != null)
            {
                Control.Checked = e.NewElement.Checked;
            }
        }

        private void CheckBoxCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.Checked = e.IsChecked;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
                    break;
            }
        }
    }
}