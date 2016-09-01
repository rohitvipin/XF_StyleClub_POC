using XF_StyleClub_POC.Enums;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF_StyleClub_POC.CustomControls
{
    /// <summary>
    /// Entry control which supports customization of keyboard done button, set focus to another element, run command on of entry completion
    /// </summary>
    public class CustomEntry : Entry
    {
        // Need to overwrite default handler because we cant Invoke otherwise
        public new event EventHandler Completed;

        /// <summary>
        /// Sets the keyboard button type Go,Next,Done,Send,Search
        /// </summary>
        public static readonly BindableProperty KeyboardButtonTypeProperty = BindableProperty.Create<CustomEntry, EntryKeyboardButtonType>(s => s.EntryKeyboardButtonType, EntryKeyboardButtonType.Done);

        /// <summary>
        /// Sets the next control to focus
        /// </summary>
        public static readonly BindableProperty NextControlToFocusProperty = BindableProperty.Create<CustomEntry, Entry>(s => s.NextControlToFocus, null, BindingMode.OneWay, NextControlToFocusPropertyChanged);

        /// <summary>
        /// Sets the command to run on completion of entry
        /// </summary>
        public static readonly BindableProperty CommandAfterCompletionProperty = BindableProperty.Create<CustomEntry, ICommand>(s => s.CommandAfterCompletion, null, BindingMode.OneWay, CommandAfterCompletionPropertyChanged);

        /// <summary>
        /// Keyboard button type property Go,Next,Done,Send,Search
        /// </summary>
        public EntryKeyboardButtonType EntryKeyboardButtonType
        {
            get
            {
                return (EntryKeyboardButtonType)GetValue(KeyboardButtonTypeProperty);
            }
            set
            {
                SetValue(KeyboardButtonTypeProperty, value);
            }
        }

        /// <summary>
        /// Sets the next control to focus property
        /// </summary>
        public Entry NextControlToFocus
        {
            get
            {
                return GetValue(NextControlToFocusProperty) as Entry;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                SetValue(NextControlToFocusProperty, value);
            }
        }

        /// <summary>
        /// Sets the command property to run on completion of entry
        /// </summary>
        public ICommand CommandAfterCompletion
        {
            get { return (ICommand)GetValue(CommandAfterCompletionProperty); }
            set
            {
                if (value == null)
                {
                    return;
                }
                SetValue(CommandAfterCompletionProperty, value);
            }
        }

        public void InvokeCompleted()
        {
            Completed?.Invoke(this, null);
        }

        private static bool NextControlToFocusPropertyChanged(BindableObject bindable, Entry controlToFocus)
        {
            var entry = bindable as CustomEntry;
            if (controlToFocus != null && entry != null)
            {
                entry.Completed += (sender, args) => controlToFocus.Focus();
            }
            return true;
        }

        private static bool CommandAfterCompletionPropertyChanged(BindableObject bindable, ICommand value)
        {
            var entry = bindable as CustomEntry;
            if (value != null && entry != null)
            {
                entry.Completed += (sender, args) => value.Execute(null);
            }
            return true;
        }
    }
}