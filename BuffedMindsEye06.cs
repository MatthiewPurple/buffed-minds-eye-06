﻿using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using buffed_minds_eye_06;

[assembly: MelonInfo(typeof(BuffedMindsEye06), "Buffed Mind's Eye (ver. 0.6)", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace buffed_minds_eye_06;
public class BuffedMindsEye06 : MelonMod
{
    // After checking for a back attack
    [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckBackAttack))]
    private class Patch
    {
        public static void Postfix(ref int __result)
        {
            // If someone has Mind's Eye, then always avoid back attacks
            if (datCalc.datCheckSkillInParty(298) == 1) __result = 0;
        }
    }

    // When getting a skill's description
    [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
    private class Patch2
    {
        public static void Postfix(ref int id, ref string __result)
        {
            // New skill description for Mind's Eye
            if (id == 298) __result = "Prevents being attacked \nfrom behind.";
        }
    }
}
