using DCS_BIOS;
using DCS_BIOS.ControlLocator;
using DCS_BIOS.EventArgs;
using DCS_BIOS.Interfaces;
using DCS_BIOS.Serialized;
using NonVisuals.CockpitMaster.Panels;
using NonVisuals.CockpitMaster.Switches;
using NonVisuals.HID;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;

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


        private DCSBIOSOutput _CDU_LINE1_COLOR;
        private DCSBIOSOutput _CDU_LINE2_COLOR;
        private DCSBIOSOutput _CDU_LINE3_COLOR;
        private DCSBIOSOutput _CDU_LINE4_COLOR;
        private DCSBIOSOutput _CDU_LINE5_COLOR;
        private DCSBIOSOutput _CDU_LINE6_COLOR;
        private DCSBIOSOutput _CDU_LINE7_COLOR;
        private DCSBIOSOutput _CDU_LINE8_COLOR;
        private DCSBIOSOutput _CDU_LINE9_COLOR;
        private DCSBIOSOutput _CDU_LINE10_COLOR;
        private DCSBIOSOutput _CDU_LINE11_COLOR;
        private DCSBIOSOutput _CDU_LINE12_COLOR;
        private DCSBIOSOutput _CDU_LINE13_COLOR;
        private DCSBIOSOutput _CDU_LINE14_COLOR;


        // PLT_CDU_LINE1_COLOR


        private DCSBIOSOutput _CDU_BRT;

        private DCSBIOSOutput _MASTER_CAUTION;

        private Dictionary<uint, int> _cduLineAddressToIndex;
        private Dictionary<uint, int> _cduLineColorAddressToIndex;

        private readonly Dictionary<string, CDUColor> _colours = new()
        {
            { "w", CDUColor.WHITE },
            { "g", CDUColor.GREEN },
            { "y", CDUColor.YELLOW },
            { "r", CDUColor.RED },
            { "c", CDUColor.CYAN },
            { "b", CDUColor.BLUE },
            { "p", CDUColor.PURPLE }
        };

        public CDU737PanelCH47(HIDSkeleton hidSkeleton) : base(hidSkeleton)
        {}

        public override void InitPanel()
        {
            try
            {
                base.InitPanel();

                CDUPanelKeys = CDUMappedCommandKeyCH47.GetMappedPanelKeys();
                ConvertTable = CDUTextLineHelpers.CH47ConvertTable;
                BaseColor = CDUColor.WHITE;

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

                _CDU_LINE1_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE1_COLOR");
                _CDU_LINE2_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE2_COLOR");
                _CDU_LINE3_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE3_COLOR");
                _CDU_LINE4_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE4_COLOR");
                _CDU_LINE5_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE5_COLOR");
                _CDU_LINE6_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE6_COLOR");
                _CDU_LINE7_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE7_COLOR");
                _CDU_LINE8_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE8_COLOR");
                _CDU_LINE9_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE9_COLOR");
                _CDU_LINE10_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE10_COLOR");
                _CDU_LINE11_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE11_COLOR");
                _CDU_LINE12_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE12_COLOR");
                _CDU_LINE13_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE13_COLOR");
                _CDU_LINE14_COLOR = DCSBIOSControlLocator.GetStringDCSBIOSOutput("PLT_CDU_LINE14_COLOR");

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

                _cduLineColorAddressToIndex = new Dictionary<uint, int>
                {
                    { _CDU_LINE1_COLOR.Address, 0 },
                    { _CDU_LINE2_COLOR.Address, 1 },
                    { _CDU_LINE3_COLOR.Address, 2 },
                    { _CDU_LINE4_COLOR.Address, 3 },
                    { _CDU_LINE5_COLOR.Address, 4 },
                    { _CDU_LINE6_COLOR.Address, 5 },
                    { _CDU_LINE7_COLOR.Address, 6 },
                    { _CDU_LINE8_COLOR.Address, 7 },
                    { _CDU_LINE9_COLOR.Address, 8 },
                    { _CDU_LINE10_COLOR.Address, 9 },
                    { _CDU_LINE11_COLOR.Address, 10 },
                    { _CDU_LINE12_COLOR.Address, 11 },
                    { _CDU_LINE13_COLOR.Address, 12 },
                    { _CDU_LINE14_COLOR.Address, 13 }
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

                if (_cduLineColorAddressToIndex.TryGetValue(e.Address, out int line))
                {
                    var colorArray = Enumerable.Range(0, 24).Select(_ => BaseColor).ToArray();
                    for ( int i=0; i< data.Length && i < 24; i++)
                    {
                        char c = data[i];
                        if (_colours.TryGetValue(c.ToString(), out CDUColor color))
                        {
                            colorArray[i] = color;
                        }
                    }
                    SetMaskColorForLine(line, colorArray);
                    
                }

                if (_cduLineAddressToIndex.TryGetValue(e.Address, out int lineIndex))
                {
                    SetLine(lineIndex, data);
                }

            }

            catch (Exception)
            {

            }
        }
    }

}
