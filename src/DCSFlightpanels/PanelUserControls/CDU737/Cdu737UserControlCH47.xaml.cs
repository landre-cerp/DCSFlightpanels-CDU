using System;
using System.Windows;
using ClassLibraryCommon;
using DCSFlightpanels.Interfaces;
using NonVisuals.CockpitMaster.PreProgrammed;
using NonVisuals.EventArgs;
using NonVisuals.HID;
using NonVisuals.Interfaces;
using NonVisuals.Panels;

namespace DCSFlightpanels.PanelUserControls.CDU737
{
    /// <summary>
    /// Interaction logic for Cdu737UserControlCH47.xaml
    /// </summary>
    /// 
    public partial class Cdu737UserControlCH47 : IGamingPanelListener,
        IGamingPanelUserControl
    {
        private readonly CDU737PanelCH47 _cdu737PanelCH47;

        public Cdu737UserControlCH47(HIDSkeleton hidSkeleton)
        {
            InitializeComponent();

            _cdu737PanelCH47 = new CDU737PanelCH47(hidSkeleton);
            
            //_HIDSkeleton = hidSkeleton;
            AppEventHandler.AttachGamingPanelListener(this);

            HideAllImages();

        }
        private bool _disposed;
        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _cdu737PanelCH47.Dispose();
                    AppEventHandler.DetachGamingPanelListener(this);

                }
                _disposed = true;
            }

            // Call base class implementation.
            base.Dispose(disposing);
        }

        public override void Init()
        {
            try
            {
                _cdu737PanelCH47.InitPanel();
            }
            catch (Exception ex)
            {
                Common.ShowErrorMessageBox(ex);
            }
        }

        private void CDU737UserControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            UserControlLoaded = true;
        }

        public override GamingPanel GetGamingPanel()
        {
            return _cdu737PanelCH47;
        }


        public void ProfileEvent(object sender, ProfileEventArgs e)
        {

        }

        public void SettingsApplied(object sender, PanelInfoArgs e)
        {

        }

        public void SettingsModified(object sender, PanelInfoArgs e)
        {

        }

        public void SwitchesChanged(object sender, SwitchesChangedEventArgs e)
        {
            string[] lines = _cdu737PanelCH47.CDULines;
            Dispatcher?.BeginInvoke(
            (Action)
            (() =>
            {
                CDU737UserControl.DisplayLines(lines, 14);
            }
            ));
        }

        public void UpdatesHasBeenMissed(object sender, DCSBIOSUpdatesMissedEventArgs e)
        {

        }
        private static void HideAllImages()
        {

        }

        public string GetName()
        {
            return GetType().Name;
        }

    }
}

