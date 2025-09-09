using DCS_BIOS.EventArgs;
using DCS_BIOS;
using NonVisuals.CockpitMaster.Panels;
using System;
using DCS_BIOS.Interfaces;
using NonVisuals.CockpitMaster.Switches;
using System.Collections.Generic;
using NonVisuals.HID;
using DCS_BIOS.Serialized;
using DCS_BIOS.ControlLocator;

namespace NonVisuals.CockpitMaster.PreProgrammed
{
    public class CDU737PanelCH47 : CDU737PanelBase , IDCSBIOSStringListener
    {
        // List the DCSBios Mappings Here

        private DCSBIOSOutput _CDU_LINE_1;
        private DCSBIOSOutput _CDU_LINE_2;
        private DCSBIOSOutput _CDU_LINE_3;
        private DCSBIOSOutput _CDU_LINE_4;
        private DCSBIOSOutput _CDU_LINE_5;
        private DCSBIOSOutput _CDU_LINE_6;
        private DCSBIOSOutput _CDU_LINE_7;
        private DCSBIOSOutput _CDU_LINE_8;
        private DCSBIOSOutput _CDU_LINE_9;
        private DCSBIOSOutput _CDU_LINE_10;
        private DCSBIOSOutput _CDU_LINE_11;
        private DCSBIOSOutput _CDU_LINE_12;
        private DCSBIOSOutput _CDU_LINE_13;
        private DCSBIOSOutput _CDU_LINE_14;


        private DCSBIOSOutput _CDU_BRT;

        private DCSBIOSOutput _MASTER_CAUTION;

        private Dictionary<uint, int> _cduLineAddressToIndex;

        public CDU737PanelCH47(HIDSkeleton hidSkeleton) : base(hidSkeleton)
        {}

        public override void InitPanel()
        {
            try
            {
                base.InitPanel();

                CDUPanelKeys = CDUMappedCommandKeyA10C.GetMappedPanelKeys();
                
                // CDU Lines & BRT

                
                _CDU_LINE_1 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE1");
                _CDU_LINE_2 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE2");
                _CDU_LINE_3 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE3");
                _CDU_LINE_4 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE4");
                _CDU_LINE_5 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE5");
                _CDU_LINE_6 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE6");
                _CDU_LINE_7 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE7");
                _CDU_LINE_8 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE8");
                _CDU_LINE_9 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE9");
                _CDU_LINE_10 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE10");
                _CDU_LINE_11 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE11");
                _CDU_LINE_12 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE12");
                _CDU_LINE_13 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE13");
                _CDU_LINE_14 = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE14");


                _CDU_BRT = DCSBIOSControlLocator.GetUIntDCSBIOSOutput("PLT_INT_LIGHT_CDU");
                _MASTER_CAUTION = DCSBIOSControlLocator.GetUIntDCSBIOSOutput("PLT_MASTER_CAUTION_LIGHT");

                _cduLineAddressToIndex = new Dictionary<uint, int>
                {
                    
                    { _CDU_LINE_1.Address, 0 },
                    { _CDU_LINE_2.Address, 1 },
                    { _CDU_LINE_3.Address, 2 },
                    { _CDU_LINE_4.Address, 3 },
                    { _CDU_LINE_5.Address, 4 },
                    { _CDU_LINE_6.Address, 5 },
                    { _CDU_LINE_7.Address, 6 },
                    { _CDU_LINE_8.Address, 7 },
                    { _CDU_LINE_9.Address, 8 },
                    { _CDU_LINE_10.Address, 9 },
                    { _CDU_LINE_11.Address, 10 },
                    { _CDU_LINE_12.Address, 11 },
                    { _CDU_LINE_13.Address, 12 },
                    { _CDU_LINE_14.Address, 13 }
                };

                BIOSEventHandler.AttachStringListener(this);
                BIOSEventHandler.AttachDataListener(this);

                SetLine(0, string.Format("{0,24}","CH47 profile"));

                StartListeningForHidPanelChanges();
                
            }
            catch (Exception ex)
            {
                SetLastException(ex);
            }
        }

        private bool _disposed;
        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    BIOSEventHandler.DetachStringListener(this);
                    BIOSEventHandler.DetachDataListener(this);
                }

                _disposed = true;
            }

            // Call base class implementation.
            base.Dispose(disposing);
        }
        protected override void GamingPanelKnobChanged(bool isFirstReport, IEnumerable<object> hashSet)
        {
            if (isFirstReport)
            {
                return;
            }

            try
            {
                foreach (CDUMappedCommandKey key in hashSet)
                {
                    DCSBIOS.Send(key.MappedCommand());
                }

            }
            catch (Exception)
            {
            }
        }



        public override void DcsBiosDataReceived(object sender, DCSBIOSDataEventArgs e)
        {
            bool refreshLedOrLight = false;

            if (SettingsLoading)
            {
                return;
            }

            try
            {
                UpdateCounter(e.Address, e.Data);

                // CDU Brightness
                if (e.Address == _CDU_BRT.Address)
                {
                    int bright = (int)_CDU_BRT.GetUIntValue(e.Data);

                    ScreenBrightness= bright * 100 / 65536;
                    KeyboardBrightness = ScreenBrightness;
                    
                    refreshLedOrLight = true;

                }

                if (e.Address == _MASTER_CAUTION.Address)
                {
                    int masterCaution = (int) _MASTER_CAUTION.GetUIntValue(e.Data);
                    if ( masterCaution == 1)
                    {
                        Led_ON(CDU737Led.FAIL);
                        
                    }
                    else
                    {
                        Led_OFF(CDU737Led.FAIL);
                    }
                    refreshLedOrLight = true;

                }

                if (refreshLedOrLight) {
                    refreshLedsAndBrightness();
                }
            }
            catch (Exception)
            {

            }

        }
        public  void DCSBIOSStringReceived(object sender, DCSBIOSStringDataEventArgs e)
        {
            try
            {
                string data = e.StringData
                    .Replace("***", "xxx")
                    .Replace("**", "xx");

                if (_cduLineAddressToIndex.TryGetValue(e.Address, out int lineIndex))
                {
                    SetColorForLine(lineIndex, CDUColor.WHITE);
                    SetLine(lineIndex, data);
                }

            }

            catch (Exception)
            {

            }
        }
    }

}
