using NetEti.Globals;
using NetEti.ObjectSerializer;
using System.Text.Json;

namespace NetEti.FileTools
{
    /// <summary>
    /// Liest Dateien mit User-Konfigurationsparametern
    /// im Xml- oder Json-Format (z.B. Vishnu.exe.config.user).
    /// </summary>
    /// <remarks>
    /// File: UserSettingsAccess.cs
    /// Autor: Erik Nagel, NetEti
    /// 
    /// 05.06.2025 Erik Nagel: erstellt
    /// </remarks>
    public class UserSettingsAccess : IGetStringValue
    {
        #region public members

        /// <summary>
        /// Enthält alle aus der Userparameter-Datei eingelesenen (Anwendungs-)Einstellungen.
        /// </summary>
        public Dictionary<string, string?>? Settings { get; private set; }

        #region IGetStringValue Members

        /// <summary>
        /// Liefert genau einen Wert zu einem Key. Wenn es keinen Wert zu dem
        /// Key gibt, wird defaultValue zurückgegeben.
        /// </summary>
        /// <param name="key">Der Zugriffsschlüssel (string)</param>
        /// <param name="defaultValue">Das default-Ergebnis (string)</param>
        /// <returns>Der Ergebnis-String</returns>
        public string? GetStringValue(string key, string? defaultValue)
        {
            if (this.Settings != null && this.Settings.ContainsKey(key))
            {
                return this.Settings[key];
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Liefert ein string-Array zu einem Key. Wenn es keinen Wert zu dem
        /// Key gibt, wird defaultValue zurückgegeben.
        /// </summary>
        /// <param name="key">Der Zugriffsschlüssel (string)</param>
        /// <param name="defaultValues">Das default-Ergebnis (string[])</param>
        /// <returns>Das Ergebnis-String-Array</returns>
        public string?[]? GetStringValues(string key, string?[]? defaultValues)
        {
            string paraKey = (key ?? "");
            List<string?> res = new List<string?>();
            if (this.Settings != null)
            {
                foreach (string settingskey in this.Settings.Keys)
                {
                    if (paraKey == "" || settingskey == paraKey)
                    {
                        res.Add(this.Settings[settingskey]);
                    }
                }
            }
            if (res.Count > 0)
            {
                return res.ToArray();
            }
            else
            {
                return defaultValues;
            }
        }

        /// <summary>
        /// Liefert einen beschreibenden Namen dieses StringValueGetters,
        /// z.B. Name plus ggf. Quellpfad.
        /// </summary>
        public string Description { get; set; }

        #endregion IGetStringValue members

        /// <summary>
        /// Liest die ganze Datei in den Speicher.
        /// </summary>
        /// <param name="documentPathName">Pfad und Name der Userparameter-Datei</param>
        /// <exception cref="Exception">Bei fehlerhaftem Document.</exception>
        /// <exception cref="ArgumentException">Bei Übergabe eines illegalen Pfadnamens.</exception>
        /// <exception cref="UnauthorizedAccessException">Unerlaubter Zugriff.</exception>
        /// <exception cref="System.Security.SecurityException">Unerlaubter Zugriff.</exception>
        public UserSettingsAccess(string documentPathName)
        {
            this.Description = documentPathName;
            this.LoadSettings(documentPathName);
        }

        #endregion public members

        #region private members

        private void LoadSettings(string documentPathName)
        {
            this.Settings = new Dictionary<string, string?>();
            this.Description = documentPathName;
            string jsonOrXml = File.ReadAllText(documentPathName);
            if (jsonOrXml.Trim().StartsWith('{') || jsonOrXml.Trim().StartsWith('['))
            {
                Dictionary<string, object>? dict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonOrXml);
                if (dict != null)
                {
                    foreach (KeyValuePair<string, object> kvp in dict)
                    {
                        this.Settings.Add(kvp.Key, kvp.Value.ToString());
                    }
                }
            }
            else
            {
                if (jsonOrXml.Trim().StartsWith('<'))
                {
                    FrameworkConfiguration? frameworkConfiguration
                        = SerializationUtility.DeserializeFromXml<FrameworkConfiguration>(jsonOrXml);
                    if (frameworkConfiguration?.ConfigAppSettings?.Add != null)
                    {
                        foreach (FrameworkConfigAppSettingEntry entry in frameworkConfiguration.ConfigAppSettings.Add)
                        {
                            if (entry.Key != null)
                            {
                                this.Settings.Add(entry.Key, entry.Value);
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException(
                        "Der Parameter 'jsonOrXml' hat kein bekanntes Format. Unterstützt werden Xml und Json.");
                }
            }
        }

        #endregion private members

    }
}
