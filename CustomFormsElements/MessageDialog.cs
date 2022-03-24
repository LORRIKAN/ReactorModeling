#nullable enable
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomFormsElements
{
    public static class MessageDialog
    {
        private static void SetStringArg(ref string? arg, string? value)
        {
            if (string.IsNullOrEmpty(arg))
                arg = value;
        }

        private static TaskDialogButton ShowDialog(IWin32Window? window, bool applicationRun, TaskDialogPage page)
        {
            if (applicationRun)
            {
                var form = new Form();
                Application.Run(form);
                form.Hide();

                TaskDialogButton result = TaskDialog.ShowDialog(form, page);
                form.Close();

                return result;
            }

            if (window is null)
                return TaskDialog.ShowDialog(page);
            else
                return TaskDialog.ShowDialog(window, page);
        }

        private static TaskDialogPage CreatePage(bool aboveAll, string? caption, string? heading, string? text, TaskDialogButtonCollection buttons)
        {
            return new TaskDialogPage
            {
                AllowCancel = !aboveAll,
                AllowMinimize = !aboveAll,
                Buttons = buttons,
                Caption = caption,
                Heading = heading,
                Text = text,
                Icon = TaskDialogIcon.Information
            };
        }

        public static TaskDialogButton ShowMessage(MessageType messageType, IWin32Window? window,
            string? caption = null, string? heading = null, string? text = null,
            bool setStringArgsAccordingToMessageType = false, bool aboveAll = false, bool applicationRun = false)
        {
            void SetStringArgs(string captionVal, string headingVal, string textVal)
            {
                if (setStringArgsAccordingToMessageType)
                {
                    SetStringArg(ref caption, captionVal);
                    SetStringArg(ref heading, headingVal);
                    SetStringArg(ref text, textVal);
                }
            }

            TaskDialogButtonCollection buttons;
            TaskDialogIcon icon;

            switch (messageType)
            {
                case MessageType.Success:
                    buttons = new TaskDialogButtonCollection { TaskDialogButton.OK };
                    SetStringArgs("Результат", "Результат операции",
                        "Операция выполнена успешно");
                    icon = TaskDialogIcon.ShieldSuccessGreenBar;
                    break;
                case MessageType.Error:
                    buttons = new TaskDialogButtonCollection { TaskDialogButton.Close };
                    SetStringArgs("Результат", "Результат операции",
                        "Операция не была выполнена");
                    icon = TaskDialogIcon.ShieldErrorRedBar;
                    break;
                case MessageType.YesNo:
                    buttons = new TaskDialogButtonCollection { TaskDialogButton.Yes, TaskDialogButton.No };
                    SetStringArgs("Выберите действие", "Выберите дальнейшее действие",
                        string.Empty);
                    icon = TaskDialogIcon.Information;
                    break;
                case MessageType.YesNoCancel:
                    buttons = new TaskDialogButtonCollection { TaskDialogButton.Yes, TaskDialogButton.No,
                        TaskDialogButton.Cancel};
                    SetStringArgs("Выберите действие", "Выберите дальнейшее действие",
                        string.Empty);
                    icon = TaskDialogIcon.Information;
                    break;
                default:
                    buttons = new TaskDialogButtonCollection { TaskDialogButton.Close };
                    icon = TaskDialogIcon.None;
                    break;
            }

            var page = CreatePage(aboveAll, caption, heading, text, buttons);

            page.Icon = icon;

            return ShowDialog(window, applicationRun, page);
        }

        public static void ShowInformationMessage(IWin32Window? window, string text, string? caption = null,
            string? heading = null, bool setStringArgsAccordingToMessageType = false,
            bool aboveAll = false, bool applicationRun = false)
        {
            if (setStringArgsAccordingToMessageType)
                SetStringArg(ref caption, "Информация");

            TaskDialogPage page = CreatePage(aboveAll, caption, heading, text,
                new TaskDialogButtonCollection { TaskDialogButton.OK });

            ShowDialog(window, applicationRun, page);
        }

        public static TaskDialogButton ShowMarqueeAwaitDialog(bool cancelable,
            Func<IAsyncEnumerable<(string message, bool error)>> progressFunc, 
            IWin32Window? window, string? caption = null, string? heading = null,
            bool setStringArgsAccordingToMessageType = false, bool aboveAll = false, 
            bool applicationRun = false)
        {
            if (setStringArgsAccordingToMessageType)
            {
                SetStringArg(ref caption, "Окно прогресса");
            }

            TaskDialogButtonCollection buttons;

            if (cancelable)
                buttons = new TaskDialogButtonCollection { TaskDialogButton.Cancel };
            else
                buttons = new TaskDialogButtonCollection();

            TaskDialogPage page = CreatePage(aboveAll, caption, heading, null, buttons);

            page.ProgressBar = new TaskDialogProgressBar { State = TaskDialogProgressBarState.Marquee };
            page.Created += async (_, _) =>
            {
                await foreach ((string message, bool error) in progressFunc())
                {
                    page.Text = message;
                    if (error)
                        page.Buttons = new TaskDialogButtonCollection { TaskDialogButton.Close };
                }

                page.BoundDialog!.Close();
            };

            return ShowDialog(window, applicationRun, page);
        }

        public static TaskDialogButton ShowNormalAwaitDialog(bool cancelable,
            Func<IAsyncEnumerable<(int progressVal, string? progressStr, bool error)>> progressFunc, 
            int min, int max, IWin32Window? window, string? caption = null, string? heading = null,
            bool setStringArgsAccordingToMessageType = false, bool aboveAll = false, 
            bool applicationRun = false)
        {
            if (setStringArgsAccordingToMessageType)
            {
                SetStringArg(ref caption, "Окно прогресса");
            }

            TaskDialogButtonCollection buttons;

            if (cancelable)
                buttons = new TaskDialogButtonCollection { TaskDialogButton.Cancel };
            else
                buttons = new TaskDialogButtonCollection();

            TaskDialogPage page = CreatePage(aboveAll, caption, heading, null, buttons);

            page.ProgressBar = new TaskDialogProgressBar
            {
                State = TaskDialogProgressBarState.Normal,
                Minimum = min,
                Maximum = max,
                Value = 0
            };

            page.Created += async (_, _) =>
            {
                await foreach ((int progressVal, string? progressStr, bool error) in progressFunc())
                {
                    page.Text = progressStr;
                    page.ProgressBar.Value = progressVal;
                    if (error)
                        page.Buttons = new TaskDialogButtonCollection { TaskDialogButton.Close };
                }

                page.BoundDialog!.Close();
            };

            return ShowDialog(window, applicationRun, page);
        }
    }

    public enum MessageType
    {
        Success,
        Error,
        YesNo,
        YesNoCancel
    }
}