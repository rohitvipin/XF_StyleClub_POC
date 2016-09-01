using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF_StyleClub_POC.CustomControls;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.iOS.CustomControlRenderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace XF_StyleClub_POC.iOS.CustomControlRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var newCustomEntryElement = e.NewElement as CustomEntry;

            if (Control == null || newCustomEntryElement == null)
            {
                return;
            }

            if (newCustomEntryElement.Keyboard == Keyboard.Numeric)
            {
                Control.InputAccessoryView = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f))
                {
                    Items = new[]
                    {
                        new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                        new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
                    }
                };
            }

            SetReturnType(newCustomEntryElement);

            Control.ShouldReturn += tf =>
            {
                newCustomEntryElement.InvokeCompleted();
                return true;
            };
        }

        private void SetReturnType(CustomEntry entry)
        {
            switch (entry.EntryKeyboardButtonType)
            {
                case EntryKeyboardButtonType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;

                case EntryKeyboardButtonType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;

                case EntryKeyboardButtonType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;

                case EntryKeyboardButtonType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;

                case EntryKeyboardButtonType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;

                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;
            }
        }
    }
}