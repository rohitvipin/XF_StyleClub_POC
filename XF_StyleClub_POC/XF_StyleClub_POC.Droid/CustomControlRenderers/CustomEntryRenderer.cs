using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Views.InputMethods;
using Java.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF_StyleClub_POC.CustomControls;
using XF_StyleClub_POC.Droid.CustomControlRenderers;
using XF_StyleClub_POC.Enums;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace XF_StyleClub_POC.Droid.CustomControlRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            var newCustomEntryElement = e.NewElement as CustomEntry;
            if (Control == null || newCustomEntryElement == null)
            {
                return;
            }
            SetReturnType(newCustomEntryElement);

            // Editor Action is called when the return button is pressed
            Control.EditorAction  += (sender, args) =>
            {
                if (newCustomEntryElement.EntryKeyboardButtonType != EntryKeyboardButtonType.Next)
                    newCustomEntryElement.Unfocus();

                // Call all the methods attached to base_entry event handler Completed
                newCustomEntryElement.InvokeCompleted();
            };
            var shape = new ShapeDrawable(new RectShape());
            shape.Paint.Color = Android.Graphics.Color.Transparent;
            shape.Paint.StrokeWidth = 0;
            shape.Paint.SetStyle(Paint.Style.Stroke);
            Control.SetBackground(shape);
        }

        private void SetReturnType(CustomEntry entry)
        {
            switch (entry.EntryKeyboardButtonType)
            {
                case EntryKeyboardButtonType.Go:
                    Control.ImeOptions = ImeAction.Go;
                    Control.SetImeActionLabel("Go", ImeAction.Go);
                    break;

                case EntryKeyboardButtonType.Next:
                    Control.ImeOptions = ImeAction.Next;
                    Control.SetImeActionLabel("Next", ImeAction.Next);
                    break;

                case EntryKeyboardButtonType.Send:
                    Control.ImeOptions = ImeAction.Send;
                    Control.SetImeActionLabel("Send", ImeAction.Send);
                    break;

                case EntryKeyboardButtonType.Search:
                    Control.ImeOptions = ImeAction.Search;
                    Control.SetImeActionLabel("Search", ImeAction.Search);
                    break;

                case EntryKeyboardButtonType.Done:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Done", ImeAction.Done);
                    break;

                default:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Done", ImeAction.Done);
                    break;
            }
        }
    }
}