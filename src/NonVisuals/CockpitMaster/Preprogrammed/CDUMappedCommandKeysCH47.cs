using System.Collections.Generic;
using NonVisuals.CockpitMaster.Switches;

namespace NonVisuals.CockpitMaster.PreProgrammed
{
    public class CDUMappedCommandKeyCH47 : CDUMappedCommandKey
    {
        public CDUMappedCommandKeyCH47(int group, int mask, bool isOn, CDU737Keys _CDUKey, string commandOn = "", string commandOff = "")
            : base(group, mask, isOn, _CDUKey, commandOn, commandOff)
        {
        }

        public static HashSet<CDUMappedCommandKey> GetMappedPanelKeys()
        {
            var result = new HashSet<CDUMappedCommandKey>
            {
                // Group 1
                new CDUMappedCommandKey(1, 1 << 7, false, CDU737Keys.RSK1,"PLT_CDU_LSK_R1 INC", "PLT_CDU_LSK_R1 DEC"),
                new CDUMappedCommandKey(1, 1 << 6, false, CDU737Keys.RSK2,"PLT_CDU_LSK_R2 INC", "PLT_CDU_LSK_R2 DEC"),
                new CDUMappedCommandKey(1, 1 << 5, false, CDU737Keys.RSK3,"PLT_CDU_LSK_R3 INC", "PLT_CDU_LSK_R3 DEC"),
                new CDUMappedCommandKey(1, 1 << 4, false, CDU737Keys.RSK4,"PLT_CDU_LSK_R4 INC", "PLT_CDU_LSK_R4 DEC"),
                new CDUMappedCommandKey(1, 1 << 3, false, CDU737Keys.RSK5,"PLT_CDU_LSK_R5 INC", "PLT_CDU_LSK_R5 DEC"),
                new CDUMappedCommandKey(1, 1 << 2, false, CDU737Keys.RSK6,"PLT_CDU_LSK_R6 INC", "PLT_CDU_LSK_R6 DEC"),

                // Group 2
                new CDUMappedCommandKey(2, 1 << 7, false, CDU737Keys.LSK1,"PLT_CDU_LSK_L1 INC", "PLT_CDU_LSK_L1 DEC"),
                new CDUMappedCommandKey(2, 1 << 6, false, CDU737Keys.LSK2,"PLT_CDU_LSK_L2 INC", "PLT_CDU_LSK_L2 DEC"),
                new CDUMappedCommandKey(2, 1 << 5, false, CDU737Keys.LSK3,"PLT_CDU_LSK_L3 INC", "PLT_CDU_LSK_L3 DEC"),
                new CDUMappedCommandKey(2, 1 << 4, false, CDU737Keys.LSK4,"PLT_CDU_LSK_L4 INC", "PLT_CDU_LSK_L4 DEC"),
                new CDUMappedCommandKey(2, 1 << 3, false, CDU737Keys.LSK5,"PLT_CDU_LSK_L5 INC", "PLT_CDU_LSK_L5 DEC"),
                new CDUMappedCommandKey(2, 1 << 2, false, CDU737Keys.LSK6,"PLT_CDU_LSK_L6 INC", "PLT_CDU_LSK_L6 DEC"),

                // Group 3
                new CDUMappedCommandKey(3, 1 << 6, false, CDU737Keys.INITREF,"PLT_CDU_MSN 1", "PLT_CDU_MSN 0"),
                new CDUMappedCommandKey(3, 1 << 5, false, CDU737Keys.RTE, "PLT_CDU_FPLN 1", "PLT_CDU_FPLN 0"),
                new CDUMappedCommandKey(3, 1 << 4, false, CDU737Keys.CLB, "PLT_CDU_FD 1", "PLT_CDU_FD 0"),
                new CDUMappedCommandKey(3, 1 << 3, false, CDU737Keys.CRZ, "PLT_CDU_IDX 1", "PLT_CDU_IDX 0"),
                new CDUMappedCommandKey(3, 1 << 2, false, CDU737Keys.DES, "PLT_CDU_DIR 1", "PLT_CDU_DIR 0" ),
                new CDUMappedCommandKey(3, 1 << 1, false, CDU737Keys.BRT_MINUS, "PLT_CDU_DIM INC", "PLT_CDU_DIM DEC"),
                new CDUMappedCommandKey(3, 1 << 0, false, CDU737Keys.BRT_PLUS, "PLT_CDU_BRT INC", "PLT_CDU_BRT DEC"),

                // Group 4
                
                new CDUMappedCommandKey(4, 1 << 5, false, CDU737Keys.MENU , "PLT_CDU_SNSR INC" , "PLT_CDU_SNSR DEC"),
                new CDUMappedCommandKey(4, 1 << 4, false, CDU737Keys.LEGS , "PLT_CDU_MARK INC", "PLT_CDU_MARK DEC"),
                new CDUMappedCommandKey(4, 1 << 3, false, CDU737Keys.DEP_ARR, "PLT_CDU_CNI INC", "PLT_CDU_CNI DEC"),
                new CDUMappedCommandKey(4, 1 << 2, false, CDU737Keys.HOLD, "PLT_CDU_TDL INC", "PLT_CDU_TDL DEC"),
                new CDUMappedCommandKey(4, 1 << 1, false, CDU737Keys.PROG,"PLT_CDU_ASE INC", "PLT_CDU_ASE DEC" ),
                new CDUMappedCommandKey(4, 1 << 0, false, CDU737Keys.EXEC,"PLT_CDU_STAT INC", "PLT_CDU_STAT DEC"),

                // Group 5
                new CDUMappedCommandKey(5, 1 << 6, false, CDU737Keys.N1LIMIT),
                new CDUMappedCommandKey(5, 1 << 5, false, CDU737Keys.FIX, "PLT_CDU_DATA INC" ,"PLT_CDU_DATA DEC"),
                new CDUMappedCommandKey(5, 1 << 4, false, CDU737Keys.A,"PLT_CDU_A INC", "PLT_CDU_A DEC"),
                new CDUMappedCommandKey(5, 1 << 3, false, CDU737Keys.B,"PLT_CDU_B INC", "PLT_CDU_B DEC"),
                new CDUMappedCommandKey(5, 1 << 2, false, CDU737Keys.C,"PLT_CDU_C INC", "PLT_CDU_C DEC"),
                new CDUMappedCommandKey(5, 1 << 1, false, CDU737Keys.D,"PLT_CDU_D INC", "PLT_CDU_D DEC"),
                new CDUMappedCommandKey(5, 1 << 0, false, CDU737Keys.E,"PLT_CDU_E INC", "PLT_CDU_E DEC"),
                // Group 6
                new CDUMappedCommandKey(6, 1 << 6, false, CDU737Keys.PREV_PAGE,"PLT_CDU_UP INC", "PLT_CDU_UP DEC"),
                new CDUMappedCommandKey(6, 1 << 5, false, CDU737Keys.NEXT_PAGE,"PLT_CDU_DOWN INC", "PLT_CDU_DOWN DEC"),
                new CDUMappedCommandKey(6, 1 << 4, false, CDU737Keys.F,"PLT_CDU_F INC", "PLT_CDU_F DEC"),
                new CDUMappedCommandKey(6, 1 << 3, false, CDU737Keys.G,"PLT_CDU_G INC", "PLT_CDU_G DEC"),
                new CDUMappedCommandKey(6, 1 << 2, false, CDU737Keys.H,"PLT_CDU_H INC", "PLT_CDU_H DEC"),
                new CDUMappedCommandKey(6, 1 << 1, false, CDU737Keys.I,"PLT_CDU_I INC", "PLT_CDU_I DEC"),
                new CDUMappedCommandKey(6, 1 << 0, false, CDU737Keys.J,"PLT_CDU_J INC", "PLT_CDU_J DEC"),

                // Group 7
                new CDUMappedCommandKey(7, 1 << 7, false, CDU737Keys.K1,"PLT_CDU_1 INC", "PLT_CDU_1 DEC"),
                new CDUMappedCommandKey(7, 1 << 6, false, CDU737Keys.K2,"PLT_CDU_2 INC", "PLT_CDU_2 DEC"),
                new CDUMappedCommandKey(7, 1 << 5, false, CDU737Keys.K3,"PLT_CDU_3 INC", "PLT_CDU_3 DEC"),
                new CDUMappedCommandKey(7, 1 << 4, false, CDU737Keys.K,"PLT_CDU_K INC", "PLT_CDU_K DEC"),
                new CDUMappedCommandKey(7, 1 << 3, false, CDU737Keys.L,"PLT_CDU_L INC", "PLT_CDU_L DEC"),
                new CDUMappedCommandKey(7, 1 << 2, false, CDU737Keys.M,"PLT_CDU_M INC", "PLT_CDU_M DEC"),
                new CDUMappedCommandKey(7, 1 << 1, false, CDU737Keys.N,"PLT_CDU_N INC", "PLT_CDU_N DEC"),
                new CDUMappedCommandKey(7, 1 << 0, false, CDU737Keys.O,"PLT_CDU_O INC", "PLT_CDU_O DEC"),

                // Group 8
                new CDUMappedCommandKey(8, 1 << 7, false, CDU737Keys.K4,"PLT_CDU_4 INC", "PLT_CDU_4 DEC"),
                new CDUMappedCommandKey(8, 1 << 6, false, CDU737Keys.K5,"PLT_CDU_5 INC", "PLT_CDU_5 DEC"),
                new CDUMappedCommandKey(8, 1 << 5, false, CDU737Keys.K6,"PLT_CDU_6 INC", "PLT_CDU_6 DEC"),
                new CDUMappedCommandKey(8, 1 << 4, false, CDU737Keys.P,"PLT_CDU_P INC", "PLT_CDU_P DEC"),
                new CDUMappedCommandKey(8, 1 << 3, false, CDU737Keys.Q,"PLT_CDU_Q INC", "PLT_CDU_Q DEC"),
                new CDUMappedCommandKey(8, 1 << 2, false, CDU737Keys.R,"PLT_CDU_R INC", "PLT_CDU_R DEC"),
                new CDUMappedCommandKey(8, 1 << 1, false, CDU737Keys.S,"PLT_CDU_S INC", "PLT_CDU_S DEC"),
                new CDUMappedCommandKey(8, 1 << 0, false, CDU737Keys.T,"PLT_CDU_T INC", "PLT_CDU_T DEC"),

                // Group 9
                new CDUMappedCommandKey(9, 1 << 7, false, CDU737Keys.K7,"PLT_CDU_7 INC", "PLT_CDU_7 DEC"),
                new CDUMappedCommandKey(9, 1 << 6, false, CDU737Keys.K8,"PLT_CDU_8 INC", "PLT_CDU_8 DEC"),
                new CDUMappedCommandKey(9, 1 << 5, false, CDU737Keys.K9,"PLT_CDU_9 INC", "PLT_CDU_9 DEC"),
                new CDUMappedCommandKey(9, 1 << 4, false, CDU737Keys.U,"PLT_CDU_U INC", "PLT_CDU_U DEC"),
                new CDUMappedCommandKey(9, 1 << 3, false, CDU737Keys.V,"PLT_CDU_V INC", "PLT_CDU_V DEC"),
                new CDUMappedCommandKey(9, 1 << 2, false, CDU737Keys.W,"PLT_CDU_W INC", "PLT_CDU_W DEC"),
                new CDUMappedCommandKey(9, 1 << 1, false, CDU737Keys.X,"PLT_CDU_X INC", "PLT_CDU_X DEC"),
                new CDUMappedCommandKey(9, 1 << 0, false, CDU737Keys.Y,"PLT_CDU_Y INC", "PLT_CDU_Y DEC"),

                // Group 10
                new CDUMappedCommandKey(10, 1 << 7, false, CDU737Keys.KPT,"PLT_CDU_DOT INC", "PLT_CDU_DOT DEC"),
                new CDUMappedCommandKey(10, 1 << 6, false, CDU737Keys.K0,"PLT_CDU_0 INC", "PLT_CDU_0 DEC"),
                new CDUMappedCommandKey(10, 1 << 5, false, CDU737Keys.KPM , "PLT_CDU_DASH INC", "PLT_CDU_DASH DEC"),
                new CDUMappedCommandKey(10, 1 << 4, false, CDU737Keys.Z,"PLT_CDU_Z INC", "PLT_CDU_Z DEC"),
                new CDUMappedCommandKey(10, 1 << 3, false, CDU737Keys.SP,"PLT_CDU_SP INC", "PLT_CDU_SP DEC"),
                new CDUMappedCommandKey(10, 1 << 2, false, CDU737Keys.DEL),
                new CDUMappedCommandKey(10, 1 << 1, false, CDU737Keys.SLASH,"PLT_CDU_SLASH INC", "PLT_CDU_SLASH DEC"),
                new CDUMappedCommandKey(10, 1 << 0, false, CDU737Keys.CLR,"PLT_CDU_CLR INC", "PLT_CDU_CLR DEC"),
            };

            return result;
        }


    }
}
