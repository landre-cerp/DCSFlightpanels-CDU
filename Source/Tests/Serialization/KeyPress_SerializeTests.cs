﻿using DCSFPTests.Serialization.Common;
using Newtonsoft.Json;
using NonVisuals.KeyEmulation;
using Xunit;

namespace DCSFPTests.Serialization {
    public static class KeyPress_SerializeTests {

        [Fact]
        public static void KeyPress_ShouldBeSerializable() {
            KeyPress s = GetObject();

            string serializedObj = JsonConvert.SerializeObject(s, Formatting.Indented, JSonSettings.JsonDefaultSettings);
            KeyPress d = JsonConvert.DeserializeObject<KeyPress>(serializedObj, JSonSettings.JsonDefaultSettings);

            Assert.True(s.Information == d.Information);
            Assert.True(s.Description == d.Description);
            Assert.True(s.Abort == d.Abort);

            //not serialized : 
            Assert.Empty(d.NegatorOSKeyPresses);

            RepositorySerialized repo = new();
            //Save sample file in project (use it only once)
            //repo.SaveSerializedObjectToFile(s.GetType(), serializedObj);

            KeyPress deseralizedObjFromFile = JsonConvert.DeserializeObject<KeyPress>(repo.GetSerializedObjectString(s.GetType()), JSonSettings.JsonDefaultSettings);

            Assert.True(s.Information == deseralizedObjFromFile.Information);
            Assert.True(s.Description == deseralizedObjFromFile.Description);
            Assert.True(s.Abort == deseralizedObjFromFile.Abort);
            Assert.Empty(deseralizedObjFromFile.NegatorOSKeyPresses);
        }

        public static KeyPress GetObject(int instanceNbr = 1) {
            return new()
            {
                Information = $"ecw azs {instanceNbr}",
                Description = $"wws zze {instanceNbr}",
                Abort = true,
                KeyPressSequence = new() {
                    { instanceNbr, KeyPressInfo_SerializeTests.GetObject(instanceNbr) },
                    { instanceNbr+1, KeyPressInfo_SerializeTests.GetObject(instanceNbr+1)} 
                }
            };
        }
    }
}
