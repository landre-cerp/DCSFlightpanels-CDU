﻿using NonVisuals.StreamDeck.Panels;

namespace NonVisuals
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Forms;
    using NonVisuals.StreamDeck;
    using TextBox = System.Windows.Controls.TextBox;
    using Newtonsoft.Json;

    public static class Extensions
    {

        public static void SetPanel(this List<StreamDeckLayer> list, StreamDeckPanel streamDeckPanel)
        {
            foreach (var streamDeckLayer in list)
            {
                streamDeckLayer.StreamDeckPanelInstance = streamDeckPanel;
            }
        }

        /// <summary>
        /// Perform a deep Copy of the object, using Json as a serialization method. NOTE: Private members are not cloned using this method.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneJson<T>(this T source)
        {
            //Note to devs: Use Newtonsoft.Json to clone the object, not System.Text.Json; because there are a lot of Newtonsoft.Json [JsonIgnore] attributes that are ignored
            //by the System.Text.Json serializer. This could lead to recursive serialization of unwanted properties that raises an exception.

            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException($"DeepClone error. The type must be serializable");
            }

            //Following line fixes "Could not create an instance of type xxx Type is an interface or abstract class and cannot be instantiated."
            //when deepcloning IKeyPressInfo from  AddKeySequence(string description, SortedList<int, IKeyPressInfo> keySequence)
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            var jsonString = JsonConvert.SerializeObject(source, settings);
            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }

        public static bool ValidateDouble(this TextBox textBox, bool ignoreIfEmpty)
        {
            if (ignoreIfEmpty && string.IsNullOrEmpty(textBox.Text))
            {
                return true;
            }
            
            if (!double.TryParse(textBox.Text, NumberStyles.Number, StreamDeckConstants.DoubleCultureInfo, out _))
            {
                MessageBox.Show("Please enter valid number.", "Invalid number.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.SelectAll();
                return false;
            }

            return true;
        }
    }
}
