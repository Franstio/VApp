﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoScrewing {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.13.0.0")]
    internal sealed partial class Settings1 : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings1 defaultInstance = ((Settings1)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings1())));
        
        public static Settings1 Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.0.10")]
        public string PLC_TARGET {
            get {
                return ((string)(this["PLC_TARGET"]));
            }
            set {
                this["PLC_TARGET"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Host=localhost;Username=autoscrewing_usr;Password=autoscrewing_usr;Database=autos" +
            "crewing")]
        public string DBCon {
            get {
                return ((string)(this["DBCon"]));
            }
            set {
                this["DBCon"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost")]
        public string MESH_URL {
            get {
                return ((string)(this["MESH_URL"]));
            }
            set {
                this["MESH_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("123")]
        public string OPERATION_ID {
            get {
                return ((string)(this["OPERATION_ID"]));
            }
            set {
                this["OPERATION_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("123")]
        public string OPERATION_USER {
            get {
                return ((string)(this["OPERATION_USER"]));
            }
            set {
                this["OPERATION_USER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM4")]
        public string Screwing_Port {
            get {
                return ((string)(this["Screwing_Port"]));
            }
            set {
                this["Screwing_Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OPENRUN")]
        public string RunningPass {
            get {
                return ((string)(this["RunningPass"]));
            }
            set {
                this["RunningPass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Input_Path {
            get {
                return ((string)(this["Input_Path"]));
            }
            set {
                this["Input_Path"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Output_Path {
            get {
                return ((string)(this["Output_Path"]));
            }
            set {
                this["Output_Path"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string WORK_ID {
            get {
                return ((string)(this["WORK_ID"]));
            }
            set {
                this["WORK_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool logPlc {
            get {
                return ((bool)(this["logPlc"]));
            }
            set {
                this["logPlc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool logKilew {
            get {
                return ((bool)(this["logKilew"]));
            }
            set {
                this["logKilew"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool logMes {
            get {
                return ((bool)(this["logMes"]));
            }
            set {
                this["logMes"] = value;
            }
        }
    }
}
